using System.Xml.Serialization;

namespace CarPark.DataModel
{
    [XmlRoot("CarPark")]
    public class CarParkRealTimeList
    {
        [XmlElement("Car_park_info")]
        public List<CarParkInfoRealtimeDto>? CarParkInfos { get; set; }
    }

    public class CarParkInfoRealtimeDto
    {
        [XmlAttribute(attributeName: "ID")]
        public string? ID { get; set; }

        [XmlAttribute("name")]
        public string? Name { get; set; }

        [XmlAttribute("CP_EName")]
        public string? CP_EName { get; set; }

        [XmlAttribute("CP_PName")]
        public string? CP_PName { get; set; }

        [XmlAttribute("Car_CNT")]
        public string? Car_CNT { get; set; }

        [XmlAttribute("MB_CNT")]
        public string? MB_CNT { get; set; }

        [XmlAttribute("Time")]
        public string? Time { get; set; }

        [XmlAttribute("maintenance")]
        public string? Maintenance { get; set; }
    }


    [XmlRoot("CarPark")]

    public class CarParkDetailList
    {

        [XmlElement("Car_park_info")]
        public List<CarParkDetailDto>? CarParkInfos { get; set; }
    }

    public class CarParkDetailDto
    {
        [XmlAttribute("CP_ID")]
        public int CP_ID { get; set; }

        [XmlAttribute("NameC")]
        public string NameC { get; set; }

        [XmlAttribute("LocationC")]
        public string LocationC { get; set; }

        [XmlAttribute("CarParkEntryC")]
        public string CarParkEntryC { get; set; }

        [XmlAttribute("ContactNo")]
        public string ContactNo { get; set; }

        [XmlAttribute("NameP")]
        public string NameP { get; set; }

        [XmlAttribute("LocationP")]
        public string LocationP { get; set; }

        [XmlAttribute("CarParkEntryP")]
        public string CarParkEntryP { get; set; }

        [XmlAttribute("X_coords")]
        public double X_coords { get; set; }

        [XmlAttribute("Y_coords")]
        public double Y_coords { get; set; }

        [XmlAttribute("height")]
        public string Height { get; set; }

        [XmlAttribute("DSCC_X")]
        public string DSCC_X { get; set; }

        [XmlAttribute("DSCC_Y")]
        public string DSCC_Y { get; set; }

        [XmlAttribute("Lcar_price_C")]
        public string Lcar_price_C { get; set; }

        [XmlAttribute("Hcar_price_C")]
        public string Hcar_price_C { get; set; }

        [XmlAttribute("moto_price_C")]
        public string Moto_price_C { get; set; }

        [XmlAttribute("remark_price_C")]
        public string Remark_price_C { get; set; }

        [XmlAttribute("Lcar_price_P")]
        public string Lcar_price_P { get; set; }

        [XmlAttribute("Hcar_price_P")]
        public string Hcar_price_P { get; set; }

        [XmlAttribute("moto_price_P")]
        public string Moto_price_P { get; set; }

        [XmlAttribute("remark_price_P")]
        public string Remark_price_P { get; set; }

        [XmlAttribute("zone_C")]
        public string Zone_C { get; set; }

        [XmlAttribute("zone_P")]
        public string Zone_P { get; set; }

        [XmlAttribute("zone_E")]
        public string Zone_E { get; set; }

        [XmlAttribute("subdistrict_C")]
        public string Subdistrict_C { get; set; }

        [XmlAttribute("subdistrict_P")]
        public string Subdistrict_P { get; set; }

        [XmlAttribute("subdistrict_E")]
        public string Subdistrict_E { get; set; }

        [XmlAttribute("NameE")]
        public string NameE { get; set; }

        [XmlAttribute("LocationE")]
        public string LocationE { get; set; }

        [XmlAttribute("CarParkEntryE")]
        public string CarParkEntryE { get; set; }

        [XmlAttribute("Lcar_price_E")]
        public string Lcar_price_E { get; set; }

        [XmlAttribute("Hcar_price_E")]
        public string Hcar_price_E { get; set; }

        [XmlAttribute("moto_price_E")]
        public string Moto_price_E { get; set; }

        [XmlAttribute("remark_price_E")]
        public string Remark_price_E { get; set; }

        // Add more properties as needed
    }

}
