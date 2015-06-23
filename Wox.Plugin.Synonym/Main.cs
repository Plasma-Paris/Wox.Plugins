using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Windows;
using Newtonsoft.Json;
using Wox.Plugin.Common;
using System.Windows.Controls;
using System.Collections.Generic;
using Wox.Plugin.Common.Settings;
using Wox.Plugin.Synonym.Settings;

namespace Wox.Plugin.Synonym
{
    public class Main : IPlugin, ISettingProvider
    {
        private SettingElements _settings;
        private PluginInitContext _context;

        public List<Result> Query(Query query)
        {
            if (query == null)
                throw new ArgumentNullException("query", "query is null.");

            if (query.ActionParameters.Count < 1)
                return ShowUsage(query);

            _context.API.StartLoadingBar();

            BaseSynonymService service;
            service = new ThesaurusSynonymService(_settings, _context);

            try
            {
                string queryString = service.GetQueryString(query.GetAllRemainingParameter());
                var response = service.GetResponse(queryString);
                return service.TransformResponseToResults(response);
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

        public List<Result> ShowUsage(Query query)
        {
            var results = new List<Result>();

            results.Add(new CustomResult()
            {
                Title = String.Format("Current language : {0}", _settings.DefaultLanguage),
                SubTitle = "Powered by " + _settings.ApiName + " API",
            });

            return results;
        }

        public Control CreateSettingPanel()
        {
            return new SettingsForm(_context, _settings, new SettingService());
        }
    }
}
