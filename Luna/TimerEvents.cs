using System;

namespace Luna
{
    internal class TimerEvents
    {
        public void Events()
        {
            if (DateTime.Now.ToString("HH:mm").Equals(Config.TIME1) || DateTime.Now.ToString("HH:mm").Equals(Config.TIME2))
            {
                AutoBan.Ban();
            }
            TimerMessage.SendMesage();
        }
    }
}
