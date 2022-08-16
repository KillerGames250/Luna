using System;
using System.Collections.Generic;
using Luna.Events;
using Luna.Chat;
using Luna.Credentials;
using Npgsql;

namespace Luna.DataBase
{
    class Database
    {
        private static readonly string addres = $"Host={Config.DB_HOST}; Username={Config.DB_USERNAME}; Database={Config.DB_NAME}; Port={Config.DB_PORT}; Password={Config.DB_PASSWORD};";
        private NpgsqlConnection connection = new(addres);

        private string PG_Read(string SQL)
        {
            string aux = "";
            try
            {
                Console.WriteLine("Start:");
                connection.Open();
                NpgsqlCommand command = new(SQL, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                reader.Read();
                aux = reader.GetValue(0).ToString();
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            connection.Close();
            Console.WriteLine("Done.");
            return aux;
        }

        private List<string> PG_List(string SQL)
        {
            List<string> aux = new();
            try
            {
                Console.WriteLine("Start:");
                connection.Open();
                NpgsqlCommand command = new(SQL, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    aux.Add(reader.GetString(0));
                }
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            connection.Close();
            Console.WriteLine("Done.");
            return aux;
        }

        public List<string> ChannelList()
        {
            List<string> aux = new() { Config.BOT_USERNAME };
            aux.AddRange(PG_List("SELECT channels_list();"));
            return aux;
        }

        public int BotJoin(string user_id, string user_name)
        {
            return Convert.ToInt32(PG_Read($"SELECT bot_join('{user_id}','{user_name}');"));
        }

        public int BotLeave(string user_id)
        {
            return Convert.ToInt32(PG_Read($"SELECT bot_leave('{user_id}');"));
        }

        public int AutoBanEnable(string user_id)
        {
            return Convert.ToInt32(PG_Read($"SELECT auto_ban_enable('{user_id}');"));
        }

        public int AutoBanDisable(string user_id)
        {
            return Convert.ToInt32(PG_Read($"SELECT auto_ban_disable('{user_id}');"));
        }

        public int CommandAdd(string channel_id, string command_name, string command_action)
        {
            return Convert.ToInt32(PG_Read($"SELECT command_add('{channel_id}','{command_name}','{command_action}')"));
        }

        public int CommandRemove(string channel_id, string command_name)
        {
            return Convert.ToInt32(PG_Read($"SELECT command_remove('{channel_id}','{command_name}');"));
        }

        public string CommandGet(string channel_name, string command_name)
        {
            string aux = PG_Read($"SELECT command_get('{channel_name}','{command_name}')");
            return aux;
        }

        public string CommandsList(string channel_name)
        {
            string commandlist = "";
            foreach (string item in PG_List($"SELECT command_list('{channel_name}')"))
            {
                commandlist = commandlist + $" !{item} " + "||";
            }
            return "";
        }

        public void BannedUser(string user_name, string user_id, string channel_id, string channel_name)
        {
            PG_Read($"SELECT ban_user('{user_name}','{user_id}','{channel_id}','{channel_name}');");
        }

        public List<string> BannedUsersList()
        {
            List<string> aux = new(PG_List($"SELECT perma_banneds_users_list()"));
            return aux;
        }

        public List<string> ChannelsWhereAutoBanEnable()
        {
            List<string> aux = new(PG_List($"SELECT channels_where_autoban_enable()"));
            return aux;
        }

        public int CounterSet(int number, string channel_name, string command_name)
        {
            return Convert.ToInt32(PG_Read($"SELECT counter_set('{number}','{channel_name}','{command_name}')"));
        }

        public string CounterGet(string channel, string command_name)
        {
            return PG_Read($"SELECT counter_get('{channel}','{command_name}')");
        }

        public int TranslationEnable(string channel_id, string language)
        {
            return Convert.ToInt32(PG_Read($"SELECT translation_enable('{channel_id}','{language}')"));
        }

        public int TranlationDisable(string channel_id)
        {
            return Convert.ToInt32(PG_Read($"SELECT translation_disable('{channel_id}')"));
        }

        public List<ChannelLanguage> ChannelsWhereTranlationEnable()
        {
            List<ChannelLanguage> aux = new();
            string temp = "";
            try
            {
                Console.WriteLine("Start:");
                connection.Open();
                NpgsqlCommand command = new("SELECT translation_list_channel_language()", connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    temp = reader.GetString(0);
                    ChannelLanguage cl = new(temp.Substring(0, temp.IndexOf('¨')), temp.Substring(temp.IndexOf('¨') + 1, 2));
                    aux.Add(cl);
                }
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            connection.Close();
            Console.WriteLine("Done.");
            return aux;
        }

        public int CreateLottery(string channel_id, string lottery_name, int winners)
        {
            return Convert.ToInt32(PG_Read($"SELECT lottery_create( '{channel_id}', '{lottery_name}', '{winners}' )"));
        }

        public int DeleteLottery(string channel_id, string lottery_name)
        {
            return Convert.ToInt32(PG_Read($"SELECT public.lottery_delete('{channel_id}','{lottery_name}')"));
        }

        public int JoinLottery(string channel_id, string user_name, string lottery_name)
        {
            return Convert.ToInt32(PG_Read($"SELECT lottery_join('{channel_id}','{user_name}','{lottery_name}')")); // ERRO refazer testes função só funciona no banco de dados
        }

        public string LotteryWinner(string user_id, string lottery_name)
        {
            List<string> aux_list = new(PG_List($"SELECT lottery_take_winner('{user_id}', '{lottery_name}')"));
            string aux = "The winners were:";
            Console.WriteLine(aux_list.Count);
            int i = 1;
            foreach (string winner in aux_list)
            {
                aux += $"{i}º {winner}";
                i++;
            }
            return aux;
        }

        public int AddTimerMessage(string channel_id, string timer_name, string timer, string message)
        {
            return Convert.ToInt32(PG_Read($"SELECT timer_message_add('{channel_id}', '{timer_name}', '{timer}', '{message.Trim()}');"));
        }

        public int RemoveTimerMessage(string channel_id, string timer_name)
        {
            return Convert.ToInt32(PG_Read($"SELECT timer_message_remove('{channel_id}', '{timer_name}');"));
        }

        public List<ChannelMessage> TimerMessages(string channel)
        {
            List<ChannelMessage> list = new();
            string temp = "";
            try
            {
                Console.WriteLine("Start:");
                connection.Open();
                NpgsqlCommand command = new($"SELECT timer_message('{channel}')", connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    temp = reader.GetString(0);
                    ChannelMessage aux = new(temp.Substring(0, temp.IndexOf('¨')), Convert.ToInt32(temp.Substring(temp.IndexOf('¨') + 1, temp.LastIndexOf('¨') - (temp.IndexOf('¨') + 1))), temp.Substring(temp.LastIndexOf('¨') + 1));
                    list.Add(aux);
                }
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            connection.Close();
            Console.WriteLine("Done.");
            return list;
        }
    }
}