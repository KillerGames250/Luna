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

        public static void SendMesage(int time)
        {
            foreach (String channel in livesOnLine)
            {
                foreach (ChannelMessage cm in Bot.db.TimerMessages(channel))
                {
                    if ((time % cm.Interval) == 0)
                    {
                        Bot.client.SendMessage(cm.Channel,cm.Message);
                    }
                }
            }
        }
    }

    internal class ChannelMessage
    {
        public String Channel { get; private set; }
        public int Interval { get; private set; }
        public String Message { get; private set; }

        public ChannelMessage(String channel, int interval,String message)
        {
            this.Channel = channel;
            this.Interval = interval;
            this.Message = message;
        }
    }
}
