using HyperPayIntegration.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HyperPayIntegration.Payment
{
    public class PaymentTransaction : FullAuditedAggregateRoot<Guid>
    {
        public string CheckoutId { get; set; }
        public string EntityId { get; set; }   
        public string MerchantTransactionId { get; set; } 
        public HyperPayMethod Method { get; set; }       
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public PaymentStatus Status { get; set; }        
        public string ResultCode { get; set; }           
        public string ResultDescription { get; set; }   
        public DateTime TransactionDate { get; set; }
        public string Ndc { get; set; }
        public string BuildNumber { get; set; }
        public string PaymentBrand { get; set; }           
        public string Descriptor { get; set; }             
        public string CustomerIp { get; set; }
        public string CardBin { get; set; }               
        public string CardLast4 { get; set; }
        public string CardExpiryMonth { get; set; }
        public string CardExpiryYear { get; set; }
    }
}
