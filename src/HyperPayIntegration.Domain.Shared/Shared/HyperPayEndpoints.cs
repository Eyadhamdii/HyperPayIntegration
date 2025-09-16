using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperPayIntegration.Shared
{
    public static class HyperPayEndpoints
    {
        public const string Checkouts = "checkouts";
        public const string CheckoutPayment = "checkouts/{0}/payment?entityId={1}";
    }
}
