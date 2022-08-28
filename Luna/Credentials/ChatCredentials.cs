using System;
using System.Threading.Tasks;

namespace Luna.Credentials
{
    internal class ChatCredentials : Credentials
    {
        public String UserName { get; private set; }
        public ChatCredentials() : base(Config.API_CHAT_ID, Config.API_CHAT_SECRET, Config.API_CHAT_REFRESH, Config.API_CHAT_TOKEN)
        {
            this.UserName = Config.BOT_USERNAME;
        }
    }
}
