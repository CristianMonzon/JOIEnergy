using JOIEnergy.Enums;
using JOIEnergy.Generator;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JOIEnergy.Controllers
{
    public class ProviderController : Controller
    {

        [HttpGet("Providers")]
        public ObjectResult GetAll() {

            Supplier[] supliers = (Supplier[])Enum.GetValues(typeof(Supplier));
            return new ObjectResult(supliers.ToDto());
        }
    }
}
