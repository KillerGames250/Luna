using TwitchLib.Client;
using Luna.DataBase;
using Luna.Settings;

namespace Luna.Chat
{
    class Commands
    {
        private Database db = new();
        private BotCommands botCommands = new();
        private GlobalCommands globalCommands = new();
        private StreamersCommands streamersCommands = new();

        public void Command(TwitchClient client, string channel, string display_name, string user_id, string command)
        {
            string mensage = "";
            string user_name = display_name.ToLower();
            if (channel.Equals(ControllerSettings.settings.CredentialsTwitch.User))
            {
                mensage = botCommands.Commands(client, command, user_id, user_name, display_name);
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
            client.SendMessage(channel, TextFormatting.MenssageFormat(mensage, user_name, command, channel));
        }
    }
}