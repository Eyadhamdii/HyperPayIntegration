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

        await _serviceProvider
            .GetRequiredService<HyperPayIntegrationDbContext>()
            .Database
            .MigrateAsync();
    }
}
