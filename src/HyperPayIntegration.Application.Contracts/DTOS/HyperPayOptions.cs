using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperPayIntegration.DTOS
{
    public class HyperPayOptions
    {
        public string BaseUrl { get; set; }
        public string EntityId { get; set; }
        public string AccessToken { get; set; }
        public bool UseTestMode { get; set; }
        public bool EnableDatabasePersistence { get; set; }

    }
}
