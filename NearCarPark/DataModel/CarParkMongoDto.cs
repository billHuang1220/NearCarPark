using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.DataModel
{



    [BsonIgnoreExtraElements]
    public class CarParkMongoDbRealtime
    {
        [BsonElement("_id")]
        public string? CpId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("e_name")]
        public string EName { get; set; }


        [BsonElement("p_name")]
        public string PName { get; set; }

        [BsonElement("car_cnt")]

        public int CarCnt { get; set; }

        [BsonElement("mb_cnt")]
        public int MbCnt { get; set; }

        [BsonElement("time")]
        public DateTime Time { get; set; }

        [BsonElement("maintain")]
        public bool Maintain { get; set; }


    }

    [BsonIgnoreExtraElements]
    public class CarParkMongoDbAnaylst
    {
        [BsonElement("_id")]
        public string? CpId { get; set; }

        [BsonElement("anaylstObject")]
        public List<CarParKAnalystObject> AnalystObjects { get; set; }

    }

    public class CarParKAnalystObject
    {
        public DateTime TimeIndex { get; set; }
        public int CarCnt { get; set; }
        public int MbCnt { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class  CarParkInfoMongoDetail
    {
        public string CpId { get; set; }

        public string? NameC { get; set; }

        public string? LocationC { get; set; }

        public string? CarParkEntryC { get; set; }

        public string? ContactNo { get; set; }

        public string? NameP { get; set; }

        public string? LocationP { get; set; }

        public string? CarParkEntryP { get; set; }

        public double XCoords { get; set; }

        public double YCoords { get; set; }

        public string? Height { get; set; }

        public string? DsccX { get; set; }

        public string? DsccY { get; set; }

        public string? LcarPriceC { get; set; }

        public string? HcarPriceC { get; set; }

        public string? MotoPriceC { get; set; }

        public string? RemarkPriceC { get; set; }

        public string? LcarPriceP { get; set; }

        public string? HcarPriceP { get; set; }

        public string? MotoPriceP { get; set; }

        public string? RemarkPriceP { get; set; }

        public string? ZoneC { get; set; }

        public string? ZoneP { get; set; }

        public string? ZoneE { get; set; }

        public string? SubdistrictC { get; set; }

        public string? SubdistrictP { get; set; }

        public string? SubdistrictE { get; set; }

        public string? NameE { get; set; }

        public string? LocationE { get; set; }

        public string? CarParkEntryE { get; set; }

        public string? LcarPriceE { get; set; }

        public string? HcarPriceE { get; set; }

        public string? MotoPriceE { get; set; }

        public string? RemarkPriceE { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class LocationInfoMongo
    {
        [BsonElement("_id")] 
        public ObjectId _id { get; set; }

        [BsonElement("name_cn")]
        public string nameCN { get; set; }
        [BsonElement("name_pt")]
        public string namePT { get; set; }

        [BsonElement("latitude")]
        public double lat { get; set; }
        [BsonElement("longitude")]
        public double lng { get; set; }
        [BsonElement("isDeleted")]
        public bool isDeleted { get; set; }
    }
}
