using HyperPayIntegration.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace HyperPayIntegration.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class HyperPayIntegrationController : AbpControllerBase
{
    protected HyperPayIntegrationController()
    {
        LocalizationResource = typeof(HyperPayIntegrationResource);
    }
}
