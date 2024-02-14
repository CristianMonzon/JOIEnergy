using System;
using System.Linq;
using System.Collections.Generic;
using JOIEnergy.Domain;
using JOIEnergy.Services.Interface;

namespace JOIEnergy.Services
{
    public class MeterReadingService : IMeterReadingService
    {
        public Dictionary<string, IList<ElectricityReading>> MeterAssociatedReadings { get; set; }
        public MeterReadingService(Dictionary<string, IList<ElectricityReading>> meterAssociatedReadings)
        {
            MeterAssociatedReadings = meterAssociatedReadings;
        }

        public IList<ElectricityReading> GetReadings(string smartMeterId) {
            if (MeterAssociatedReadings.ContainsKey(smartMeterId)) {
                return MeterAssociatedReadings[smartMeterId];
            }
            return new List<ElectricityReading>();
        }

        public Dictionary<string, IList<ElectricityReading>> GetReadings()
        {
            return MeterAssociatedReadings;            
        }

        public void StoreReadings(string smartMeterId, IList<ElectricityReading> electricityReadings) {
            if (!MeterAssociatedReadings.ContainsKey(smartMeterId)) {
                MeterAssociatedReadings.Add(smartMeterId, new List<ElectricityReading>());
            }

            electricityReadings.ToList().ForEach(electricityReading => MeterAssociatedReadings[smartMeterId].Add(electricityReading));
        }
    }
}
