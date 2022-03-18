using System;

namespace Luna
{
    class GlobalCommands
    {
        public static String Commands(String command, String channel)
        {
            Database db = new();
            switch (command)
            {
                case "list":
                    return db.CommandsList(channel);

                case "hi":
                    return "Heya {user} !!!";

                case "ticket":
                    if (db.JoinLottery() == 1)
                    {
                        return "Good luck {user}";
                    }
                    else
                    {
                        return "Error to buy a ticket";
                    }

                default:
                    return "";
            }
        }
    }
}
