using HyperPayIntegration.Samples;
using Xunit;

namespace HyperPayIntegration.EntityFrameworkCore.Applications;

[Collection(HyperPayIntegrationTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<HyperPayIntegrationEntityFrameworkCoreTestModule>
{

}
