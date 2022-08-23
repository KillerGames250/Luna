using System;
using TwitchLib.Client;
using Luna.Credentials;

namespace Luna.Events
{
    internal class TimerEvents
    {
        public void Events(TwitchClient client)
        {
            AutoBan autoBan = new();
            TimerMessage message = new();
            int time = DateTime.Now.Hour * 60 + DateTime.Now.Minute;
            message.SendMesage(client, time);
            if (time % Convert.ToInt32(Config.TIME_BAN) == 0)
            {
                autoBan.Ban(client);
            }
        }
    }
}
