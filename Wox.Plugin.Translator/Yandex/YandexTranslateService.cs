using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Wox.Plugin.Translator.Settings;

namespace Wox.Plugin.Translator.Yandex
{

    public class YandexTranslateService : BaseTranslateService
    {
        public YandexTranslateService(SettingElements settings, PluginInitContext context) :
            base (settings, context)
        { }

        private string _translateURL = "https://translate.yandex.net/api/v1.5/tr.json/translate";

        public override string GetQueryString(string queryParams)
        {
            if (String.IsNullOrEmpty(queryParams))
                throw new ArgumentException("queryParams is null or empty.", "queryParams");

            var split = queryParams.Split(' ');

            if (split.Length < 3)
                throw new ArgumentException("queryParams is less than three words.", "queryParams");

            return String.Format("?key={0}&lang={1}-{2}&text={3}",
                _settings.YandexApiKey,
                split[0],
                split[1],
                String.Join(" ", split.Skip(2).ToArray()));
        }

        public override TranslateResponse GetResponse(string queryParameters)
        {
            var response = GetJSON<YandexResult>(_translateURL + queryParameters);
            var results = new List<TranslateMatch>();

            foreach (var text in response.Text)
            	results.Add(new TranslateMatch() { Translation = text });

            return new TranslateResponse() { ResponseStatus = response.Code, Matches = results.ToArray() };
        }
    }
}
