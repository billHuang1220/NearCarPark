
namespace CarPark.DataModel
{

    public class CarSlotHistorySingleDto
    {
        public string timeIndex { get; set; }
        public int count { get; set; }

    }
    public class MBSlotParkHistorySingleDto
    {
        public string timeIndex { get; set; }
        public int count { get; set; }

    }
    public class CarParkIntroDto
    {
        public string nameC { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public int count { get; set; }
        public double distance { get; set; }
        public string priceString { get; set; }


    }

    public class CarParkListDto
    {
        public string? nameC { get; set; }
        public bool hasCarSlot { get; set; }
        public bool hasMBSlot { get; set; }
        public string cp_ID { get; set; }
    }
}
