using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Windows;
using Newtonsoft.Json;
using System.Windows.Controls;
using System.Collections.Generic;
using Wox.Plugin.Translator.Settings;

namespace Wox.Plugin.Translator.MyMemory
{
    public class MyMemoryTranslateService : BaseTranslateService
    {
        public MyMemoryTranslateService(SettingElements settings, PluginInitContext context) :
            base (settings, context)
        { }

        private string _translateURL = "http://api.mymemory.translated.net/get";

        public override string GetQueryString(string queryParams)
        {
            if (String.IsNullOrEmpty(queryParams))
                throw new ArgumentException("queryParams is null or empty.", "queryParams");

            var split = queryParams.Split(' ');

            if (split.Length < 3)
                throw new ArgumentException("queryParams is less than three words.", "queryParams");

            return String.Format("?q={0}&langpair={1}|{2}",
                String.Join(" ", split.Skip(2).ToArray()),
                split[0],
                split[1]);
        }

        public override TranslateResponse GetResponse(string queryParameters)
        {
            return GetJSON<TranslateResponse>(_translateURL + queryParameters);
        }
    }
}
