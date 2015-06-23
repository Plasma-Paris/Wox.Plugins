using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Windows;
using Newtonsoft.Json;
using Wox.Plugin.Common;
using System.Collections.Generic;
using Wox.Plugin.Translator.Settings;

namespace Wox.Plugin.Translator
{
    public abstract class BaseTranslateService : BaseApiService
    {
        protected SettingElements _settings;
        protected PluginInitContext _context;

        public BaseTranslateService(SettingElements settings, PluginInitContext context)
        {
            if (settings == null)
                throw new ArgumentNullException("settings", "settings is null.");
            if (context == null)
                throw new ArgumentNullException("context", "context is null.");
            
            _settings = settings;
            _context = context;
        }

        public abstract string GetQueryString(string queryParams);

        public abstract TranslateResponse GetResponse(string queryParameters);

        public List<Result> TransformResponseToResults(TranslateResponse response)
        {
            if (response == null)
                return new List<Result>();

            if (response.ResponseStatus != 200)
                return new List<Result>() { 
                        new CustomResult()
                        {
                            Title = "Failed to translate", 
                            SubTitle = "Error: " + response.ResponseStatus
                        }
                    };

            var results = new List<Result>(response.Matches.Length);
            foreach (var match in response.Matches.OrderByDescending(m => m.Match))
                results.Add(new CustomResult()
                {
                    Title = match.Translation,
                    SubTitle = match.Match != null ? String.Format("(Trust: {0})", match.Match) : string.Empty,
                    Action = (c) => { Clipboard.SetText(match.Translation); return true; }
                });

            return results;
        }
    }
}
