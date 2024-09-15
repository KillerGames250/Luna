using System;
using Luna.DataBase;
using Luna.Events;
using System.Timers;
using TwitchLib.Api;
using TwitchLib.Api.Services;
using TwitchLib.Api.Services.Events.LiveStreamMonitor;

namespace Luna.Monitor
{
	internal class LiveMonitor
	{
		private Timer timer = new();
		private TwitchAPI twitchAPI = new();
		private LiveStreamMonitorService liveMonitor;
		private Database db = new();

		public LiveMonitor(String monitor_id, String monitor_secret, String monitor_token)
		{
			twitchAPI.Settings.ClientId = monitor_id;
			twitchAPI.Settings.AccessToken = monitor_token;
			twitchAPI.Settings.Secret = monitor_secret;
			liveMonitor = new(twitchAPI, 60);
			liveMonitor.SetChannelsByName(db.ChannelList());
			timer.Interval = 600000;
			timer.Elapsed += OnTimerEvent;
			timer.Enabled = true;
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

		private void OnTimerEvent(object sender, ElapsedEventArgs e)
		{
			liveMonitor.SetChannelsByName(db.ChannelList());
		}
	}
}
