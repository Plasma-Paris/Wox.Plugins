using System;
using System.Linq;
using System.Collections.Generic;
using Wox.Plugin.Common.Settings;
using System.Collections.ObjectModel;

namespace Wox.Plugin.Translator.Settings
{
    public class SettingElements : NotifyPropertyChanged
    {
        public SettingElements()
        {
            DefaultLanguages = new ObservableCollection<DefaultLanguage>();
        }

        public const string K_API_MYMEMORY = "MyMemory";
        public const string K_API_YANDEX = "Yandex.Translate";

        public ObservableCollection<DefaultLanguage> DefaultLanguages { get; set; }

        private string _yandexApiKey;
        private string _apiName;
        public string ApiName
        {
            get
            {
                return _apiName;
            }
            set
            {
                _apiName = value;
                RaisePropertyChanged(() => ApiName);
            }
        }
        public string YandexApiKey
        {
            get
            {
                return _yandexApiKey;
            }
            set
            {
                _yandexApiKey = value;
                RaisePropertyChanged(() => YandexApiKey);
            }
        }
    }
}
