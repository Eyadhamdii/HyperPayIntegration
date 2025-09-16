using System;
using System.Collections.Generic;
using System.Text;
using HyperPayIntegration.Localization;
using Volo.Abp.Application.Services;

namespace HyperPayIntegration;

public abstract class HyperPayIntegrationAppService : ApplicationService
{
    protected HyperPayIntegrationAppService()
    {
        LocalizationResource = typeof(HyperPayIntegrationResource);
    }
}
