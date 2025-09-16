using Microsoft.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace HyperPayIntegration.EntityFrameworkCore;

public static class HyperPayIntegrationEfCoreEntityExtensionMappings
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        HyperPayIntegrationGlobalFeatureConfigurator.Configure();
        HyperPayIntegrationModuleExtensionConfigurator.Configure();

        OneTimeRunner.Run(() =>
        {
                
        });
    }
}
