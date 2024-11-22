using Domain.Entities.Exchange;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.UseCases.Exchange
{
    public class ExchangeRequestService : IExchangeRequestService
    {
        private readonly IExchangeRequestRepository _exchangeRequestRepository;

        public ExchangeRequestService(IExchangeRequestRepository exchangeRequestRepository)
        {
            _exchangeRequestRepository = exchangeRequestRepository;
        }

        public async Task<ExchangeRequest> GetExchangeRequestByIdAsync(int requestId)
        {
            return await _exchangeRequestRepository.GetByIdAsync(requestId);
        }

        public async Task<IEnumerable<ExchangeRequest>> GetExchangeRequestsByUserIdAsync(string userId)
        {
            return await _exchangeRequestRepository.GetAllAsync(userId);
        }

        public async Task<int> AddExchangeRequestAsync(ExchangeRequest exchangeRequest)
        {
           return  await _exchangeRequestRepository.AddAsync(exchangeRequest);
        }

        public async Task UpdateExchangeRequestAsync(ExchangeRequest exchangeRequest)
        {
            await _exchangeRequestRepository.UpdateAsync(exchangeRequest);
        }
    }
}
