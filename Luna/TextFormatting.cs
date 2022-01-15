using System;

namespace Luna
{
    class TextFormatting
    {
        public static String CommandFormat(String command)
        {
            if (command.Contains(' '))
            {
                command = command.Substring((command.IndexOf('!') + 1), command.IndexOf(' ') - command.IndexOf('!') - 1);
                command = command.ToLower();
                return command.Trim();
            }
            else
            {
                command = command.Substring(command.IndexOf('!') + 1);
                return command.Trim();
            }
        }

        public static String MenssageFormat(String mensage, String user_name, String command, String channel)
        {
            Database db = new();
            if (mensage.Contains("{user}"))
            {
                mensage = mensage.Replace("{user}", $"@{user_name}");
            }
            if (mensage.Contains("{user2}"))
            {
                String user2 = command.Substring(command.IndexOf(' '));
                mensage = mensage.Replace("{user2}", $"{user2}");
            }
            if (mensage.Contains("{rnum}"))
            {
                Random rng = new();
                int aux = 0;
                aux = Convert.ToInt32(mensage.Substring((mensage.IndexOf('[') + 1), (mensage.IndexOf(']') - mensage.IndexOf('[') - 1)));
                mensage = mensage.Replace(("{rnum}"+$"[{aux}]"), $"{rng.Next(0, aux)}");
            }
            if (mensage.Contains("{count}"))
            {
                if (command.Contains('+'))
                {
                    int temp = Int32.Parse(command.Substring(command.IndexOf('+') + 1));
                    int counter = Int32.Parse(db.CounterGet(channel, CommandFormat(command))) + temp;
                    db.CounterSet(counter, channel, CommandFormat(command));
                    mensage = mensage.Replace("{count}", $"{counter}");
                }
                else
                {
                    int counter = Int32.Parse(db.CounterGet(channel, CommandFormat(command))) + 1;
                    db.CounterSet(counter, channel, CommandFormat(command));
                    mensage = mensage.Replace("{count}", $"{counter}");
                }
            }
            return mensage.Trim();
        }
    }
}
