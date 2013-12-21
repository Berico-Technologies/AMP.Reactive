using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using cmf.eventing.patterns.rpc;
using amp.configuration.modules;

namespace amp.configuration
{
    

    public class AmpereConfig
    {
        private IKernel _kernel;

        public AmpereConfig()
        {
            _kernel = new StandardKernel(new EventBusModule());
        }

        public IRpcEventBus EventBus
        {
            get { return _kernel.Get<IRpcEventBus>(); }
        }
    }
}
