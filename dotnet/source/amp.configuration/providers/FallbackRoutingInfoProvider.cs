using amp.configuration.settings;
using amp.topology.client;
using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amp.configuration.providers
{
    public class FallbackRoutingInfoProvider : Provider<IFallbackRoutingInfoProvider>
    {
        protected override IFallbackRoutingInfoProvider CreateInstance(IContext context)
        {
            FallbackRoutingInfoProviderSettings settings = new FallbackRoutingInfoProviderSettings();
            DefaultApplicationExchangeProvider routingInfoProvider = new DefaultApplicationExchangeProvider();
            routingInfoProvider.Hostname = settings.HostName;
            routingInfoProvider.Port = Int32.Parse(settings.Port);
            return routingInfoProvider;
        }
    }
}
