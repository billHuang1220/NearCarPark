using System.Xml.Serialization;
using Flurl.Http;
using CarPark.DataModel;
namespace CarPark.Crawler
{

    public class APICrawler
    {
        private const string realTimeAPIUrl = "https://dsat.apigateway.data.gov.mo/car_park_maintance";
        private const string auth = "APPCODE 09d43a591fba407fb862412970667de4";
        private const string detailAPIUrl = "https://dsat.apigateway.data.gov.mo/car_park_detail";

        public async Task<List<CarParkInfoRealtimeDto>> GetCarParkRealTimeAsync()
        {
            var xmlString = await realTimeAPIUrl
                .WithHeader(name: "Authorization", auth)
                .GetStringAsync();

            XmlSerializer serializer = new XmlSerializer(typeof(CarParkRealTimeList));
            CarParkRealTimeList carPark;

            using (StringReader reader = new StringReader(xmlString))
            {
                carPark = (CarParkRealTimeList)serializer.Deserialize(reader);
            }


            return carPark.CarParkInfos;
        }

        public async Task<List<CarParkDetailDto>> GetCarParkDetailAsync()
        {
            var xmlString = await detailAPIUrl
                .WithHeader(name: "Authorization", auth)
                .GetStringAsync();

            XmlSerializer serializer = new XmlSerializer(typeof(CarParkDetailList));
            CarParkDetailList carPark;

            using (StringReader reader = new StringReader(xmlString))
            {
                carPark = (CarParkDetailList)serializer.Deserialize(reader);
            }


            return carPark.CarParkInfos;
        }

    }
}