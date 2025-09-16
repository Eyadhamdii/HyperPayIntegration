using HyperPayIntegration.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace HyperPayIntegration.Web.Pages;

public abstract class HyperPayIntegrationPageModel : AbpPageModel
{
    protected HyperPayIntegrationPageModel()
    {
        LocalizationResourceType = typeof(HyperPayIntegrationResource);
    }
}
