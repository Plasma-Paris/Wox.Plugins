using System;
using System.IO;
using Wox.Plugin;
using System.Net;
using System.Text;
using Wox.Plugin.Synonym;
using Wox.Plugin.Synonym.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Wox.Plugin.Synonyms
{
    [TestClass]
    public class WebSynonymousTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            BaseSynonymService service = new ThesaurusSynonymService(new SettingElements(), new PluginInitContext());

            var url = String.Format("?word={0}&language={1}&key={2}&output=json", "te", "fr_FR", string.Empty);
            var response = service.GetResponse(url);
            var result = service.TransformResponseToResults(response);

            
        }

        [TestMethod]
        public void TestMethod3()
        {
            string newVariable = "fr_FR"; // it_IT, fr_FR, de_DE, en_US, el_GR, es_ES, de_DE, no_NO, pt_PT, ro_RO, ru_RU, sk_SK
            var newVariable1 = "voiture";
            var keyVariable = "";
            var url = String.Format("http://thesaurus.altervista.org/thesaurus/v1?word={0}&language={1}&key={2}&output=json", newVariable1, newVariable, keyVariable); 
                
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";

            var httpResponse = request.GetResponse() as HttpWebResponse;
            string response; 

            using (Stream stream = httpResponse.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                response = reader.ReadToEnd();
        }
    }
}
