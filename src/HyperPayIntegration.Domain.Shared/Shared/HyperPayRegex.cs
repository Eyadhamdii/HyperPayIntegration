using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperPayIntegration.Shared
{
    public static class HyperPayRegex
    {
        public const string Success1 = "^(000\\.000\\.|000\\.100\\.1|000\\.[36])";
        public const string Success2 = "^(000\\.400\\.0[^3]|000\\.400\\.[0-1]{2}0)";
        public const string Pending1 = "^(000\\.200)";
        public const string Pending2 = "^(800\\.400\\.5|100\\.400\\.500)";
    }
}
