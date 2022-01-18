using System;
using System.Net.Http;
using System.Collections.Generic;

namespace Luna
{
    class Translator
    {
        static Database db = new();
        static HttpClient httpclient = new();
        static List<ChannelLanguage> teste = new(db.ChannelsWhereTranlationEnable());

        public String Translate(String channel, String message)
        {

            try
            {
                String lang = SearchLanguage(channel);
                if (lang == "")
                {
                    return "";
                }
                HttpResponseMessage response = httpclient.GetAsync($"https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl={lang}&dt=t&q={TextFormatting.TranslationMessageWhithoutSpacesFormat(message)}").Result;
                String translation = response.Content.ReadAsStringAsync().Result;
                translation = translation.Substring(4, translation.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                if (!translation.Equals(message))
                {
                    return TextFormatting.TranslationMessageNormalFormat(translation);
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

        private String SearchLanguage(String channel)
        {
            foreach (ChannelLanguage channel_language in teste)
            {
                if (channel_language.GetChannel().Equals(channel))
                {
                    return channel_language.GetLanguage();
                }
            }
            return "";
        }

        private static int SearchUser(String channel)
        {
            int i = 0;
            foreach (ChannelLanguage channel_language in teste)
            {
                if (channel_language.GetChannel().Equals(channel))
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public static int AddChannelLanguage(String channel, String channel_id, String language)
        {
            ChannelLanguage temp = new(channel, language);
            try
            {
                teste.Add(temp);
                db.TranslationEnable(channel_id, language);
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return 0;
        }

        public static int RemoveChannelLanguage(String channel, String channel_id)
        {
            try
            {
                teste.RemoveAt(SearchUser(channel));
                db.TranlationDisable(channel_id);
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return 0;
        }
    }

    class ChannelLanguage
    {
        private String channel;
        private String language;    

        public ChannelLanguage(String channel, String language)
        {
            this.channel = channel;
            this.language = language;
        }

        public void SetChannel(String channel)
        {
            this.channel=channel;
        }

        public String GetChannel()
        {
            return this.channel;
        }

        public void SetLanguage(String language)
        {
            this.language = language;
        }

        public String GetLanguage()
        {
            return this.language;
        }
    }
}