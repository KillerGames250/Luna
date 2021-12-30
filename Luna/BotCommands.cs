using System;

namespace Luna
{
    class BotCommands:Bot
    {
        public static String Commands(String command, String user_id, String user_name, String display_name, String channel)
        {
            Database db = new();
            switch (command)
            {
                case "join":
                    if (db.BotJoin(user_id, user_name.ToLower()) == 1)
                    {
                        Bot.ChannelJoin(display_name);
                        return $"Welcome to the group @{display_name}";
                    }
                    else
                    {
                        return "Error to join";
                    }

                case "leave":
                    if (db.BotLeave(user_id) == 1)
                    {
                        Bot.ChannelLeave(display_name);
                        return $"See you @{display_name}";
                    }
                    else
                    {
                        return "Error to leave";
                    }

                case "enableban":
                    if (db.AutoBanEnable(user_id) == 1)
                    {
                        return "Auto ban is enable in your channel";
                    }
                    else
                    {
                        return "Error to enable";
                    }

                case "disableban":
                    if (db.AutoBanDisable(user_id) == 1)
                    {
                        return "Auto ban is disable in your channel";
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
