using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Wox.Plugin.Synonym.Settings;

namespace Wox.Plugin.Synonym
{
    public class ThesaurusSynonymService : BaseSynonymService
    {
        public ThesaurusSynonymService(SettingElements settings, PluginInitContext context) :
            base(settings, context)
        { }

        private string _synonymURL = "http://thesaurus.altervista.org/thesaurus/v1";

        public override string GetQueryString(string queryParams)
        {
            if (String.IsNullOrEmpty(queryParams))
                throw new ArgumentException("queryParams is null or empty.", "queryParams");

            return String.Format("?word={0}&language={1}&key={2}&output=json", 
                queryParams,
                _settings.DefaultLanguage,
                _settings.ThesaurusApiKey
            );
        }

        public override ApiResponse GetResponse(string queryParameters)
        {
            return GetJSON<ApiResponse>(_synonymURL + queryParameters);
        }
    }
}
