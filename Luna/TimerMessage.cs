using System;
using System.Collections.Generic;

namespace Luna
{
    internal class TimerMessage
    {
        private static List<String> livesOnLine = new();

        public static void AddChannel(String channel)
        {
            livesOnLine.Add(channel);
        }

        public static void RemoveChannel(String channel)
        {
            livesOnLine.Remove(channel);
        }

        public static void SendMesage()
        {
            int aux = (DateTime.Now.Hour * 60) + DateTime.Now.Minute;
            foreach (String channel in livesOnLine)
            {
                foreach (ChannelMessage cm in Bot.db.TimerMessages(channel))
                {
                    if ((aux % cm.GetInterval()) == 0)
                    {
                        Bot.client.SendMessage(cm.GetChannel(),cm.GetMessage());
                    }
                }
            }
        }
    }

    internal class ChannelMessage
    {
        private String channel;
        private int interval;
        private String message;

        public ChannelMessage(String channel, int interval,String message)
        {
            this.channel = channel;
            this.interval = interval;
            this.message = message;
        }

        public String GetChannel()
        {
            return this.channel;
        }

        public void SetChannel(String channel)
        {
            this.channel = channel;
        }

        public String GetMessage()
        {
            return this.message;
        }

        public void SetMessage(String message)
        {
            this.message = message;
        }

        public int GetInterval()
        {
            return interval;
        }

        public void SetInterval(int interval)
        {
            this.interval = interval;
        }
    }
}
