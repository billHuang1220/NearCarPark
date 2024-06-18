using CarPark.Crawler;
using CarPark.DatabaseContext;
using CarPark.DbWorker;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var s = builder.Configuration.GetSection("MSSQL:ConnectionStrings").Value;
builder.Services.AddDbContext<CarParkDbContext>(options => options.UseSqlServer(s));
builder.Services.AddTransient<CarApiCrawler>();

// builder.Services.AddTransient<IDbWorker, CarParkDbWorker>();
builder.Services.AddTransient<IDbWorker, CarParkMongoDbWorker>();
/*
var s = builder.Configuration.GetConnectionString("MSSQL");
builder.Services.AddDbContext<CarParkDbContext>(options => options.UseSqlServer(s));
*/
builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
    new MongoClient(builder.Configuration.GetConnectionString("MongoDb")));

var app = builder.Build();

builder.Services.AddCors();

app.UseCors(builder =>
{
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
