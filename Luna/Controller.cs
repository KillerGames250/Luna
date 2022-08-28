using System;
using Luna.Chat;
using Luna.Monitor;
using Luna.Credentials;
using System.Threading.Tasks;

namespace Luna
{
    internal class Controller
    {
        ChatCredentials chat_credential = new();
        MonitorCredentials monitor_credential = new();
        public void BotStart()
        {
            CredentialUpdate();
            ChatConnector chat = new(chat_credential.UserName, chat_credential.Token);
            LiveMonitor monitor = new(monitor_credential.ID, monitor_credential.Secret, monitor_credential.Token);
            chat.Connect();
            monitor.MonitorStart();
            while (true)
            {
                if (!chat.IsConnected())
                {
                    break;
                }
            }
        }

        private void CredentialUpdate()
        {
            
        }
    }
}
