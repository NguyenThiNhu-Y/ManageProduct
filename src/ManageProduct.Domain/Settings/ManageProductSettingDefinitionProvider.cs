using Volo.Abp.Settings;

namespace ManageProduct.Settings
{

    public class ManageProductSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(ManageProductSettings.MySetting1));
        }
    }
}