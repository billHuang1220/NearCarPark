using CarPark.DatabaseContext;
using CarPark.DataModel;

namespace CarPark.DbWorker
{
    public class CarParkDbWorker
    {
        public async Task<bool> UpdateToDbAsync(List<CarParkInfoRealtimeDto> carParks)
        {
            using var context = new CarParkDbContext();
            context.CarParkInfoRealTimes
                .UpdateRange(carParks.Select(x=>x.ToDbObj()));
            var result = await context.SaveChangesAsync();
            return result == carParks.Count;
        }

        public async Task<bool> SaveToDbAsync(List<CarParkInfoRealtimeDto> carParks)
        {
            using var context = new CarParkDbContext();
            await context.CarParkInfoRealTimes.AddRangeAsync(carParks.Select(x => x.ToDbObj()));
            var result = await context.SaveChangesAsync();
            return result == carParks.Count;
        }
        public async Task<bool> SaveToDbAsync(List<CarParkDetailDto> carParks)
        {
            using var context = new CarParkDbContext();
            await context.CarParkInfoDetails.AddRangeAsync(carParks.Select(x => x.ToDbObj()));
            var result = await context.SaveChangesAsync();
            return result == carParks.Count;
        }
    }
}
