using CarPark.Crawler;
using CarPark.DbWorker;
using CarPark.DataModel;
using System.Net;
namespace CarPark.Services
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly CarApiCrawler _crawler;
        private readonly IDbWorker _dbworker;

        public Worker(ILogger<Worker> logger, CarApiCrawler aPICrawler, IDbWorker carParkDbWorker)
        {
            _crawler = aPICrawler;
            _dbworker = carParkDbWorker;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            System.Net.ServicePointManager.SecurityProtocol |=
    SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback +=
    (sender, cert, chain, sslPolicyErrors) => true;
            while (!stoppingToken.IsCancellationRequested)
            {


                List<CarParkInfoRealtimeDto>? cpData = await _crawler.GetCarParkRealTimeAsync();
                var result = await _dbworker.InsertToAnalystDbAsync(cpData);

                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker updating carParkDb at: {time} with return result {result}", DateTimeOffset.Now, result);
                }

                await Task.Delay(600000, stoppingToken);
            }
        }
    }
}
