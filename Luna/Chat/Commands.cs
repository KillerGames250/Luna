using System;
using Luna.DataBase;
using Luna.Credentials;


namespace Luna.Chat
{
    class Commands
    {
        private Database db = new();
        private ChatCommands botCommands = new();
        private GlobalCommands globalCommands = new();
        private StreamersCommands streamersCommands = new();

        public string Command(string channel, string display_name, string user_id, string command)
        {
            string mensage = "";
            string user_name = display_name.ToLower();
            if (channel.Equals(Config.BOT_USERNAME))
            {
                mensage = botCommands.Commands(command, user_id, user_name, display_name);
            }
            if (channel.Equals(user_name))
            {
                mensage = streamersCommands.Commands(command, user_id, channel);
            }
            if (mensage.Equals(""))
            {
                mensage = db.CommandGet(channel, TextFormatting.CommandFormat(command));
                if (mensage.Equals(""))
                {
                    mensage = globalCommands.Commands(command, channel, display_name);
                }
            }
            return TextFormatting.MenssageFormat(mensage, user_name, command, channel);
        }
    }
}