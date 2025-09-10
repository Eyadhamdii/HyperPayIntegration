using System.Threading.Tasks;

namespace HyperPayIntegration.Data;

public interface IHyperPayIntegrationDbSchemaMigrator
{
    Task MigrateAsync();
}
