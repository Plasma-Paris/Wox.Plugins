using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Windows;
using Newtonsoft.Json;
using System.Windows.Controls;
using System.Collections.Generic;

namespace Wox.Plugin.Translator.Settings
{
    public class DefaultLanguage
    {
        public string Source { get; set; }
        public string Destination { get; set; }

        public override string ToString()
        {
            return String.Format("Source: {0} - Destination: {1}", Source, Destination);
        }
    }
}
