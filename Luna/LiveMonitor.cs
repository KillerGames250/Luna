using System;
using System.Collections.Generic;
using TwitchLib.Api;
using TwitchLib.Api.Services;
using TwitchLib.Api.Services.Events;
using TwitchLib.Api.Services.Events.LiveStreamMonitor;

namespace Luna
{
    internal class LiveMonitor
    {
        TwitchAPI twitchAPI = new();
        LiveStreamMonitorService liveMonitor;
        public static List<String> livesOnLine  = new();

        public LiveMonitor()
        {
            twitchAPI.Settings.ClientId = Config.API_MONITOR_ID;
            twitchAPI.Settings.AccessToken = Config.API_MONITOR_TOKEN;
            twitchAPI.Settings.Secret = Config.API_MONITOR_SECRET;
            liveMonitor = new(twitchAPI, 60);
            List<String> list = new List<String>() {"lunachan250", "killergames250", "caixinhatv" , "tiekoi"};
            liveMonitor.SetChannelsByName(list);
        }

        public void monitorStart()
        {
            liveMonitor.OnStreamOnline += LiveMonitor_OnStreamOnline;
            liveMonitor.OnStreamOffline += LiveMonitor_OnStreamOffline;
            liveMonitor.Start();
        }

        public void monitorStop()
        {
            liveMonitor.Stop();
        }

        private void LiveMonitor_OnStreamOnline(object sender, OnStreamOnlineArgs e)
        {
            livesOnLine.Add(e.Channel);
        }

        private void LiveMonitor_OnStreamOffline(object sender, OnStreamOfflineArgs e)
        {
            livesOnLine.Remove(e.Channel);
        }

    }
}
