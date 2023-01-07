using Luna.Chat;
using Luna.Monitor;
using Luna.Settings;

namespace Luna
{
    internal class Controller
    {
        public void BotStart()
        {
            if (ControllerSettings.Load())
            {
                ChatConnector chat = new(ControllerSettings.settings.CredentialsTwitch.User, ControllerSettings.settings.CredentialsTwitch.ChatToken);
                LiveMonitor monitor = new(ControllerSettings.settings.CredentialsTwitch.MonitorID, ControllerSettings.settings.CredentialsTwitch.MonitorSecret, ControllerSettings.settings.CredentialsTwitch.MonitorToken);
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
    }
}
