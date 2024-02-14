using JOIEnergy.Domain;
using System.Collections.Generic;

namespace JOIEnergy.Services.Interface
{
    public interface IMeterReadingService
    {
        IList<ElectricityReading> GetReadings(string smartMeterId);

        Dictionary<string, IList<ElectricityReading>> GetReadings();
        
        void StoreReadings(string smartMeterId, IList<ElectricityReading> electricityReadings);
    }
}