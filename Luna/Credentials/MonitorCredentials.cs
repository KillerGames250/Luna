using System;

namespace Luna.Credentials
{
    internal class MonitorCredentials : Credentials
    {
        public MonitorCredentials() : base(Config.API_MONITOR_ID, Config.API_MONITOR_SECRET, Config.API_MONITOR_REFRESH, Config.API_MONITOR_TOKEN)
        {

        }
    }
}
