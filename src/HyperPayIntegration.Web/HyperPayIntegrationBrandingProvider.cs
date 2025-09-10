using Microsoft.Extensions.Localization;
using HyperPayIntegration.Localization;
using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace HyperPayIntegration.Web;

[Dependency(ReplaceServices = true)]
public class HyperPayIntegrationBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<HyperPayIntegrationResource> _localizer;

    public HyperPayIntegrationBrandingProvider(IStringLocalizer<HyperPayIntegrationResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
