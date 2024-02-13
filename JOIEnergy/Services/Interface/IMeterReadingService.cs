﻿using JOIEnergy.Domain;
using System.Collections.Generic;

namespace JOIEnergy.Services.Interface
{
    public interface IMeterReadingService
    {
        List<ElectricityReading> GetReadings(string smartMeterId);
        void StoreReadings(string smartMeterId, List<ElectricityReading> electricityReadings);
    }
}