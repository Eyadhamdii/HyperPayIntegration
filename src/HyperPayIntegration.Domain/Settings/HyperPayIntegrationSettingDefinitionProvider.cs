using Volo.Abp.Settings;

namespace HyperPayIntegration.Settings;

public class HyperPayIntegrationSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(HyperPayIntegrationSettings.MySetting1));
    }
}
