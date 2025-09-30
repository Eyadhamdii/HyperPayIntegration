using HyperPayIntegration.Payment;
using HyperPayIntegration.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace HyperPayIntegration.EntityFrameworkCore.Payment
{
    public class PaymentTransactionRepository
         : EfCoreRepository<HyperPayIntegrationDbContext, PaymentTransaction, Guid>, IPaymentTransactionRepository
    {
        public PaymentTransactionRepository(IDbContextProvider<HyperPayIntegrationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<PaymentTransaction?> FindByCheckoutIdAsync(string checkoutId)
        {
            var dbContext = await GetDbContextAsync();
            return await dbContext.PaymentTransactions
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(x => x.CheckoutId == checkoutId);
        }

    }
}
