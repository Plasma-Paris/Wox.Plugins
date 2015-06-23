using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Windows;
using Newtonsoft.Json;
using System.Windows.Controls;
using System.Collections.Generic;

namespace Wox.Plugin.Translator
{
    public class TranslateMatch
    {
        public string Translation { get; set; }
        public float? Match { get; set; }
    }
}
