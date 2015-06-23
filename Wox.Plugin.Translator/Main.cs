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
using Wox.Plugin.Translator.Yandex;
using Wox.Plugin.Translator.MyMemory;
using Wox.Plugin.Translator.Settings;

namespace Wox.Plugin.Translator
{
    public class Main : IPlugin, ISettingProvider
    {
        private SettingElements _settings;
        private PluginInitContext _context;

        public List<Result> Query(Query query)
        {
            if (query == null)
                throw new ArgumentNullException("query", "query is null.");

            if (query.ActionParameters.Count < 3)
                return ShowUsage(query);

            _context.API.StartLoadingBar();

            BaseTranslateService service;
            switch (_settings.ApiName)
            {
                case SettingElements.K_API_MYMEMORY:
                    service = new MyMemoryTranslateService(_settings, _context);
                    break;
                case SettingElements.K_API_YANDEX:
                default:
                    service = new YandexTranslateService(_settings, _context);
                    break;
            }

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
            foreach (DefaultLanguage defaultLanguage in _settings.DefaultLanguages)
            {
                string autoCompleteItemText = String.Format("{0} {1} {2}",
                    _context.CurrentPluginMetadata.ActionKeyword, defaultLanguage.Source, defaultLanguage.Destination);
                results.Add(new CustomResult()
                {
                    Title = autoCompleteItemText,
                    Action = (c) => { _context.API.ChangeQuery(autoCompleteItemText, true); return false; }
                });
            }

            results.Add(new CustomResult()
            {
                Title = String.Format("Usage : tr source-language destination-language words (ex: {0} en fr Hello)",
                    _context.CurrentPluginMetadata.ActionKeyword),
                SubTitle = "Powered by " + _settings.ApiName ?? SettingElements.K_API_YANDEX + " API", 
            });

            return results;
        }
        
        public Control CreateSettingPanel()
        {
            return new SettingsForm(_context, _settings, new SettingService());
        }
    }
}
