﻿using Xunit;

namespace HyperPayIntegration.EntityFrameworkCore;

[CollectionDefinition(HyperPayIntegrationTestConsts.CollectionDefinitionName)]
public class HyperPayIntegrationEntityFrameworkCoreCollection : ICollectionFixture<HyperPayIntegrationEntityFrameworkCoreFixture>
{

}
