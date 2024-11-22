using LookupEntity = Application.Domain.Entities.Lookup;

namespace Application.UseCases.Lookup
{
    public interface ILookupService
    {
        Task<IEnumerable<LookupEntity.Lookup>> GetDeliveryMethodsAsync();
        Task<IEnumerable<LookupEntity.Lookup>> GetPaymentMethodsAsync();
        Task<IEnumerable<LookupEntity.Lookup>> GetStatusesAsync();
        Task<IEnumerable<LookupEntity.Lookup>> GetRequestTypesAsync();
    }
}
