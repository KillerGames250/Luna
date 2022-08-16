using System;
using Luna.Chat;
using Luna.Monitor;
using Luna.Credentials;


namespace Luna
{
    internal class Controller
    {
        public void BotStart()
        {
            Token token = new();
            token.UpdateTokens();
            ChatConnector chat = new();
            LiveMonitor monitor = new();
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
    }
}
