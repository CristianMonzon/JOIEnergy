using System.Collections.Generic;

namespace JOIEnergy.Domain
{
    public class MeterReading
    {
        public string SmartMeterId { get; set; }
        public List<ElectricityReading> ElectricityReadings { get; set; }
    }
}
