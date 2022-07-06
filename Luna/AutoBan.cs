using System;
using System.Collections.Generic;

namespace Luna
{
    internal class AutoBan
    {
        public static void Ban()
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
