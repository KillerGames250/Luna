using System;
using Luna.Chat;
using Luna.DataBase;
using System.Collections.Generic;

namespace Luna.Events
{
    internal class AutoBan
    {
        private Database db = new();
        public void Ban()
        {
            List<string> channels = db.ChannelsWhereAutoBanEnable();
            List<string> bannedusers = db.BannedUsersList();
            foreach (string channel in channels)
            {
                foreach (string users in bannedusers)
                {
                    Chat.ChatConnector.client.SendMessage(channel, $"/ban {users}");
                }
            }
        }
    }
}
