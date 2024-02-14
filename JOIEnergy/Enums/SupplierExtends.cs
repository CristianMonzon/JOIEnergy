using JOIEnergy.DTO;
using System.Collections.Generic;
using System.Linq;

namespace JOIEnergy.Enums
{
    public static class SupplierExtends
    {
        public static IList<ProviderDTO> ToDto(this Supplier[] supplier)
        {
            return supplier.Select(c => new ProviderDTO() { Company = c.ToString() }).ToList();
        }
    }
}
