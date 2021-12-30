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

                default:
                    return "";
            }
        }
    }
}
