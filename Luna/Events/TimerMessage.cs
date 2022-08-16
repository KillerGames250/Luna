using Luna.Chat;
using Luna.DataBase;
using System;
using System.Collections.Generic;

namespace Luna.Events
{
    internal class TimerMessage
    {
        private Database db = new();

        private static List<string> livesOnLine = new();

        public static void AddChannel(string channel)
        {
            livesOnLine.Add(channel);
        }

        public static void RemoveChannel(string channel)
        {
            livesOnLine.Remove(channel);
        }

        public void SendMesage(int time)
        {
            foreach (string channel in livesOnLine)
            {
                foreach (ChannelMessage cm in db.TimerMessages(channel))
                {
                    if (time % cm.Interval == 0)
                    {
                        Chat.ChatConnector.client.SendMessage(cm.Channel, cm.Message);
                    }
                }
            }
        }
    }

    internal class ChannelMessage
    {
        public string Channel { get; private set; }
        public int Interval { get; private set; }
        public string Message { get; private set; }

        public ChannelMessage(string channel, int interval, string message)
        {
            Channel = channel;
            Interval = interval;
            Message = message;
        }
    }
}
