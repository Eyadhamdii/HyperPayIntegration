using Microsoft.AspNetCore.Builder;
using HyperPayIntegration;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<HyperPayIntegrationWebTestModule>();

public partial class Program
{
}
