using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace HyperPayIntegration.Data;

/* This is used if database provider does't define
 * IHyperPayIntegrationDbSchemaMigrator implementation.
 */
public class NullHyperPayIntegrationDbSchemaMigrator : IHyperPayIntegrationDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
