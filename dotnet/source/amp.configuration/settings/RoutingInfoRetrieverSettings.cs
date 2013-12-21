using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amp.configuration.settings
{
    public class RoutingInfoRetrieverSettings
    {
        public string UrlExpression {
            get {
                return ConfigurationManager.AppSettings["RoutingInfoUrlExpression"];
            }
        }
    }
}
