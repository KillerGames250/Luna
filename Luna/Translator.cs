using System;
using System.Net.Http;

namespace Luna
{
    class Translator
    {
        Database db = new();
        HttpClient httpclient = new();

        public String Translate(String channel, String menssage)
        {
            try
            {
                String lang = "ja";
                HttpResponseMessage response = httpclient.GetAsync($"https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl={lang}&dt=t&q={menssage}").Result;
                String responseBody = response.Content.ReadAsStringAsync().Result;
                responseBody = responseBody.Substring(4, responseBody.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                if (!responseBody.Equals(menssage))
                {
                    return responseBody;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return "";
        }
    }
}
