using Microsoft.AspNetCore.Mvc;
using Application.UseCases.Lookup;

namespace BookExchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LookupController : Controller
    {
        private readonly ILookupService _lookupService;

        public LookupController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        // GET: api/lookup/delivery-methods
        [HttpGet("delivery-methods")]
        public async Task<IActionResult> GetDeliveryMethods()
        {
            var deliveryMethods = await _lookupService.GetDeliveryMethodsAsync();
            return Ok(deliveryMethods);
        }

        // GET: api/lookup/payment-methods
        [HttpGet("payment-methods")]
        public async Task<IActionResult> GetPaymentMethods()
        {
            var paymentMethods = await _lookupService.GetPaymentMethodsAsync();
            return Ok(paymentMethods);
        }

        // GET: api/lookup/statuses
        [HttpGet("statuses")]
        public async Task<IActionResult> GetStatuses()
        {
            var statuses = await _lookupService.GetStatusesAsync();
            return Ok(statuses);
        }

        // GET: api/lookup/request-types
        [HttpGet("request-types")]
        public async Task<IActionResult> GetRequestTypes()
        {
            var requestTypes = await _lookupService.GetRequestTypesAsync();
            return Ok(requestTypes);
        }
    }
}
