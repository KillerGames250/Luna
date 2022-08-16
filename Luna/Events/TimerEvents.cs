using System;

namespace Luna.Events
{
    internal class TimerEvents
    {
        public static void Events()
        {
            int time = DateTime.Now.Hour * 60 + DateTime.Now.Minute;
            TimerMessage.SendMesage(time);
            if (time % Convert.ToInt32(Config.TIME_BAN) == 0)
            {
                AutoBan.Ban();
            }
        }
    }
}
