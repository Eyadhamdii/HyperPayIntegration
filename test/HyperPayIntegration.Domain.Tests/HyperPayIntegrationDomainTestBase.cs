using Volo.Abp.Modularity;

namespace HyperPayIntegration;

/* Inherit from this class for your domain layer tests. */
public abstract class HyperPayIntegrationDomainTestBase<TStartupModule> : HyperPayIntegrationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
