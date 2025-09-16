using HyperPayIntegration.DTOS;
using HyperPayIntegration.Payment;
using HyperPayIntegration.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace HyperPayIntegration;

[DependsOn(
    typeof(HyperPayIntegrationDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(HyperPayIntegrationApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class HyperPayIntegrationApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var config = context.Services.GetConfiguration();

        context.Services.Configure<HyperPayOptions>(config.GetSection("Payment:HyperPay"));

        context.Services.AddHttpClient<HyperPayClient>((sp, client) =>
        {
            var opt = sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<HyperPayOptions>>().Value;

            client.BaseAddress = new Uri(opt.BaseUrl);
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", opt.AccessToken);
        });

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<HyperPayIntegrationApplicationModule>();
        });

    }
}
