using HyperPayIntegration.Samples;
using Xunit;

namespace HyperPayIntegration.EntityFrameworkCore.Domains;

[Collection(HyperPayIntegrationTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<HyperPayIntegrationEntityFrameworkCoreTestModule>
{

}
