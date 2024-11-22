using System.Data;
using Application.Domain.Entities.Lookup;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Repository
{
    public class LookupRepository : ILookupRepository
    {
        private readonly string _connectionString;

        public LookupRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Lookup>> GetDeliveryMethodsAsync()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<Lookup>(
                    "GetDeliveryMethods",
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Lookup>> GetPaymentMethodsAsync()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<Lookup>(
                    "GetPaymentMethods",
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Lookup>> GetStatusesAsync()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<Lookup>(
                    "GetStatuses",
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Lookup>> GetRequestTypesAsync()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<Lookup>(
                    "GetRequestTypes",
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
