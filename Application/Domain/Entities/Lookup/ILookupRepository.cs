namespace Application.Domain.Entities.Lookup
{
    public interface ILookupRepository
    {
        Task<IEnumerable<Lookup>> GetDeliveryMethodsAsync();
        Task<IEnumerable<Lookup>> GetPaymentMethodsAsync();
        Task<IEnumerable<Lookup>> GetStatusesAsync();
        Task<IEnumerable<Lookup>> GetRequestTypesAsync();
    }
}
