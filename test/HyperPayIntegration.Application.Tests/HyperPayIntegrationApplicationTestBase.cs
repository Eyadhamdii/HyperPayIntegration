using Volo.Abp.Modularity;

namespace HyperPayIntegration;

public abstract class HyperPayIntegrationApplicationTestBase<TStartupModule> : HyperPayIntegrationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
