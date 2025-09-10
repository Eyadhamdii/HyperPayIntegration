using HyperPayIntegration.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace HyperPayIntegration.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(HyperPayIntegrationEntityFrameworkCoreModule),
    typeof(HyperPayIntegrationApplicationContractsModule)
    )]
public class HyperPayIntegrationDbMigratorModule : AbpModule
{
}
