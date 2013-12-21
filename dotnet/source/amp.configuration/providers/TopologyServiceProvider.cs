using amp.rabbit.topology;
using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amp.configuration.providers
{
    public class TopologyServiceProvider : Provider<ITopologyService>
    {
        protected override ITopologyService CreateInstance(IContext context)
        {
            return null;
        }
    }
}
