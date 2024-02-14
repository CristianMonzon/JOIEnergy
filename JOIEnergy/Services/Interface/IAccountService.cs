using JOIEnergy.Enums;

namespace JOIEnergy.Services.Interface
{
    public interface IAccountService
    {
        Supplier GetPricePlanIdForSmartMeterId(string smartMeterId);
    }
}