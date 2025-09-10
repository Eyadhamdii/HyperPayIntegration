using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace HyperPayIntegration.Pages;

public class Index_Tests : HyperPayIntegrationWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
