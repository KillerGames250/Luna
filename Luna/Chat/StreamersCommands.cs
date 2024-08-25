using System;
using Luna.DataBase;

namespace Luna.Chat
{
	class StreamersCommands
	{
		public string Commands(string command, string user_id, string channel)
		{
			Database db = new();
			switch (TextFormatting.CommandFormat(command))
			{
				case "add":
					string command_name = command.Substring(command.IndexOf(' ') + 1, command.IndexOf('=') - command.IndexOf(' ') - 1);
					string command_action = command.Substring(command.IndexOf('=') + 1);
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
					string command_remove = command.Substring(command.IndexOf(' ') + 1);
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
						int temp = int.Parse(command.Substring(command.IndexOf('=') + 1));
						if (db.CounterSet(temp, channel, command.Substring(command.IndexOf(' ') + 1, command.IndexOf('=') - command.IndexOf(' ') - 1)) == 1)
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
					if (db.CreateLottery(user_id, command.Substring(command.IndexOf(' ') + 1, command.LastIndexOf(' ') - command.IndexOf(' ') - 1), Convert.ToInt32(command.Substring(command.LastIndexOf('[') + 1, command.IndexOf(']') - command.LastIndexOf('[') - 1))) == 1)
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
					string aux = db.LotteryWinner(user_id, command.Substring(command.IndexOf(' ') + 1));
					if (aux != "")
					{
						return aux;
					}
					else
					{
						return "Error to take a winner";
					}

				case "addtm":
					if (db.AddTimerMessage(user_id, command.Substring(command.IndexOf(' ') + 1, command.IndexOf('[') - command.IndexOf(' ') - 1), command.Substring(command.IndexOf('[') + 1, command.IndexOf(']') - command.IndexOf('[') - 1), command.Substring(command.IndexOf('=') + 1)) == 1)
					{
						return "Message successfully added";
					}
					else
					{
						return "Error to add the message";
					}

				case "rmtm":
					if (db.RemoveTimerMessage(user_id, command.Substring(command.IndexOf(' ') + 1)) == 1)
					{
						return "Message successfully removed";
					}
					else
					{
						return "Error to remove the message";
					}

				default:
					return "";
			}
		}
	}
}
