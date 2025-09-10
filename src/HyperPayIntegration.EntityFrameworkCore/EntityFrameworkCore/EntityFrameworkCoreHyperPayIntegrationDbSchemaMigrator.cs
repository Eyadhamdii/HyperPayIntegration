using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HyperPayIntegration.Data;
using Volo.Abp.DependencyInjection;

namespace HyperPayIntegration.EntityFrameworkCore;

public class EntityFrameworkCoreHyperPayIntegrationDbSchemaMigrator
    : IHyperPayIntegrationDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreHyperPayIntegrationDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the HyperPayIntegrationDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<HyperPayIntegrationDbContext>()
            .Database
            .MigrateAsync();
    }
}
