using System;

namespace Luna
{
    class Commands
    {
        Database db = new();
        
        public String Command(String channel, String display_name, String user_id, String command)
        {
            String mensage = "";
            String user_name = display_name.ToLower();
            if (channel.Equals(Config.BOT_USERNAME))
            {
                mensage = BotCommands.Commands(command, user_id, user_name, display_name);
            }
            if (channel.Equals(user_name))
            {
                mensage = StreamersCommands.Commands(command, user_id, channel);
            }
            if (mensage.Equals(""))
            {
                mensage = db.CommandGet(channel, TextFormatting.CommandFormat(command)); // User commands
                if (mensage.Equals(""))
                {
                    mensage = GlobalCommands.Commands(TextFormatting.CommandFormat(command), channel);
                }
            }
            return TextFormatting.MenssageFormat(mensage, user_name, command, channel);
        }
    }
}