using cmf.eventing.patterns.rpc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amp.configuration.tests
{
    [TestFixture]
    public class AmpereConfigTest
    {

        [Test]
        public void TestInjectedBusConfiguration()
        { 
            AmpereConfig config = new AmpereConfig();
            IRpcEventBus eventBus = config.EventBus;
            Assert.IsNotNull(eventBus);
        }
    }
}
