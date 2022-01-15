using System;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using System.Collections.Generic;
using TwitchLib.Communication.Events;
using System.Timers;

namespace Luna
{
    class Bot
    {
        Timer timer = new();
        Database db = new();
        Commands cmd = new();
        Translator translator = new();
        ConnectionCredentials credentials = new(Config.BOT_USERNAME, Config.OAUTH_TOKEN);
        public  static TwitchClient client = new();

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

        public static void ChannelJoin(String channel)
        {
            client.JoinChannel(channel.ToLower());
        }

        public static void ChannelLeave(String channel)
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
                client.SendMessage(e.ChatMessage.Channel,("@"+e.ChatMessage.DisplayName + " " + translator.Translate(e.ChatMessage.Channel, e.ChatMessage.Message).ToString()));
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
            if (DateTime.Now.ToString("HH:mm").Equals("22:00"))
            {
                List<String> channels= db.ChannelsWhereAutoBanEnable();
                List<String> bannedusers = db.BannedUsersList();
                foreach (String channel in channels)
                {
                    foreach (String users in bannedusers)
                    {
                        client.SendMessage(channel, $"/ban {users}");
                    }
                }
            }
        }
    }
}