using System;
using System.IO;
using Newtonsoft.Json;
using Wox.Plugin.Common;
using System.Windows.Controls;
using Wox.Plugin.Jrnl.Settings;
using System.Collections.Generic;
using Wox.Plugin.Common.Settings;

namespace Wox.Plugin.Jrnl
{
    class Main : IPlugin, ISettingProvider
    {
        private PluginInitContext _context;
        private SettingElements _settings;          

        public List<Result> Query(Query query)
        {
            _context.API.StartLoadingBar();

            JrnlService service = new JrnlService(_settings, _context);

            try
            {
                string queryString = query == null ? String.Empty : query.GetAllRemainingParameter();
                string commandLine = service.TranformQueryToCommandLine(queryString);
                var response = service.ExecuteCommandLine(commandLine);
                return service.TransformCommandLineResponseToResults(response, queryString);
            }
            finally
            {
                _context.API.StopLoadingBar();
            }
        }

        public void Init(PluginInitContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context", "context is null.");

            _context = context;
            _settings = JsonConvert.DeserializeObject<SettingElements>(
                File.ReadAllText(Path.Combine(context.CurrentPluginMetadata.PluginDirectory, "setting.json")));
            CustomResult.DefaultIcoPath = context.CurrentPluginMetadata.IcoPath;
        }
        
        public Control CreateSettingPanel()
        {
            return new SettingsForm(_context, _settings, new SettingService());
        }
    }
}
