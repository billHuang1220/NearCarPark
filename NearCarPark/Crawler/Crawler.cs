using CarPark.DataModel;
using Flurl.Http;
using System.Xml.Serialization;
namespace CarPark.Crawler;

public class CarApiCrawler
{
    private const string RealTimeApiUrl = "https://dsat.apigateway.data.gov.mo/car_park_maintance";
    private const string Auth = "APPCODE 09d43a591fba407fb862412970667de4";
    private const string DetailApiUrl = "https://dsat.apigateway.data.gov.mo/car_park_detail";

    public async Task<List<CarParkInfoRealtimeDto>> GetCarParkRealTimeAsync()
    {

        var response = await RealTimeApiUrl
            .AllowAnyHttpStatus()
            .WithHeader(name: "Authorization", Auth)
            .GetAsync();

        if(response.StatusCode != 200)
            throw new Exception($"Can not get data from api with statues: {response.StatusCode}");


        XmlSerializer serializer = new XmlSerializer(typeof(CarParkRealTimeList));
        CarParkRealTimeList carPark;

        var xmlString = await response.GetStringAsync();

        using (StringReader reader = new StringReader(xmlString))
        {
            carPark = (CarParkRealTimeList)serializer.Deserialize(reader);
        }


        return carPark.CarParkInfos;
    }

    public async Task<List<CarParkDetailDto>> GetCarParkDetailAsync()
    {
        var response = await DetailApiUrl
            .AllowAnyHttpStatus()
            .WithHeader(name: "Authorization", Auth)
            .GetAsync();

        if (response.StatusCode != 200)
            throw new Exception($"Can not get data from api with statues: {response.StatusCode}");

        XmlSerializer serializer = new XmlSerializer(typeof(CarParkDetailList));
        CarParkDetailList? carPark;

        using (StringReader reader = new StringReader(await response.GetStringAsync()))
        {
            carPark = serializer.Deserialize(reader) as CarParkDetailList;
        }


        return carPark.CarParkInfos;
    }

}
