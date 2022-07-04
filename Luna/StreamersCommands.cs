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
                        int temp = Int32.Parse(command.Substring(command.IndexOf('=') + 1));
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

                case "createlottery":
                    if (db.CreateLottery(user_id, command.Substring(command.IndexOf(' ') + 1, command.LastIndexOf(' ') - command.IndexOf(' ') - 1), Convert.ToInt32(command.Substring(command.LastIndexOf(' ') + 1))) == 1)
                    {
                        return "Good luck to all";
                    }
                    else
                    {
                        return "Error to create";
                    }

                case "deletelottery":
                    if (db.DeleteLottery(user_id, command.Substring(command.IndexOf(' ') + 1)) == 1)
                    {
                        return "Lottery successfully deletted";
                    }
                    else
                    {
                        return "Error to delete";
                    }

                case "lotterywinner":
                    String aux = db.LotteryWinner(user_id, command.Substring(command.IndexOf(' ') + 1));
                    if (aux != "")
                    {
                        return aux;
                    }
                    else
                    {
                        return "Error to take a winner";
                    }

                default:
                    return "";
            }
        }
    }
}
