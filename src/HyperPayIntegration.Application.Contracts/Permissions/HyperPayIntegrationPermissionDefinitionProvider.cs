using HyperPayIntegration.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace HyperPayIntegration.Permissions;

public class HyperPayIntegrationPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(HyperPayIntegrationPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(HyperPayIntegrationPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HyperPayIntegrationResource>(name);
    }
}
