using CarPark.Crawler;
using CarPark.DbWorker;
using CarPark.DataModel;
namespace CarPark.Services
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly APICrawler _crawler;
        private readonly CarParkDbWorker _dbworker;

        public Worker(ILogger<Worker> logger)
        {
            _crawler = new APICrawler();
            _dbworker = new CarParkDbWorker();
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
               
                List<CarParkInfoRealtimeDto>? cpData = await _crawler.GetCarParkRealTimeAsync();
                var result = await _dbworker.UpdateToDbAsync(cpData);

                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker updataing carParkDb at: {time} with return result {result}", DateTimeOffset.Now, result);
                }
                await Task.Delay(600000, stoppingToken);
            }
        }
    }
}
