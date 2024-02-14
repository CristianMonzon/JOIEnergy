using JOIEnergy.Domain;
using JOIEnergy.DTO;
using JOIEnergy.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JOIEnergy.Controllers
{
    [Route("readings")]
    public class MeterReadingController : Controller
    {
        private readonly IMeterReadingService _meterReadingService;

        public MeterReadingController(IMeterReadingService meterReadingService)
        {
            _meterReadingService = meterReadingService;
        }
        
        [HttpPost ("store")]
        public ObjectResult Post([FromBody]MeterReadingDTO meterReadingDto)
        {
            var meterReadings = meterReadingDto.FromDto();

            if (!IsMeterReadingsValid(meterReadings)) {
                return new BadRequestObjectResult("Internal Server Error");
            }
            _meterReadingService.StoreReadings(meterReadings.SmartMeterId,meterReadings.ElectricityReadings);
            return new OkObjectResult("{}");
        }

        [HttpGet("read")]
        public ObjectResult GetAll()
        {
            var readings = _meterReadingService.GetReadings();
            var readingsDTO = readings.ToDictionary(c => c.Key, c => c.Value.Select(c => c.ToDto()));
            return new OkObjectResult(readingsDTO);
        }

        [HttpGet("read/{smartMeterId}")]
        public ObjectResult GetReading(string smartMeterId)
        {
            var readings = _meterReadingService.GetReadings(smartMeterId);
            var readingsDTO = readings.Select(c => c.ToDto());
            return new OkObjectResult(readings);
        }

        private bool IsMeterReadingsValid(MeterReading meterReadings)
        {
            String smartMeterId = meterReadings.SmartMeterId;
            var electricityReadings = meterReadings.ElectricityReadings;            
            return smartMeterId != null 
                && smartMeterId.Any()
                && electricityReadings != null 
                && electricityReadings.Any();
        }
    }
}
