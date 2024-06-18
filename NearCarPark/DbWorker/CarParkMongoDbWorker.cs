using System.Globalization;
using CarPark.Crawler;
using CarPark.DataModel;
using MongoDB.Bson;
using MongoDB.Driver;
using static System.Net.Mime.MediaTypeNames;

namespace CarPark.DbWorker
{
    public class CarParkMongoDbWorker : IDbWorker
    {
        private readonly IMongoCollection<CarParkMongoDbRealtime> _realTimeCollection;
        private readonly IMongoCollection<CarParkInfoMongoDetail> _detailCollection;
        private readonly IMongoCollection<CarParkMongoDbAnaylst> _analystCollection;
        private readonly IMongoCollection<LocationInfoMongo> _locationCollection;

        private readonly CarApiCrawler _crawler;

        private DateTime _lastUpdate = DateTime.UtcNow;
        private const int UpdateInterval = 5;

        public CarParkMongoDbWorker(IMongoClient client, CarApiCrawler crawler)
        {

            _realTimeCollection =
                client.GetDatabase("CarParkDB").GetCollection<CarParkMongoDbRealtime>("CarParkRealtime");
            _detailCollection =
                client.GetDatabase("CarParkDB").GetCollection<CarParkInfoMongoDetail>("CarParkDetailInfo");
            _analystCollection =
                client.GetDatabase("CarParkDB").GetCollection<CarParkMongoDbAnaylst>("CarParkAnalyst");
            _locationCollection =
                client.GetDatabase("CarParkDB").GetCollection<LocationInfoMongo>("Locations");

            _crawler = crawler;
        }

        public async Task<bool> UpdateToDbAsync(List<CarParkInfoRealtimeDto> carParks)
        {
            var cps = carParks.Select(x =>
                x.ToMongoCpRealtime()).ToList();

            var updates = new List<WriteModel<CarParkMongoDbRealtime>>();
            foreach (var cp in cps)
            {
                
                updates.Add(new ReplaceOneModel<CarParkMongoDbRealtime>(Builders<CarParkMongoDbRealtime>
                    .Filter.Where(x => x.CpId == cp.CpId), cp));
            }
            try
            {
                await _realTimeCollection.BulkWriteAsync(updates, new BulkWriteOptions() { IsOrdered = true });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
        }

        public async Task<List<object>> FindAutoFillListAsync(string prefix)
        {
            var autoCompleteList = new List<object>();

            var isCN =  prefix.Any(c =>char.GetUnicodeCategory(c) == UnicodeCategory.OtherLetter);
            var filter = Builders<LocationInfoMongo>.Filter.And(
                Builders<LocationInfoMongo>.Filter.Or(
                    Builders<LocationInfoMongo>.Filter.Regex(x => x.namePT, new BsonRegularExpression(prefix, "i")),
                    Builders<LocationInfoMongo>.Filter.Regex(x => x.nameCN, new BsonRegularExpression(prefix, "i"))
                ),
                Builders<LocationInfoMongo>.Filter.Eq(x=>x.isDeleted, false)
            );
            var options = new FindOptions<LocationInfoMongo> { Limit = 10 };

            using (var cursor = await _locationCollection.FindAsync(filter, options))
            {
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        var locInfo = new
                        {
                            nameCN = document.nameCN,
                            namePT = document.namePT,
                            lat = document.lat,
                            lng = document.lng,
                            id = document._id.ToString()
                        };
                        autoCompleteList.Add(locInfo);
                    }
                }
            }

            return autoCompleteList;
        }

        public async Task<bool> InsertToLocationAsync(List<LocationDto> locations)
        {
            var locationMongoObj = locations.Select(x => x.ToMongoDbObj()).ToList();

            var temp = locationMongoObj.Select(x => x.nameCN).Distinct().ToList();

            var duplicateNameCn = await _locationCollection.Find(l => temp.Contains(l.nameCN)).ToListAsync();
            var duplicateNameEn = await _locationCollection.Find(l => temp.Contains(l.namePT)).ToListAsync();

            if (duplicateNameCn.Any()|| duplicateNameEn.Any())
                throw new Exception("Location duplicated");

            await _locationCollection.InsertManyAsync(locationMongoObj);

            return true;
        }

        public async Task<bool> DeleteLocationAsync(string id)
        {
            var update = Builders<LocationInfoMongo>.Update.Set(x => x.isDeleted, true);
            var result = await _locationCollection.UpdateOneAsync(x => x._id == ObjectId.Parse(id), update);

            return result.ModifiedCount > 0;
        }

        public async Task<bool> UpdateLocationAsync(LocationDto location, string id)
        {

            var locInfo = location.ToMongoDbObj(id);
            var result = await _locationCollection.ReplaceOneAsync(x => x._id.ToString() == id, locInfo);

            return result.ModifiedCount > 0;
        }


        public async Task<List<CarParkListDto>> GetAnalystAsync()
        {
            var result = await _detailCollection.Find(_=>true)
                .Project(x => new CarParkListDto
                {
                    nameC = x.NameC,
                    hasCarSlot = (x.LcarPriceC != "-"),
                    hasMBSlot = (x.MotoPriceC != "-"),
                    cp_ID = x.CpId
                })
                .SortBy(x=>x.CpId)
                .ToListAsync();

            return result;
        }

