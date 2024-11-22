namespace Domain.Entities.Exchange
{
    public interface IExchangeRequestRepository
    {
        Task<ExchangeRequest> GetByIdAsync(int requestId);
        Task<IEnumerable<ExchangeRequest>> GetAllAsync(string userId);
        Task<int> AddAsync(ExchangeRequest exchangeRequest);
        Task UpdateAsync(ExchangeRequest exchangeRequest);
    }
}
