using LookupEntity = Application.Domain.Entities.Lookup;

namespace Application.UseCases.Lookup
{
    public class LookupService : ILookupService
    {
        private readonly LookupEntity.ILookupRepository _lookupRepository;

        public LookupService(LookupEntity.ILookupRepository lookupRepository)
        {
            _lookupRepository = lookupRepository;
        }

        public async Task<IEnumerable<LookupEntity.Lookup>> GetDeliveryMethodsAsync()
        {
            return await _lookupRepository.GetDeliveryMethodsAsync();
        }

        public async Task<IEnumerable<LookupEntity.Lookup>> GetPaymentMethodsAsync()
        {
            return await _lookupRepository.GetPaymentMethodsAsync();
        }

        public async Task<IEnumerable<LookupEntity.Lookup>> GetStatusesAsync()
        {
            return await _lookupRepository.GetStatusesAsync();
        }
    }
}
