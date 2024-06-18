using Microsoft.AspNetCore.Mvc;
using CarPark.DatabaseContext;
using CarPark.DbWorker;
using Microsoft.EntityFrameworkCore;
using CarPark.DataModel;
using MongoDB.Bson;

namespace CarParkWebAPI.Controllers
{
    public class CarParkWebController(ILogger<CarParkWebController> _logger,IDbWorker _dbWorker) : Controller
    {

        [HttpGet("GetCarParkList")]
        public async Task<IActionResult> GetAnalyst()
        {
            try
            {
                var result = await _dbWorker.GetAnalystAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Ok(e.Message);
            }
        }

        [HttpGet( "GetCarSlotAnalyst")]
        public async Task<IActionResult> GetCarSlotAnalyst(string date,string cpID)
        {

            try
            {
                var result = await _dbWorker.GetCarSlotAnalystAsync(date, cpID);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e,e.Message);
                return Ok(e.Message);
            }
  
        }

        [HttpGet("GetMbSlotAnalyst")]
        public async Task<IActionResult> GetMbSlotAnalyst(string date, string cpID)
        {

            try
            {
                var result = await _dbWorker.GetMbSlotAnalystAsync(date, cpID);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return Ok(e.Message);
            }
        }

        [HttpGet("GetCarNearestCarPark")]
        public async Task<IActionResult> GetCarNearestCarPark(float lat, float lng)
        {
            try
            {
                var carParks = await _dbWorker.GetCarNearestCarParkAsync(lat, lng);

                return Ok(carParks);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return Ok(e.Message);
            }
         
        }

        [HttpGet("GetMbNearestCarPark")]
        public async Task<IActionResult> GetMbNearestCarPark(float lat, float lng)
        {
            try
            {
                var carParks = await _dbWorker.GetMbNearestCarParkAsync(lat, lng);

                return Ok(carParks);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return Ok(e.Message);
            }
        }

        [HttpGet("GetAvailableDate")]
        public async Task<IActionResult> GetAvailableDate()
        {
            try
            {
                var date = await _dbWorker.AvailableAnalystsDateAsync();

                return Ok(date);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return Ok(e.Message);
            }
        }


        [HttpPost("InsertLocation")]
        public async Task<IActionResult> InsertLocation([FromBody] List<LocationDto> locations)
        {
            try
            {
                var result = await _dbWorker.InsertToLocationAsync(locations);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Ok(e.Message);
            }
            
        }

        [HttpGet("AutoComplete")]
        public async Task<IActionResult> GetAutoCompleteList(string prefix)
        {
            try
            {
                var list = await _dbWorker.FindAutoFillListAsync(prefix);

                return Ok(list);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return Ok(e.Message);
            }
        }


        [HttpPut("DeleteLocation")]
        public async Task<IActionResult> DeleteLocation(String id)
        {
            try
            {
                var result = await _dbWorker.DeleteLocationAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return Ok(e.Message);
            }
        }

        [HttpPut("UpdateLocation")]
        public async Task<IActionResult> UpdateLocation(LocationDto location,string id)
        {
            try
            {
                var result = await _dbWorker.UpdateLocationAsync(location,id);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return Ok(e.Message);
            }
        }
    }
}
