using System;

namespace Luna
{
    class StreamersCommands
    {
        public static String Commands(String command, String user_id, String channel)
        {
            Database db = new();
            switch (TextFormatting.CommandFormat(command))
            {
                case "add":
                    String command_name = command.Substring(command.IndexOf(' ') + 1, command.IndexOf('=') - command.IndexOf(' ') - 1);
                    String command_action = command.Substring(command.IndexOf('=') + 1);
                    switch (db.CommandAdd(user_id, command_name.Trim(), command_action.Trim()))
                    {
                        case 1:
                            return "Command successfully add";

                        case 0:
                            return "command already exists";

                        default:
                            return "Error to add command";
                    }

                case "remove":
                    String command_remove = command.Substring(command.IndexOf(' ') + 1);
                    if (db.CommandRemove(user_id, command_remove) == 1)
                    {
                        return "Command successfully remove";
                    }
                    else
                    {
                        return "Error to remove Command";
                    }

                case "reset":
                    if (command.Contains('='))
                    {
                        Console.WriteLine(command.Substring(command.IndexOf('=') + 1));
                        int temp = Int32.Parse(command.Substring(command.IndexOf('=') + 1));
                        Console.WriteLine(command.Substring(command.IndexOf(' ') + 1, (command.IndexOf('=') - command.IndexOf(' ') - 1)));
                        if (db.CounterSet(temp, channel, command.Substring(command.IndexOf(' ') + 1, (command.IndexOf('=') - command.IndexOf(' ') - 1))) ==1) 
                        {
                            return "successfully reset"; 
                        } 
                        else 
                        {
                            return "Error to reset";
                        }
                    }
                    else
                    {
                        if (db.CounterSet(0, channel, command.Substring(command.IndexOf(' ') + 1)) == 1)
                        {
                            return "successfully reset";
                        }
                        else
                        {
                            return "Error to reset";
                        }
                    }

                default:
                    return "";
            }
        }
    }
}
