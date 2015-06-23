using System;
using Wox.Plugin;
using Wox.Plugin.Translator;
using Wox.Plugin.Translator.MyMemory;
using Wox.Plugin.Translator.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Wox.Plugin.Translator
{
    [TestClass]
    public class WebTranslationTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            BaseTranslateService service = new MyMemoryTranslateService(new SettingElements(), new PluginInitContext());

            var response = service.GetResponse("http://api.mymemory.translated.net/get?q=Hello%20World!&langpair=en|fr");
            var result = service.TransformResponseToResults(response);

            Assert.AreEqual(response.Matches.Length, result.Count);
        }

        [TestMethod]
        public void TestMethod2()
        {
            BaseTranslateService service = new MyMemoryTranslateService(new SettingElements(), new PluginInitContext());

            var response = service.GetQueryString("en fr Hello");

            Assert.AreEqual("?q=Hello&langpair=en|fr", response);
        }

        [TestMethod]
        public void TestMethod3()
        {
            
        }
    }
}
