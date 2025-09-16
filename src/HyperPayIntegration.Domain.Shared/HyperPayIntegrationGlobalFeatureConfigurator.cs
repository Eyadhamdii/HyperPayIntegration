using Volo.Abp.Threading;

namespace HyperPayIntegration;

public static class HyperPayIntegrationGlobalFeatureConfigurator
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        OneTimeRunner.Run(() =>
        {
        });
    }
}
