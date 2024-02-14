using JOIEnergy.Domain;
using JOIEnergy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JOIEnergy.Generator
{
    public class PricePlanGenerator
    {
        //TODO Encapsulate structure in class. For example : Dictionnary
        public static IList<PricePlan> PricePlans()
        {
            return new List<PricePlan> {
                new PricePlan{
                    EnergySupplier = Enums.Supplier.DrEvilsDarkEnergy,
                    UnitRate = 10m,
                    PeakTimeMultiplier = new List<PeakTimeMultiplier>()
                },
                new PricePlan{
                    EnergySupplier = Enums.Supplier.TheGreenEco,
                    UnitRate = 2m,
                    PeakTimeMultiplier = new List<PeakTimeMultiplier>()
                },
                new PricePlan{
                    EnergySupplier = Enums.Supplier.PowerForEveryone,
                    UnitRate = 1m,
                    PeakTimeMultiplier = new List<PeakTimeMultiplier>()
                }
            };
        }

    }
}
