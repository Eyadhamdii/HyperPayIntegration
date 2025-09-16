using HyperPayIntegration.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace HyperPayIntegration.Controllers;

public abstract class HyperPayIntegrationController : AbpControllerBase
{
    protected HyperPayIntegrationController()
    {
        LocalizationResource = typeof(HyperPayIntegrationResource);
    }
}
