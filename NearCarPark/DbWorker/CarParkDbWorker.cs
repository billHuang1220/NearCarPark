using CarPark.Crawler;
using CarPark.DatabaseContext;
using CarPark.DataModel;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace CarPark.DbWorker
{
    public interface IDbWorker
    {
        public Task<List<CarParkListDto>> GetAnalystAsync();
        public Task<List<CarSlotHistorySingleDto>> GetCarSlotAnalystAsync(string date, string cpID);
        public Task<List<MBSlotParkHistorySingleDto>> GetMbSlotAnalystAsync(string date, string cpID);
        public Task<List<CarParkIntroDto>> GetCarNearestCarParkAsync(float lat, float lng);
        public Task<List<CarParkIntroDto>> GetMbNearestCarParkAsync(float lat, float lng);
        public Task<List<string>> AvailableAnalystsDateAsync();
        public Task<bool> InsertToAnalystDbAsync(List<CarParkInfoRealtimeDto> carParks);
        public Task<bool> SaveToDbAsync(List<CarParkInfoRealtimeDto> carParks);
        public Task<bool> SaveToDetailDbAsync(List<CarParkDetailDto> carParks);
        public Task<bool> UpdateToDbAsync(List<CarParkInfoRealtimeDto> carParks);
        public Task<List<LocationDto>> FindAutoFillListAsync(string prefix);
        public Task<bool> InsertToLocationAsync(List<LocationDto> location);
        public Task<bool> DeleteLocationAsync(string id);
        public Task<bool> UpdateLocationAsync(LocationDto location, string id);

        public Task<List<LocationDto>> GetAllLocations();

    }


    public class CarParkDbWorker(CarParkDbContext _context,CarApiCrawler _crawler): IDbWorker
    {
        private DateTime LastUpdate = DateTime.UtcNow;
        private int UpdateInterval = 5;

        public async Task<bool> UpdateToDbAsync(List<CarParkInfoRealtimeDto> carParks)
        {
            _context.CarParkInfoRealTimes
                .UpdateRange(carParks.Select(x => x.ToDbObj()));
            var result = await _context.SaveChangesAsync();
            return result == carParks.Count;
        }

        public Task<List<LocationDto>> FindAutoFillListAsync(string prefix)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertToLocationAsync(List<LocationDto> location)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteLocationAsync(String id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateLocationAsync(LocationDto location, string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LocationDto>> GetAllLocations()
        {
            throw new NotImplementedException();
        }


        public async Task<bool> InsertToAnalystDbAsync(List<CarParkInfoRealtimeDto> carParks)
        {
            CarParkAnalyst analystRow = new CarParkAnalyst();
            analystRow.SetCarParkAnalyst(carParks);

            var entity = await _context.CarParkAnalysts.FindAsync(analystRow.TimeIndex);

            if (entity == null)
            {
                await _context.AddAsync(analystRow);
            }

            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> SaveToDbAsync(List<CarParkInfoRealtimeDto> carParks)
        {
            await _context.CarParkInfoRealTimes.AddRangeAsync(carParks.Select(x => x.ToDbObj()));
            var result = await _context.SaveChangesAsync();
            return result == carParks.Count;
        }

        public Task<bool> SaveToDetailDbAsync(List<CarParkDetailDto> carParks)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveToDbAsync(List<CarParkDetailDto> carParks)
        {
            await _context.CarParkInfoDetails.AddRangeAsync(carParks.Select(x => x.ToDbObj()));
            var result = await _context.SaveChangesAsync();
            return result == carParks.Count;
        }

        public async Task<List<CarParkListDto>> GetAnalystAsync()
        {
            var result = (await _context.CarParkInfoDetails
                .Select(x => new CarParkListDto
                {
                    nameC = x.NameC,
                    hasCarSlot = (x.LcarPriceC != "-"),
                    hasMBSlot = (x.MotoPriceC != "-"),
                    cp_ID = x.CpId

                })
                .ToListAsync());

            return result;
        }

        public async Task<List<CarSlotHistorySingleDto>> GetCarSlotAnalystAsync(string date, string cpID)
        {

            if (!await _context.CarParkAnalysts.AnyAsync(x => x.TimeIndex.Substring(0, 4) == date))
                throw new ArgumentException($"Error finding data with date: {date}");


            var result = await _context.CarParkAnalysts
                .Where(x => x.TimeIndex.Substring(0, 4) == date)
                .Select(x => x.ToSingleCarSlotHistory(cpID))
                .ToListAsync();


            return result;
        }


        public async Task<List<MBSlotParkHistorySingleDto>> GetMbSlotAnalystAsync(string date, string cpID)
        {

            if (!await _context.CarParkAnalysts.AnyAsync(x => x.TimeIndex.Substring(0, 4) == date))
                throw new ArgumentException($"Error finding data with date: {date}");


            var result = await _context.CarParkAnalysts
                .Where(x => x.TimeIndex.Substring(0, 4) == date)
                .Select(x => x.ToSingleMBSlotHistory(cpID))
                .ToListAsync();


            return result;
        }

        public async Task<bool> CheckUpdateCarParkRealtimeAsync()
        {
            if (DateTime.UtcNow.Subtract(LastUpdate).Seconds >= UpdateInterval)
            {
                LastUpdate = DateTime.UtcNow;
                var realtimeData = await _crawler.GetCarParkRealTimeAsync();
                return await UpdateToDbAsync(realtimeData);

            }

            return false;
        }



        public async Task<List<CarParkIntroDto>> GetCarNearestCarParkAsync(float lat, float lng)
        {
            _ = await CheckUpdateCarParkRealtimeAsync();

            var carParks = await (from x in _context.CarParkInfoRealTimes
                                  join y in _context.CarParkInfoDetails
                                      on x.Id equals y.CpId
                                  select new CarParkIntroDto
                                  { 
                                      nameC = x.Name,
                                      lat =y.XCoords,
                                      lng = y.YCoords,
                                      count =x.CarCnt,
                                  })
                .ToListAsync();

            var sortCarParks = carParks.OrderBy(
                cp => cp.GetDistance(lat, lng)).Take(5).ToList();
            if (sortCarParks.Count <= 0)
                throw new Exception("No car park available now");

            return sortCarParks;
        }

        public async Task<List<CarParkIntroDto>> GetMbNearestCarParkAsync(float lat, float lng)
        {
            _ = await CheckUpdateCarParkRealtimeAsync();


            var carParks = await (from x in _context.CarParkInfoRealTimes
                                  join y in _context.CarParkInfoDetails
                                      on x.Id equals y.CpId
                                  where x.MbCnt > 0
                                  select new CarParkIntroDto
                                  {
                                      nameC = x.Name,
                                      lat = y.XCoords,
                                      lng = y.YCoords,
                                      count = x.MbCnt,
                                  })
                .ToListAsync();

            var sortCarParks = carParks.OrderBy(
                cp => cp.GetDistance(lat, lng)).Take(5).ToList();

            if (sortCarParks.Count <= 0)
                throw new Exception("No car park available now");

            
            return sortCarParks;
        
        }


        public async Task<List<string>> AvailableAnalystsDateAsync()
        {
            var date = await _context.CarParkAnalysts.Select(x => x.TimeIndex).ToListAsync();
            HashSet<string> filteredDate = new HashSet<string>();
            foreach (var d in date)
            {
                filteredDate.Add(d.Substring(0, 4));
            }

            if (filteredDate.Count <= 0)
                throw new Exception("Can not find any available analysts data");
            return filteredDate.ToList();
        }
    }
}
