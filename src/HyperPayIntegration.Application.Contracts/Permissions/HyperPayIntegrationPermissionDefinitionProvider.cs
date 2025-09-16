using HyperPayIntegration.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace HyperPayIntegration.Permissions;

public class HyperPayIntegrationPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(HyperPayIntegrationPermissions.GroupName);
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HyperPayIntegrationResource>(name);
    }
}
