using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amp.configuration.settings
{
    public class CommandableCacheSettings
    {
        public int CacheExpiryInSeconds 
        {
            get 
            {
                return Int32.Parse(ConfigurationManager.AppSettings["CacheExpiryInSeconds"]);
            }
        }
    }
}
