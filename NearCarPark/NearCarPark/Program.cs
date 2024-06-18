using CarPark.Crawler;
using CarPark.DatabaseContext;
using CarPark.DbWorker;
using CarPark.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;


var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddTransient<CarApiCrawler>();
builder.Services.AddTransient<IDbWorker,CarParkMongoDbWorker>();
/*
var s = builder.Configuration.GetConnectionString("MSSQL");
builder.Services.AddDbContext<CarParkDbContext>(options => options.UseSqlServer(s));
*/
builder.Services.AddSingleton<IMongoClient,MongoClient>(sp => 
    new MongoClient(builder.Configuration.GetConnectionString("MongoDb")));


var host = builder.Build();
host.Run();
