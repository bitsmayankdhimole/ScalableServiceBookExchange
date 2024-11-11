
using Domain.Enums;

namespace Domain.Entities
{
    public class ExchangeRequest
    {
        public string RequestId { get; set; }
        public string RequestType { get; set; }
        public string SenderBookId { get; set; }
        public string ReceiverBookId { get; set; }
        public string SenderUserId { get; set; }
        public string ReceiverUserId { get; set; }
        public int DeliveryMethodId { get; set; }
        public int ExchangeDuration { get; set; }
        public int PaymentMethodId { get; set; }
        public int StatusId { get; set; }

        public DeliveryMethod DeliveryMethod { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Status Status { get; set; }
    }

}
