using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amp.configuration.settings
{
    public class FileBasedCertProviderSettings
    {
        /// <summary>
        /// Path to PKCS12 encoded keystore file (e.g.- cert.pfx)
        /// </summary>
        public string ClientCertFilename
        {
            get
            {
                return ConfigurationManager.AppSettings["ClientCertFilename"];
            }
        }

        /// <summary>
        /// Password to open the PKCS12 keystore file to use the private key for encryption
        /// </summary>
        public string ClientCertPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["ClientCertPassword"];
            }
        }
    }
}
