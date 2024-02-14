using JOIEnergy.Enums;
using System.Collections.Generic;

namespace JOIEnergy.Services.Interface
{
    public interface IPricePlanService
    {
        Dictionary<string, decimal> GetConsumptionCostOfElectricityReadingsForEachPricePlan(string smartMeterId);

        IList<Supplier> Suppliers();        
    }
}