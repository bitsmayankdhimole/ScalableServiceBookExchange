using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Entities.Exchange;

namespace BookExchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeRequestsController : Controller
    {
        private readonly IExchangeRequestRepository _exchangeRequestRepository;

        public ExchangeRequestsController(IExchangeRequestRepository exchangeRequestRepository)
        {
            _exchangeRequestRepository = exchangeRequestRepository;
        }

        // POST: api/exchange-requests
        [HttpPost]
        public async Task<IActionResult> CreateExchangeRequest([FromBody] ExchangeRequest exchangeRequest)
        {
            if (exchangeRequest == null)
            {
                return BadRequest();
            }

            await _exchangeRequestRepository.AddAsync(exchangeRequest);
            return CreatedAtAction(nameof(GetExchangeRequestById), new { requestId = exchangeRequest.RequestId }, exchangeRequest);
        }

        // GET: api/exchange-requests/{requestId}
        [HttpGet("{requestId}")]
        public async Task<IActionResult> GetExchangeRequestById(string requestId)
        {
            var exchangeRequest = await _exchangeRequestRepository.GetByIdAsync(requestId);
            if (exchangeRequest == null)
            {
                return NotFound();
            }

            return Ok(exchangeRequest);
        }

        // GET: api/exchange-requests
        [HttpGet]
        public async Task<IActionResult> GetAllExchangeRequests()
        {
            var exchangeRequests = await _exchangeRequestRepository.GetAllAsync();
            return Ok(exchangeRequests);
        }

        // PUT: api/exchange-requests/{requestId}
        [HttpPut("{requestId}")]
        public async Task<IActionResult> UpdateExchangeRequest(string requestId, [FromBody] ExchangeRequest exchangeRequest)
        {
            if (exchangeRequest == null || requestId != exchangeRequest.RequestId)
            {
                return BadRequest();
            }

            var existingRequest = await _exchangeRequestRepository.GetByIdAsync(requestId);
            if (existingRequest == null)
            {
                return NotFound();
            }

            await _exchangeRequestRepository.UpdateAsync(exchangeRequest);
            return NoContent();
        }
    }
}
