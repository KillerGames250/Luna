using System;
using Luna.DataBase;

namespace Luna.Chat
{
    class ChatCommands
    {
        private Database db = new();
        public string Commands(string command, string user_id, string user_name, string display_name)
        {
            switch (TextFormatting.CommandFormat(command))
            {
                case "join":
                    if (db.BotJoin(user_id, user_name.ToLower()) == 1)
                    {
                        ChatConnector.ChannelJoin(display_name);
                        return $"Welcome to the group @{display_name}";
                    }
                    else
                    {
                        return "Error to join";
                    }

                case "leave":
                    if (db.BotLeave(user_id) == 1)
                    {
                        ChatConnector.ChannelLeave(display_name);
                        return $"See you @{display_name}";
                    }
                    else
                    {
                        return "Error to leave";
                    }

                case "enableban":
                    if (db.AutoBanEnable(user_id) == 1)
                    {
                        return "Auto ban is enabled in your channel";
                    }
                    else
                    {
                        return "Error to enable";
                    }

                case "disableban":
                    if (db.AutoBanDisable(user_id) == 1)
                    {
                        return "Auto ban is disabled in your channel";
                    }
                    else
                    {
                        return "Error to disable";
                    }

                case "enabletranslation":
                    if (Translator.AddChannelLanguage(user_name.ToLower(), user_id, command.Substring(command.IndexOf(' ') + 1, 5)) == 1)
                    {
                        return "Message translation is enabled in your channel";
                    }
                    else
                    {
                        return "Error to enable";
                    }

                case "disabletranslation":
                    if (Translator.RemoveChannelLanguage(user_name.ToLower(), user_id) == 1)
                    {
                        return "Message translation is disabled in your channel";
                    }
                    else
                    {
                        return "Error to disable";
                    }

                default:
                    return " ";
            }
        }
    }
}
