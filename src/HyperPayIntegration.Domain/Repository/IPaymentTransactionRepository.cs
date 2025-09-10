using HyperPayIntegration.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace HyperPayIntegration.Repository
{
    public interface IPaymentTransactionRepository : IRepository<PaymentTransaction, Guid>
    {
        Task<PaymentTransaction> FindByCheckoutIdAsync(string checkoutId);
    }
}
