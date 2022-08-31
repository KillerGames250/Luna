using System;
using Luna.Chat;
using Luna.Monitor;
using Luna.Credentials;

namespace Luna
{
    internal class Controller
    {
        ChatCredentials chat_credential = new();
        MonitorCredentials monitor_credential = new();
        public void BotStart()
        {
            chat_credential.UpdateCredentials();
            monitor_credential.UpdateCredentials();
            ChatConnector chat = new(chat_credential.UserName, chat_credential.Token);
            LiveMonitor monitor = new(monitor_credential.ID, monitor_credential.Secret, monitor_credential.Token);
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
