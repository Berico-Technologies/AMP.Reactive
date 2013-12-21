using amp.eventing;
using amp.bus;
using amp.utility.http;
using cmf.bus;
using cmf.eventing.patterns.rpc;
using Ninject.Activation;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amp.rabbit.transport;
using amp.rabbit.topology;
using amp.topology.client;
using amp.utility.http;
using amp.bus.security;
using amp.configuration.settings;
using amp.rabbit;
using amp.utility.serialization;
using Ninject;

namespace amp.configuration.modules
{
    public class EventBusModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFallbackRoutingInfoProvider>().ToMethod(context => CreateFallbackRoutingInfoProvider());
            Bind<ICertificateProvider>().ToMethod(context => CreateFileBasedCertProvider());
            Bind<IRabbitConnectionFactory>().To<CertificateConnectionFactory>();
            Bind<IWebRequestFactory>().To<CertificateWebRequestFactory>();
            Bind<Utf8JsonDeserializer<RoutingInfo>>().ToSelf();
            Bind<IRoutingInfoRetreiver>().ToMethod(context => CreateHttpRoutingInfoRetriever(context));
            Bind<ITopologyService>().To<GlobalTopologyService>();
            Bind<IEnvelopeReceiver>().To<RabbitEnvelopeReceiver>();

            //Bind<IRoutingInfoCache>().ToMethod(context => CreateCommandableCache()
        }

        private DefaultApplicationExchangeProvider CreateFallbackRoutingInfoProvider()
        {
            FallbackRoutingInfoProviderSettings fs = new FallbackRoutingInfoProviderSettings();
            DefaultApplicationExchangeProvider provider = new DefaultApplicationExchangeProvider();
            provider.Hostname = fs.HostName;
            provider.Port = fs.Port;
            return provider;
        }

        private FileBasedCertProvider CreateFileBasedCertProvider()
        { 
            FileBasedCertProviderSettings fs = new FileBasedCertProviderSettings();
            FileBasedCertProvider certProvider = new FileBasedCertProvider(fs.ClientCertFilename, fs.ClientCertPassword);
            return certProvider;
        }

        private HttpRoutingInfoRetreiver CreateHttpRoutingInfoRetriever(IContext context)
        {
            IKernel kernel = context.Kernel;
            IWebRequestFactory webFactory = kernel.Get<IWebRequestFactory>();
            RoutingInfoRetrieverSettings rs = new RoutingInfoRetrieverSettings();
            string urlExpression = rs.UrlExpression;
            Utf8JsonDeserializer<RoutingInfo> deserializer = kernel.Get<Utf8JsonDeserializer<RoutingInfo>>();
            HttpRoutingInfoRetreiver retriever = new HttpRoutingInfoRetreiver(
                webFactory, urlExpression, deserializer);
            return retriever;
        }
    }
}
