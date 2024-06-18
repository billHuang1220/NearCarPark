using CarPark.DataModel;
using MongoDB.Bson;

namespace CarPark.DbWorker;

public static class LocationExtension
{
    public static LocationInfoMongo ToMongoDbObj(this LocationDto location)
    {

        return new LocationInfoMongo
        {
            nameCN = location.nameCN,
            namePT = location.nameEN,
            lat = location.lat,
            lng = location.lng

        };
    }

    public static LocationInfoMongo ToMongoDbObj(this LocationDto location,string id)
    {

        return new LocationInfoMongo
        {
            _id = ObjectId.Parse(id),
            nameCN = location.nameCN,
            namePT = location.nameEN,
            lat = location.lat,
            lng = location.lng

        };
    }

}