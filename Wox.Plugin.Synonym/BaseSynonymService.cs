using System;
using System.Linq;
using System.Text;
using System.Windows;
using Wox.Plugin.Common;
using System.Collections.Generic;
using Wox.Plugin.Synonym.Settings;

namespace Wox.Plugin.Synonym
{
    public abstract class BaseSynonymService : BaseApiService
    {
        protected SettingElements _settings;
        protected PluginInitContext _context;

        public BaseSynonymService(SettingElements settings, PluginInitContext context)
        {
            if (settings == null)
                throw new ArgumentNullException("settings", "settings is null.");
            if (context == null)
                throw new ArgumentNullException("context", "context is null.");

            _settings = settings;
            _context = context;
        }

        public abstract string GetQueryString(string queryParams);
        public abstract ApiResponse GetResponse(string queryParameters);

        public List<Result> TransformResponseToResults(ApiResponse response)
        {
            if (response == null)
                return new List<Result>();

            if (!string.IsNullOrEmpty(response.Error))
                return new List<Result>() { new CustomResult()
                    {
                        Title = response.Error
                    } 
                };
            
            var results = new List<Result>(response.Response.Length);
            foreach (var result in response.Response)
                foreach (var synonym in result.List.Synonyms.Split('|'))
                    results.Add(new CustomResult()
                    {
                        Title = synonym,
                        SubTitle = result.List.Category,
                        Action = (c) => { Clipboard.SetText(result.List.Synonyms); return true; }
                    });

            return results;
        }
    }
}
