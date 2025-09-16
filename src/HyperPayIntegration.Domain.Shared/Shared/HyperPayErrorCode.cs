using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperPayIntegration.Shared
{
    public enum HyperPayErrorCode
    {
        None = 0,
        InvalidMethod,
        InvalidRequest,
        CheckoutFailed,
        StatusFailed,
        Unauthorized,
        Forbidden,
        Unknown
    }
}
