using JOIEnergy.DTO;
using System;
using System.Runtime.CompilerServices;

namespace JOIEnergy.Domain
{

    public static class ElectricityReadingExtends
    {
        public static ElectricityReadingDTO ToDto(this ElectricityReading electricityReading)
        {
            var response = new ElectricityReadingDTO();
            if (electricityReading != null)
            {
                response.Reading= electricityReading.Reading;
                response.Time = electricityReading.Time;
            }

            return response;
        }
    }
}
