using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna.Settings
{
    internal class Settings
    {
        public CredentialsDatabase CredentialsDatabase { get; set; }
        public CredentialsTwitch CredentialsTwitch { get; set; }
        public string BanTimer { get; set; }
    }
}
