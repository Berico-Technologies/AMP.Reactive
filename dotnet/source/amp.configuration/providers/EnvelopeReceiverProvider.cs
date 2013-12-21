using amp.rabbit.transport;
using cmf.bus;
using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amp.configuration.providers
{
    public class EnvelopeReceiverProvider : Provider<IEnvelopeReceiver>
    {
        protected override IEnvelopeReceiver CreateInstance(IContext context)
        {

            return null;
        }
    }
}
