using JOIEnergy.Generator;
using JOIEnergy.Services.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JOIEnergy.Controllers
{
    public class PricePlanController : Controller
    {
        private readonly IPricePlanService _pricePlanService;

        public PricePlanController(IPricePlanService pricePlanService)
        {
            _pricePlanService = pricePlanService;
        }

        [HttpGet("PricePlans")]
        public ObjectResult GetAll() {
            return new ObjectResult(PricePlanGenerator.PricePlans());
        }

        [HttpGet("PricePlans/suppliers")]
        public ObjectResult GetSuppliers()
        {
            return new ObjectResult(_pricePlanService.Suppliers());
        }
    }
}
