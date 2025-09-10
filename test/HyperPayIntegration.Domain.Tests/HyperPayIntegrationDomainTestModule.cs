using Volo.Abp.Modularity;

namespace HyperPayIntegration;

[DependsOn(
    typeof(HyperPayIntegrationDomainModule),
    typeof(HyperPayIntegrationTestBaseModule)
)]
public class HyperPayIntegrationDomainTestModule : AbpModule
{

}
