using JOIEnergy.DTO;
using System.Collections.Generic;

namespace JOIEnergy.Domain
{
    public static class MeterReadingExtends
    {
        public static MeterReading FromDto(this MeterReadingDTO meterReadingDTO)
        {
            MeterReading response = new MeterReading()
            {
                SmartMeterId = meterReadingDTO.SmartMeterId,
                ElectricityReadings = meterReadingDTO.ElectricityReadings
            };
            return response;
        }
    }
}