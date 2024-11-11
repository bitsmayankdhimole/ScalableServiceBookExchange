namespace Domain.Entities.Exchange
{
    public interface IExchangeRequestRepository
    {
        Task<ExchangeRequest> GetByIdAsync(string requestId);
        Task<IEnumerable<ExchangeRequest>> GetAllAsync();
        Task AddAsync(ExchangeRequest exchangeRequest);
        Task UpdateAsync(ExchangeRequest exchangeRequest);
    }
}
