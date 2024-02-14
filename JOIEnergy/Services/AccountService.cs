using System;
using System.Collections.Generic;
using JOIEnergy.Enums;
using JOIEnergy.Services.Interface;

namespace JOIEnergy.Services
{
    public class AccountService : IAccountService
    { 
        private Dictionary<string, Supplier> _smartMeterToPricePlanAccounts;

        public AccountService(Dictionary<string, Supplier> smartMeterToPricePlanAccounts) {
            _smartMeterToPricePlanAccounts = smartMeterToPricePlanAccounts;
        }

        public Supplier GetPricePlanIdForSmartMeterId(string smartMeterId) {
            var response = Supplier.NullSupplier;
            _smartMeterToPricePlanAccounts.TryGetValue(smartMeterId, out response);
            return response;
        }
    }
}
