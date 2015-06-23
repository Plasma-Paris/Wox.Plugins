using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wox.Plugin.Common.Settings;

namespace Wox.Plugin.Synonym.Settings
{
    public class SettingElements : NotifyPropertyChanged
    {
        public SettingElements()
        {
            
        }

        private string _thesaurusApiKey;
        private string _defaultLanguage;
        public string DefaultLanguage
        {
            get
            {
                return _defaultLanguage;
            }
            set
            {
                _defaultLanguage = value;
                RaisePropertyChanged(() => DefaultLanguage);
            }
        }
        public string ThesaurusApiKey
        {
            get
            {
                return _thesaurusApiKey;
            }
            set
            {
                _thesaurusApiKey = value;
                RaisePropertyChanged(() => ThesaurusApiKey);
            }
        }

        public string ApiName { get { return "Thesaurus"; } }
    }
}
