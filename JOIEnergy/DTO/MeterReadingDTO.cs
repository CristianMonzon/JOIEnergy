using JOIEnergy.Domain;
using System;
using System.Collections.Generic;

namespace JOIEnergy.DTO
{
    public class MeterReadingDTO
    {
        public string SmartMeterId { get; set; }
        public List<ElectricityReading> ElectricityReadings { get; set; }
    }
}
