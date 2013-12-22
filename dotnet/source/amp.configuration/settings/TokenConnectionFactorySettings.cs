using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amp.configuration.settings
{
    public class TokenConnectionFactorySettings
    {
        public string AnubisUri
        {
            get
            {
                return ConfigurationManager.AppSettings["AnubisUri"];
            }
        }
    }
}
