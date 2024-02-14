using JOIEnergy.Domain;
using JOIEnergy.Enums;
using System;
using System.Collections.Generic;

namespace JOIEnergy.Generator
{
    public class SuppliersGenerator
    {
        public static Dictionary<String, Supplier> Suppliers
        {
            get
            {
                Dictionary<String, Supplier> smartMeterToPricePlanAccounts = new Dictionary<string, Supplier>();
                smartMeterToPricePlanAccounts.Add("smart-meter-0", Supplier.DrEvilsDarkEnergy);
                smartMeterToPricePlanAccounts.Add("smart-meter-1", Supplier.TheGreenEco);
                smartMeterToPricePlanAccounts.Add("smart-meter-2", Supplier.DrEvilsDarkEnergy);
                smartMeterToPricePlanAccounts.Add("smart-meter-3", Supplier.PowerForEveryone);
                smartMeterToPricePlanAccounts.Add("smart-meter-4", Supplier.TheGreenEco);
                return smartMeterToPricePlanAccounts;
            }
        }

        private static Supplier GetBySupplier(Supplier suplier)
        {
            Supplier supplier = Supplier.NullSupplier;
            Suppliers.TryGetValue(suplier.ToString(), out supplier);
            return supplier;
        }

    }
}
