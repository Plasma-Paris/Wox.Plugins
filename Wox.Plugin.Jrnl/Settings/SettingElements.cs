using System;
using System.Linq;
using System.Collections.Generic;
using Wox.Plugin.Common.Settings;
using System.Collections.ObjectModel;

namespace Wox.Plugin.Jrnl.Settings
{
    public class SettingElements : NotifyPropertyChanged
    {
        public SettingElements()
        {
            
        }

        private string _jrnlPath;
        public string JrnlPath
        {
            get
            {
                return _jrnlPath;
            }
            set
            {
                _jrnlPath = value;
                RaisePropertyChanged(() => JrnlPath);
            }
        }
    }
}
