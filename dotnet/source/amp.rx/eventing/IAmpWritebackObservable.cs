using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amp.rx.eventing
{
    /// <summary>
    /// This interface enables a caller to interact with the AMPere messaging system, by publishing 
    /// serializable objects through <see cref="cmf.eventing.IEventBus">IEventBus</see>
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    public interface IAmpWritebackObservable<TEvent> : IAmpObservable<TEvent>
    {
        /// <summary>
        /// This links amp.rx into the ability to publish events into the AMPere messaging system. 
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="serializableObject">By default, AMPere will attempt to send the message via the <see cref="cmf.eventing.IEventBus">IEventBus</see> as a JSON encoded UTF-8 string.</param>
        void Write<TMessage>(TMessage serializableObject);
    }
}
