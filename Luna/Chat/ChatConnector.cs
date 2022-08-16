using System;
using System.Timers;
using System.Collections.Generic;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Events;
using Luna.Events;
using Luna.DataBase;
using Luna.Credentials;

namespace Luna.Chat
{
    class ChatConnector
    {
        private Timer timer = new();
        private Database db = new();
        private Commands cmd = new();
        private Translator translator = new();
        private ConnectionCredentials credentials = new(Config.BOT_USERNAME, Config.API_CHAT_TOKEN);
        private TwitchClient client = new();

        public void Connect()
        {
            client.Initialize(credentials, db.ChannelList());
            client.OnConnected += Client_OnConnected;
            client.OnDisconnected += Client_OnDisconnected;
            client.OnLog += Client_OnLog;
            client.OnChatCommandReceived += Client_OnChatCommandRecieved;
            client.OnError += Client_OnError;
            client.OnUserBanned += Clinent_OnUserBanned;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.Connect();
            timer.Interval = 60000;
            timer.Elapsed += OnTimerEvent;
            timer.Enabled = true;
        }

        public void Disconnect()
        {
            timer.Enabled = false;
            client.Disconnect();
        }

        public void ChannelJoin(string channel)
        {
            client.JoinChannel(channel.ToLower());
        }

        public void ChannelLeave(string channel)
        {
            client.LeaveChannel(channel.ToLower());
        }

        private void Client_OnChatCommandRecieved(object sender, OnChatCommandReceivedArgs e)
        {
            client.SendMessage(e.Command.ChatMessage.Channel, cmd.Command(e.Command.ChatMessage.Channel, e.Command.ChatMessage.DisplayName, e.Command.ChatMessage.UserId, e.Command.ChatMessage.Message));
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            if (!e.ChatMessage.Message.StartsWith('!'))
            {
                string message = translator.Translate(e.ChatMessage.Channel, e.ChatMessage.Message).ToString();
                if (!message.Equals(""))
                {
                    client.SendMessage(e.ChatMessage.Channel, message + $" .[By {e.ChatMessage.DisplayName}]");
                }
            }
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine("[BOT]: Connected");
        }

        private void Client_OnDisconnected(object sender, OnDisconnectedEventArgs e)
        {
            Console.WriteLine("[BOT]: Disconnected");
        }

        private void Client_OnLog(object sender, OnLogArgs e)
        {
            Console.WriteLine(e.Data);
        }

        private void Client_OnError(object sender, OnErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Clinent_OnUserBanned(object sender, OnUserBannedArgs e)
        {
            db.BannedUser(e.UserBan.Username, e.UserBan.TargetUserId, e.UserBan.RoomId, e.UserBan.Channel);
        }

        private void OnTimerEvent(object sender, ElapsedEventArgs e)
        {
            TimerEvents.Events();
        }

        public bool IsConnected()
        {
            return client.IsConnected;
        }
    }
}