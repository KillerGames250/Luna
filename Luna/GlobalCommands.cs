using System;

namespace Luna
{
    class GlobalCommands
    {
        public static String Commands(String command, String channel, String user_name)
        {
            Database db = new();
            switch (TextFormatting.CommandFormat(command))
            {
                case "list":
                    return db.CommandsList(channel);

                case "hi":
                    return "Heya {user} !!!";

                case "ticket":
                    if (db.JoinLottery(channel, user_name, command.Substring(command.IndexOf(' '))) == 1)
                    {
                        return "Good luck {user}";
                    }
                    else
                    {
                        return "Error to buy a ticket {user}";
                    }

                default:
                    return "";
            }
        }
    }
}
