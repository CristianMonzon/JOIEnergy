using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOIDao.Domain
{
    public class DPricePlan
    {
        public string EnergySupplier { get; set; }
        public decimal UnitRate { get; set; }
        public IList<DPeakTimeMultiplier> PeakTimeMultiplier { get; set; }
    }
}
