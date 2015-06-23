using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Wox.Plugin.Common.Settings
{
    public class SettingService
    {
        public void SaveSettings(PluginInitContext context, object settings)
        {
            File.WriteAllText(Path.Combine(context.CurrentPluginMetadata.PluginDirectory, "setting.json"), JsonConvert.SerializeObject(settings, Formatting.Indented));
        }
    }
}
