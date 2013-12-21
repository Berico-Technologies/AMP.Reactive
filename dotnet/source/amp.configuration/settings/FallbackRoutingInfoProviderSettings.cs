using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amp.configuration.settings
{
    public class FallbackRoutingInfoProviderSettings
    {
        public string HostName {
            get {
                return ConfigurationManager.AppSettings["FallbackHostName"];
            }
        }

        public int Port {
            get {
                return Int32.Parse(ConfigurationManager.AppSettings["FallbackPort"]);
            }
        }
    }
}
