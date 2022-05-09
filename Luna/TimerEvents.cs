using System;
using System.Collections.Generic;

namespace Luna
{
    internal class TimerEvents
    {
        LiveMonitor monitor = new();
        public void Events()
        {
            if (DateTime.Now.ToString("HH:mm").Equals(Config.TIME1) || DateTime.Now.ToString("HH:mm").Equals(Config.TIME2))
            {
                List<String> channels = Bot.db.ChannelsWhereAutoBanEnable();
                List<String> bannedusers = Bot.db.BannedUsersList();
                foreach (String channel in channels)
                {
                    foreach (String users in bannedusers)
                    {
                        Bot.client.SendMessage(channel, $"/ban {users}");
                    }
                }
            }
        }
    }
}
