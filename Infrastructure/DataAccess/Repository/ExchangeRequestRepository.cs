using Dapper;
using Domain.Entities;
using Domain.Entities.Exchange;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DataAccess.Repository
{
    public class ExchangeRequestRepository : IExchangeRequestRepository
    {
        private readonly string _connectionString;

        public ExchangeRequestRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<ExchangeRequest> GetByIdAsync(int requestId)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryFirstOrDefaultAsync<ExchangeRequest>(
                    "GetExchangeRequestById",
                    new { RequestId = requestId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<ExchangeRequest>> GetAllAsync(int userId)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<ExchangeRequest>(
                    "GetAllExchangeRequestsByUserId",
                    new { UserId = userId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> AddAsync(ExchangeRequest exchangeRequest)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var requestId = await db.QuerySingleAsync<int>(
                    "AddExchangeRequest",
                    new
                    {
                        exchangeRequest.RequestTypeId,
                        exchangeRequest.SenderBookId,
                        exchangeRequest.ReceiverBookId,
                        exchangeRequest.SenderUserId,
                        exchangeRequest.ReceiverUserId,
                        exchangeRequest.DeliveryMethodId,
                        exchangeRequest.ExchangeDuration,
                        exchangeRequest.PaymentMethodId,
                        exchangeRequest.StatusId
                    },
                    commandType: CommandType.StoredProcedure);

                return requestId;
            }
        }


        public async Task UpdateAsync(ExchangeRequest exchangeRequest)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.ExecuteAsync(
                    "UpdateExchangeRequest",
                    new
                    {
                        exchangeRequest.RequestId,
                        exchangeRequest.RequestTypeId,
                        exchangeRequest.SenderBookId,
                        exchangeRequest.ReceiverBookId,
                        exchangeRequest.SenderUserId,
                        exchangeRequest.ReceiverUserId,
                        exchangeRequest.DeliveryMethodId,
                        exchangeRequest.ExchangeDuration,
                        exchangeRequest.PaymentMethodId,
                        exchangeRequest.StatusId
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
