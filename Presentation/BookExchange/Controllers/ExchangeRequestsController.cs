using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.UseCases.Exchange;
using BookExchange.Models;

namespace BookExchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeRequestsController : Controller
    {
        private readonly IExchangeRequestService _exchangeRequestService;

        public ExchangeRequestsController(IExchangeRequestService exchangeRequestService)
        {
            _exchangeRequestService = exchangeRequestService;
        }

        // POST: api/exchange-requests
        [HttpPost]
        public async Task<IActionResult> CreateExchangeRequest([FromBody] CreateExchangeRequest exchangeRequest)
        {
            if (exchangeRequest == null)
            {
                return BadRequest();
            }

            var domainExchangeRequest = new ExchangeRequest
            {
                RequestTypeId = exchangeRequest.RequestTypeId,
                SenderBookId = exchangeRequest.SenderBookId,
                ReceiverBookId = exchangeRequest.ReceiverBookId,
                SenderUserId = exchangeRequest.SenderUserId,
                ReceiverUserId = exchangeRequest.ReceiverUserId,
                DeliveryMethodId = exchangeRequest.DeliveryMethodId,
                ExchangeDuration = exchangeRequest.ExchangeDuration,
                PaymentMethodId = exchangeRequest.PaymentMethodId,
                StatusId = exchangeRequest.StatusId
            };

            int requestId = await _exchangeRequestService.AddExchangeRequestAsync(domainExchangeRequest);
            domainExchangeRequest.RequestId = requestId;
            return CreatedAtAction(nameof(GetExchangeRequestById), new { requestId = requestId }, domainExchangeRequest);
        }

        // GET: api/exchange-requests/{requestId}
        [HttpGet("exchange-request/{requestId}")]
        public async Task<IActionResult> GetExchangeRequestById(int requestId)
        {
            var exchangeRequest = await _exchangeRequestService.GetExchangeRequestByIdAsync(requestId);
            if (exchangeRequest == null)
            {
                return NotFound();
            }

            return Ok(exchangeRequest);
        }

        // GET: api/exchange-requests
        [HttpGet("exchange-requests/{userId}")]
        public async Task<IActionResult> GetAllExchangeRequests(string userId)
        {
            var exchangeRequests = await _exchangeRequestService.GetExchangeRequestsByUserIdAsync(userId);
            return Ok(exchangeRequests);
        }

        // PUT: api/exchange-requests/{requestId}
        [HttpPut("{requestId}")]
        public async Task<IActionResult> UpdateExchangeRequest(int requestId, [FromBody] UpdateExchangeRequest exchangeRequest)
        {
            if (exchangeRequest == null || requestId < 1)
            {
                return BadRequest();
            }

            var existingRequest = await _exchangeRequestService.GetExchangeRequestByIdAsync(requestId);
            if (existingRequest == null)
            {
                return NotFound();
            }

            var domainExchangeRequest = new ExchangeRequest
            {
                RequestId = requestId,
                RequestTypeId = exchangeRequest.RequestTypeId,
                SenderBookId = exchangeRequest.SenderBookId,
                ReceiverBookId = exchangeRequest.ReceiverBookId,
                SenderUserId = exchangeRequest.SenderUserId,
                ReceiverUserId = exchangeRequest.ReceiverUserId,
                DeliveryMethodId = exchangeRequest.DeliveryMethodId,
                ExchangeDuration = exchangeRequest.ExchangeDuration,
                PaymentMethodId = exchangeRequest.PaymentMethodId,
                StatusId = exchangeRequest.StatusId
            };

            await _exchangeRequestService.UpdateExchangeRequestAsync(domainExchangeRequest);
            return NoContent();
        }
    }
}
