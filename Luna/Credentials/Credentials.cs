using System;
using System.Threading.Tasks;
using TwitchLib.Api;
using TwitchLib.Api.Auth;

namespace Luna.Credentials
{
    internal class Credentials
    {
        public String ID { get; private set; }
        public String Secret { get; private set; }
        public String Refresh { get; private set; }
        public String Token { get; private set; }
        private bool Status { get; set; }

        private TwitchAPI api = new();

        public Credentials(String id, String Secret, String Refresh, String Token)
        {
            this.ID = id;
            this.Secret = Secret;
            this.Refresh = Refresh;
            this.Token = Token;
        }

        protected virtual async Task<bool> CheckTokenValid()
        {
            api.Settings.ClientId = ID;
            ValidateAccessTokenResponse aux = await api.Auth.ValidateAccessTokenAsync(Token);
            if (aux is null)
            {
                Status = false;
            }
            else
            {
                if (aux.ExpiresIn <= 0)
                {
                    Status = false;
                }
                else
                {
                    Status = true;
                }
            }
            return Status;
        }

        protected virtual async Task RefreshToken()
        {
            api.Settings.ClientId = ID;
            RefreshResponse aux = await api.Auth.RefreshAuthTokenAsync(Refresh, Secret, ID);
            Token = aux.AccessToken;
        }

        public virtual void UpdateCredentials()
        {
            try
            {
                CheckTokenValid().Wait();
            }
            catch (Exception)
            {
                Status = false;
            }
            if (!Status)
            {
                RefreshToken().Wait();
            }
        }
    }
}
