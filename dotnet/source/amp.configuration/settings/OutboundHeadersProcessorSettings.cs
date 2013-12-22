using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amp.configuration.settings
{
    public class OutboundHeadersProcessorSettings
    {
        public string AlternateSenderIdentity
        {
            get
            {
                return ConfigurationManager.AppSettings["AlternateSenderIdentity"];
            }
        }
    }
}
