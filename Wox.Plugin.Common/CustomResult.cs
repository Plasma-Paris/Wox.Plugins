using System;
using System.Linq;
using System.Collections.Generic;

namespace Wox.Plugin.Common
{
    public class CustomResult : Result
    {
        public static string DefaultIcoPath;
        public CustomResult()
        {
            IcoPath = DefaultIcoPath;
        }
    }
}
