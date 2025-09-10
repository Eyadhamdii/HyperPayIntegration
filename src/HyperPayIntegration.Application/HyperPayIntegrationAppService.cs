using System;
using System.Collections.Generic;
using System.Text;
using HyperPayIntegration.Localization;
using Volo.Abp.Application.Services;

namespace HyperPayIntegration;

/* Inherit your application services from this class.
 */
public abstract class HyperPayIntegrationAppService : ApplicationService
{
    protected HyperPayIntegrationAppService()
    {
        LocalizationResource = typeof(HyperPayIntegrationResource);
    }
}
