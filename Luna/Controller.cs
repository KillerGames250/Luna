using Luna.Chat;
using Luna.Monitor;
using Luna.Settings;

namespace Luna
{
	internal class Controller
	{
		private ChatConnector chat;
		private LiveMonitor monitor;

		public void BotStart()
		{
			if (ControllerSettings.Load())
			{
				chat = new(ControllerSettings.settings.CredentialsTwitch.User, ControllerSettings.settings.CredentialsTwitch.ChatToken);
				monitor = new(ControllerSettings.settings.CredentialsTwitch.MonitorID, ControllerSettings.settings.CredentialsTwitch.MonitorSecret, ControllerSettings.settings.CredentialsTwitch.MonitorToken);
				chat.Connect();
				monitor.MonitorStart();
				while (true)
				{
					System.Threading.Thread.Sleep(1);
					if (!chat.IsConnected())
					{
						break;
					}
				}
			}
		}

		public void BotStop()
		{
			chat.Disconnect();
			monitor.MonitorStop();
		}
	}
}
