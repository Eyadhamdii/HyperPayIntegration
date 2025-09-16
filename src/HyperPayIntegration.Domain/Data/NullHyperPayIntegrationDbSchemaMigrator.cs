using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace HyperPayIntegration.Data;

public class NullHyperPayIntegrationDbSchemaMigrator : IHyperPayIntegrationDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
