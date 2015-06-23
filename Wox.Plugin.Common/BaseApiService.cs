using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Wox.Plugin.Common
{
    public class BaseApiService
    {
        public static HttpWebResponse CreateGetHttpResponse(string url)
        {
            if (String.IsNullOrEmpty(url))
                throw new ArgumentNullException("url");

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";

            return request.GetResponse() as HttpWebResponse;
        }
                
        public T GetJSON<T>(string url)
        {
            WebResponse response;
            try
            {
                response = CreateGetHttpResponse(url);
            }
            catch (System.Net.WebException ex)
            {
                response = ex.Response;
            }

            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                return JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
        }
    }
}
