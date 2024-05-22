using CarPark.Crawler;
using CarPark.DataModel;
using CarPark.DbWorker;
using CarPark.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

/*APICrawler crawler = new APICrawler();
List<CarParkInfoRealtimeDto>? cpData = await crawler.GetCarParkRealTimeAsync();
CarParkDbWorker worker = new CarParkDbWorker();
var result = await worker.UpdateToDbAsync(cpData);

*/


var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();

