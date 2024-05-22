using CarPark.DataModel;
using CarPark.DatabaseContext;

namespace CarPark.DbWorker
{
    public static class CarParkInfoExtentsion
    {
        public static CarParkInfoRealTime ToDbObj(this CarParkInfoRealtimeDto carPark)
        {
            return new CarParkInfoRealTime
            {
                Id = Int32.Parse(carPark.ID),
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
                CpId = carParkInfo.CP_ID,
                NameC = carParkInfo.NameC,
                LocationC = carParkInfo.LocationC,
                CarParkEntryC = carParkInfo.CarParkEntryC,
                ContactNo = carParkInfo.ContactNo,
                NameP = carParkInfo.NameP,
                LocationP = carParkInfo.LocationP,
                CarParkEntryP = carParkInfo.CarParkEntryP,
                XCoords =  carParkInfo.X_coords,
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
    }
}
