using System;
using System.Threading.Tasks;
using TwitchLib.Api;
using TwitchLib.Api.Auth;

namespace Luna.Credentials
{
    internal abstract class Credentials
    {
        public String ID { get; private set; }
        public String Secret { get; private set; }
        public String Refresh { get; private set; }
        public String Token { get; private set; }
        private TwitchAPI api = new();

        public Credentials(String id, String Secret, String Refresh, String Token)
        {
            this.ID = id;
            this.Secret = Secret;
            this.Refresh = Refresh;
            this.Token = Token;
        }

        public async virtual Task<bool> IsTokenValid()
        {
            api.Settings.ClientId = ID;
            ValidateAccessTokenResponse aux = await api.Auth.ValidateAccessTokenAsync(Token);
            if (aux.ExpiresIn <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public virtual async Task RefreshToken()
        {
            api.Settings.ClientId = ID;
            RefreshResponse aux = await api.Auth.RefreshAuthTokenAsync(Refresh, Secret, ID);
            Token = aux.AccessToken;
        }
    }
}
