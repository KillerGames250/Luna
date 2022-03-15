using System;
using System.Collections.Generic;

namespace Luna
{
    internal class TimerEvents:Bot
    {
        public static void Events()
        {
            if (DateTime.Now.ToString("HH:mm").Equals(Config.TIME1) || DateTime.Now.ToString("HH:mm").Equals(Config.TIME2))
            {
                List<String> channels = db.ChannelsWhereAutoBanEnable();
                List<String> bannedusers = db.BannedUsersList();
                foreach (String channel in channels)
                {
                    foreach (String users in bannedusers)
                    {
                        client.SendMessage(channel, $"/ban {users}");
                    }
                }
            }
        }
    }
}
