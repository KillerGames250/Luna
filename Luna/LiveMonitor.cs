﻿using System;
using TwitchLib.Api;
using TwitchLib.Api.Services;
using TwitchLib.Api.Services.Events.LiveStreamMonitor;

namespace Luna
{
    internal class LiveMonitor
    {
        TwitchAPI twitchAPI = new();
        LiveStreamMonitorService liveMonitor;

        public LiveMonitor()
        {
            twitchAPI.Settings.ClientId = Config.API_MONITOR_ID;
            twitchAPI.Settings.AccessToken = Config.API_MONITOR_TOKEN;
            twitchAPI.Settings.Secret = Config.API_MONITOR_SECRET;
            liveMonitor = new(twitchAPI, 60);
            liveMonitor.SetChannelsByName(Bot.channels);
        }

        public void MonitorStart()
        {
            liveMonitor.OnStreamOnline += LiveMonitor_OnStreamOnline;
            liveMonitor.OnStreamOffline += LiveMonitor_OnStreamOffline;
            liveMonitor.Start();
        }

        public void MonitorStop()
        {
            liveMonitor.Stop();
        }

        private void LiveMonitor_OnStreamOnline(object sender, OnStreamOnlineArgs e)
        {
            TimerMessage.AddChannel(e.Channel);
        }

        private void LiveMonitor_OnStreamOffline(object sender, OnStreamOfflineArgs e)
        {
            TimerMessage.RemoveChannel(e.Channel);
        }
    }
}
