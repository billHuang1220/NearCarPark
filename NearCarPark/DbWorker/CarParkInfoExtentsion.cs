using CarPark.DataModel;
using CarPark.DatabaseContext;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace CarPark.DbWorker
{
    public static class CarParkInfoExtentsion
    {
        public static CarParkInfoRealTime ToDbObj(this CarParkInfoRealtimeDto carPark)
        {
            return new CarParkInfoRealTime
            {
                Id =carPark.ID,
                Name = carPark.Name,
                CpEname = carPark.CP_EName,
                CpPname = carPark.CP_EName,
                CarCnt = carPark.Car_CNT != "" ? Int32.Parse(carPark.Car_CNT) : -1,
                MbCnt = carPark.MB_CNT != "" ? Int32.Parse(carPark.MB_CNT) : -1,
                Time = System.DateTime.Parse(carPark.Time),
                Maintenance = carPark.Maintenance == "0" ? false : true,
            };
        }

        public static CarParkInfoDetail ToDbObj(this CarParkDetailDto carParkInfo)
        {
            return new CarParkInfoDetail
            {
                CpId = carParkInfo.CP_ID.ToString(),
                NameC = carParkInfo.NameC,
                LocationC = carParkInfo.LocationC,
                CarParkEntryC = carParkInfo.CarParkEntryC,
                ContactNo = carParkInfo.ContactNo,
                NameP = carParkInfo.NameP,
                LocationP = carParkInfo.LocationP,
                CarParkEntryP = carParkInfo.CarParkEntryP,
                XCoords = carParkInfo.X_coords,
                YCoords = carParkInfo.Y_coords,
                Height = carParkInfo.Height,
                DsccX = carParkInfo.DSCC_X,
                DsccY = carParkInfo.DSCC_Y,
                LcarPriceC = carParkInfo.Lcar_price_C,
                HcarPriceC = carParkInfo.Hcar_price_C,
                MotoPriceC = carParkInfo.Moto_price_C,
                RemarkPriceC = carParkInfo.Remark_price_C,
                LcarPriceP = carParkInfo.Lcar_price_P,
                HcarPriceP = carParkInfo.Hcar_price_P,
                MotoPriceP = carParkInfo.Moto_price_P,
                RemarkPriceP = carParkInfo.Remark_price_P,
                ZoneC = carParkInfo.Zone_C,
                ZoneP = carParkInfo.Zone_P,
                ZoneE = carParkInfo.Zone_E,
                SubdistrictC = carParkInfo.Subdistrict_C,
                SubdistrictP = carParkInfo.Subdistrict_P,
                SubdistrictE = carParkInfo.Subdistrict_E,
                NameE = carParkInfo.NameE,
                LocationE = carParkInfo.LocationE,
                CarParkEntryE = carParkInfo.CarParkEntryE,
                LcarPriceE = carParkInfo.Lcar_price_E,
                HcarPriceE = carParkInfo.Hcar_price_E,
                MotoPriceE = carParkInfo.Moto_price_E,
                RemarkPriceE = carParkInfo.Remark_price_E
            };
        }
        public static CarParkInfoMongoDetail ToMongoDbObj(this CarParkDetailDto carParkInfo)
        {
            return new CarParkInfoMongoDetail
            {
                CpId = carParkInfo.CP_ID.ToString(),
                NameC = carParkInfo.NameC,
                LocationC = carParkInfo.LocationC,
                CarParkEntryC = carParkInfo.CarParkEntryC,
                ContactNo = carParkInfo.ContactNo,
                NameP = carParkInfo.NameP,
                LocationP = carParkInfo.LocationP,
                CarParkEntryP = carParkInfo.CarParkEntryP,
                XCoords = carParkInfo.X_coords,
                YCoords = carParkInfo.Y_coords,
                Height = carParkInfo.Height,
                DsccX = carParkInfo.DSCC_X,
                DsccY = carParkInfo.DSCC_Y,
                LcarPriceC = carParkInfo.Lcar_price_C,
                HcarPriceC = carParkInfo.Hcar_price_C,
                MotoPriceC = carParkInfo.Moto_price_C,
                RemarkPriceC = carParkInfo.Remark_price_C,
                LcarPriceP = carParkInfo.Lcar_price_P,
                HcarPriceP = carParkInfo.Hcar_price_P,
                MotoPriceP = carParkInfo.Moto_price_P,
                RemarkPriceP = carParkInfo.Remark_price_P,
                ZoneC = carParkInfo.Zone_C,
                ZoneP = carParkInfo.Zone_P,
                ZoneE = carParkInfo.Zone_E,
                SubdistrictC = carParkInfo.Subdistrict_C,
                SubdistrictP = carParkInfo.Subdistrict_P,
                SubdistrictE = carParkInfo.Subdistrict_E,
                NameE = carParkInfo.NameE,
                LocationE = carParkInfo.LocationE,
                CarParkEntryE = carParkInfo.CarParkEntryE,
                LcarPriceE = carParkInfo.Lcar_price_E,
                HcarPriceE = carParkInfo.Hcar_price_E,
                MotoPriceE = carParkInfo.Moto_price_E,
                RemarkPriceE = carParkInfo.Remark_price_E
            };
        }

        private const double EarthRadiusKm = 6371.0;
        public static double GetDistance(this CarParkIntroDto carParkInfo,double lat, double lng)
        {
            double lat1Rad = ToRadians((double)carParkInfo.lat);
            double lon1Rad = ToRadians((double)carParkInfo.lng);
            double lat2Rad = ToRadians(lat);
            double lon2Rad = ToRadians(lng);

            double dlon = lon2Rad - lon1Rad;
            double dlat = lat2Rad - lat1Rad;

            double a = Math.Pow(Math.Sin(dlat / 2), 2) + Math.Cos(lat1Rad) * Math.Cos(lat2Rad) * Math.Pow(Math.Sin(dlon / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            // Convert to meter and rounded to 2 digits
            double distance = Math.Round(EarthRadiusKm * c * 1000, 2, MidpointRounding.AwayFromZero);

            carParkInfo.distance = distance;
            return distance;
        }

        private static double ToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        public static void SetCarParkAnalyst(this CarParkAnalyst analyst, List<CarParkInfoRealtimeDto> carParks)
        {
            /* int timeIndex = */
            DateTime dateTime = DateTime.Parse(carParks[0].Time);
            analyst.TimeIndex = dateTime.ToTimeIndexString();
            foreach (var carPark in carParks)
            {
                var _carParkDbObj = carPark.ToDbObj();
                string propertyName = $"Car{_carParkDbObj.Id}";
                PropertyInfo property = typeof(CarParkAnalyst).GetProperty(propertyName);
                if (property != null)
                {
                    property.SetValue(analyst, _carParkDbObj.CarCnt, null);
                }
                propertyName = $"Mb{_carParkDbObj.Id}";
                property = typeof(CarParkAnalyst).GetProperty(propertyName);
                if (property != null)
                {
                    property.SetValue(analyst, _carParkDbObj.MbCnt, null);
                }
            }

        }

        public static string ToTimeIndexString(this DateTime dateTime)
        {
            DateTime roundedDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute / 10 * 10, 0);
            return roundedDateTime.ToString("MMddHHmm");
        }

        public static CarSlotHistorySingleDto ToSingleCarSlotHistory(this CarParkAnalyst analyst, string cpID)
        {
            var car_property_str = "Car" + cpID;
            var time = analyst.TimeIndex.Substring(4);
            time = $"{time.ToString().Substring(0, 2)}:{time.ToString().Substring(2)}";
            var car_property = typeof(CarParkAnalyst).GetProperty(car_property_str);

            if (car_property == null)
            {
                throw new ArgumentException($"Error finding property with Invalid cpID: {cpID}");
            }

            return new CarSlotHistorySingleDto
            {
                timeIndex = time,
                count = (int)car_property.GetValue(analyst),
            };
        }
        public static MBSlotParkHistorySingleDto ToSingleMBSlotHistory(this CarParkAnalyst analyst, string cpID)
        {
            var mb_property_str = "Mb" + cpID;
            var time = analyst.TimeIndex.Substring(4);
            time = $"{time.ToString().Substring(0, 2)}:{time.ToString().Substring(2)}";
            var mb_property = typeof(CarParkAnalyst).GetProperty(mb_property_str);

            if (mb_property == null)
            {
                throw new ArgumentException($"Invalid cpID: {cpID}");
            }

            return new MBSlotParkHistorySingleDto
            {
                timeIndex = time,
                count = (int)mb_property.GetValue(analyst)
            };
        }

        public static CarParkMongoDbAnaylst CarParkAnalystToMongo(this CarParkInfoRealtimeDto cp)
        {
            var list = new List<CarParKAnalystObject>();
            list.Add(new CarParKAnalystObject
            {
                TimeIndex = DateTime.Parse(cp.Time),
                CarCnt = cp.Car_CNT != "" ? int.Parse(cp.Car_CNT) : -1,
                MbCnt = cp.MB_CNT != "" ? int.Parse(cp.MB_CNT) : -1,
            });
            return new CarParkMongoDbAnaylst
            {
                CpId = cp.ID,
                AnalystObjects = list
            };

        }

        public static CarParkMongoDbRealtime ToMongoCpRealtime(this CarParkInfoRealtimeDto cp)
        {
            return new CarParkMongoDbRealtime
             {
                 CpId = cp.ID,
                 Name = cp.Name,
                 EName = cp.CP_EName,
                 PName = cp.CP_PName,
                 CarCnt = cp.Car_CNT != "" ? int.Parse(cp.Car_CNT) : -1,
                 MbCnt = cp.MB_CNT != "" ? int.Parse(cp.MB_CNT) : -1,
                 Time = DateTime.Parse(cp.Time),
                 Maintain = cp.Maintenance != "0",

             };
        }


    }
}
