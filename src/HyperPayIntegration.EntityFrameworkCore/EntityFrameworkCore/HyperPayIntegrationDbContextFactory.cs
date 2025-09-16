using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HyperPayIntegration.EntityFrameworkCore;

public class HyperPayIntegrationDbContextFactory : IDesignTimeDbContextFactory<HyperPayIntegrationDbContext>
{
    public HyperPayIntegrationDbContext CreateDbContext(string[] args)
    {
        HyperPayIntegrationEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<HyperPayIntegrationDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new HyperPayIntegrationDbContext(builder.Options);


    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../HyperPayIntegration.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
