using JOIEnergy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JOIEnergy.Generator
{
    public class ElectricityReadingGenerator
    {
        public static Dictionary<string, List<ElectricityReading>> ElectricityReading()
        {
            var readings = new Dictionary<string, List<ElectricityReading>>();         
            var smartMeterIds = SuppliersGenerator.Suppliers.Select(mtpp => mtpp.Key);

            foreach (var smartMeterId in smartMeterIds)
            {
                readings.Add(smartMeterId, Generate(20));
            }
            return readings;
        }

        private static List<ElectricityReading> Generate(int number)
        {
            var readings = new List<ElectricityReading>();
            var random = new Random();
            for (int i = 0; i < number; i++)
            {
                var reading = (decimal)random.NextDouble();
                var electricityReading = new ElectricityReading
                {
                    Reading = reading,
                    Time = DateTime.Now.AddSeconds(-i * 10)
                };
                readings.Add(electricityReading);
            }
            readings.Sort((reading1, reading2) => reading1.Time.CompareTo(reading2.Time));
            return readings;
        }


    }
}
