using Domain.Entities;

namespace Application.UseCases.Exchange
{
    public interface IExchangeRequestService
    {
        Task<ExchangeRequest> GetExchangeRequestByIdAsync(int requestId);
        Task<IEnumerable<ExchangeRequest>> GetExchangeRequestsByUserIdAsync(string userId);
        Task<int> AddExchangeRequestAsync(ExchangeRequest exchangeRequest);
        Task UpdateExchangeRequestAsync(ExchangeRequest exchangeRequest);
    }
}