        public async Task<List<CarSlotHistorySingleDto>> GetCarSlotAnalystAsync(string date, string cpID)
        {
            var analyst = await _analystCollection.Find(x => x.CpId == cpID).FirstOrDefaultAsync();
            if (analyst == null)
            {
                throw new ArgumentException($"Error finding data with date: {date}");
            }

            var result = analyst.AnalystObjects.Select(obj => new CarSlotHistorySingleDto
            {
                timeIndex = obj.TimeIndex.ToTimeIndexString().Substring(4),
                count = obj.CarCnt
            }).ToList();

            return result;
        }

        public async Task<List<MBSlotParkHistorySingleDto>> GetMbSlotAnalystAsync(string date, string cpID)
        {
            var analyst = await _analystCollection.Find(x => x.CpId == cpID).FirstOrDefaultAsync();
            if (analyst == null)
            {
                throw new ArgumentException($"Error finding data with date: {date}");
            }

            var result = analyst.AnalystObjects.Select(obj => new MBSlotParkHistorySingleDto
            {
                timeIndex = obj.TimeIndex.ToTimeIndexString().Substring(4),
                count = obj.MbCnt
            }).ToList();

            return result;
        }

        public async Task<List<CarParkIntroDto>> GetCarNearestCarParkAsync(float lat, float lng)
        {
            await CheckUpdateCarParkRealtimeAsync();

            var carParks = _detailCollection.AsQueryable().ToList()
                .Join(
                    _realTimeCollection.AsQueryable(),
                    x => x.CpId,
                    y => y.CpId,
                    (x, y) => new CarParkIntroDto
                    {
                        nameC = x.NameC,
                        lat = x.XCoords,
                        lng = x.YCoords,
                        count = y.CarCnt,
                        priceString = x.LcarPriceC.Replace("##", "\n")
        }
                )
                .Where(x=>x.count>0)
                .ToList();

            var sortCarParks = carParks.OrderBy(cp => cp.GetDistance(lat, lng)).Take(5).ToList();
            if (sortCarParks.Count <= 0)
                throw new Exception("No car park available now");
            return sortCarParks;

        }

        public async Task<List<CarParkIntroDto>> GetMbNearestCarParkAsync(float lat, float lng)
        {
            await CheckUpdateCarParkRealtimeAsync();

            var carParks = _detailCollection.AsQueryable().ToList()
                .Join(
                    _realTimeCollection.AsQueryable(),
                    x => x.CpId,
                    y => y.CpId,
                    (x, y) => new CarParkIntroDto
                    {
                        nameC = x.NameC,
                        lat = x.XCoords,
                        lng = x.YCoords,
                        count = y.MbCnt,
                        priceString = x.MotoPriceC.Replace("##", "\n")

                    }
                )
                .Where(x => x.count > 0)
                .ToList();

            var sortCarParks = carParks.OrderBy(cp => cp.GetDistance(lat, lng)).Where(x=>x.count>0).Take(5).ToList();
            if (sortCarParks.Count <= 0)
                throw new Exception("No car park available now");
            return sortCarParks;
        }

        public async Task<bool> CheckUpdateCarParkRealtimeAsync()
        {
            if (DateTime.UtcNow.Subtract(_lastUpdate).Seconds >= UpdateInterval)
            {
                _lastUpdate = DateTime.UtcNow;
                var realtimeData = await _crawler.GetCarParkRealTimeAsync();
                return await UpdateToDbAsync(realtimeData);

            }

            return false;
        }

        public async Task<List<string>> AvailableAnalystsDateAsync()
        {
            var analyst = _analystCollection.AsQueryable().First().AnalystObjects
                .Select(x => x.TimeIndex.ToTimeIndexString().Substring(0, 4))
                .ToHashSet().ToList();
          
            return analyst;
        }

        public async Task<bool> InsertToAnalystDbAsync(List<CarParkInfoRealtimeDto> carParks)
        {
            foreach (var cp in carParks)
            {
                var filter = Builders<CarParkMongoDbAnaylst>.Filter.Eq(x => x.CpId, cp.ID);
                var update = Builders<CarParkMongoDbAnaylst>.Update.Push(x => x.AnalystObjects, new CarParKAnalystObject
                {
                    TimeIndex = DateTime.Parse(cp.Time),
                    CarCnt = cp.Car_CNT != "" ? int.Parse(cp.Car_CNT) : -1,
                    MbCnt = cp.MB_CNT != "" ? int.Parse(cp.MB_CNT) : -1
                });

                await _analystCollection.UpdateOneAsync(filter, update);
            }

            return true;
        }
        public async Task<bool> InitAnalystDbAsync(List<CarParkInfoRealtimeDto> carParks)
        {
            var cp = carParks.Select(x =>
                x.CarParkAnalystToMongo()).ToList();


            await _analystCollection.InsertManyAsync(cp);
            return true;
        }

        public async Task<bool> SaveToDbAsync(List<CarParkInfoRealtimeDto> carParks)
        {
          var cp =  carParks.Select(x => 
              x.ToMongoCpRealtime()).ToList();

      
                await _realTimeCollection.InsertManyAsync(cp);
                return true;

        }

        public async Task<bool> SaveToDetailDbAsync(List<CarParkDetailDto> carParks)
        {
            var cp = carParks.Select(x =>
                x.ToMongoDbObj()).ToList();


            await _detailCollection.InsertManyAsync(cp);
            return true;

        }

      

        

    }
}
