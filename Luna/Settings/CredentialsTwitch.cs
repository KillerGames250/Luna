using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna.Settings
{
    internal class CredentialsTwitch
    {
        public string User { get; set; }
        public string ChatID { get; set; }
        public string ChatToken { get; set; }
        public string ChatSecret { get; set; }
        public string ChatRefresh { get; set; }
        public string MonitorID { get; set; }
        public string MonitorToken { get; set; }
        public string MonitorSecret { get; set; }
        public string MonitorRefresh { get; set; }
    }
}
