using Volo.Abp.Modularity;

namespace HyperPayIntegration;

[DependsOn(
    typeof(HyperPayIntegrationApplicationModule),
    typeof(HyperPayIntegrationDomainTestModule)
)]
public class HyperPayIntegrationApplicationTestModule : AbpModule
{

}
