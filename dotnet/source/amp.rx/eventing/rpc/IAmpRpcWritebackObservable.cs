using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amp.rx.eventing.rpc
{
    public interface IAmpRpcWritebackObservable<TEvent> : IAmpObservable<TEvent>
    {
        /// <summary>
        /// This enables the developer to respond back on an exlusively created message queue. 
        /// </summary>
        /// <remarks>
        /// This is the way that an asynchronous messaging system, like AMPere, can simluate a traditional request/response exchange between two specific endpoints. 
        /// This is in contrast to the <see cref="amp.rx.eventing.IAmpWritebackObservable.Write"/>IAmpWritebackObservable.Write()</see> method which publishes events 
        /// that can be seen by anyone subscribing to them.
        /// </remarks>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="serializableObject">By default, AMPere will attempt to send the message via the <see cref="cmf.eventing.IEventBus">IEventBus</see> as a JSON encoded UTF-8 string.</param>
        /// <param name="headers">Metadata in the form of key/value pairs that will be published with the serializableObject.
        /// <para>
        /// Note: The original headers received in the <see cref="cmf.eventing.patterns.streaming.StreamingEventItem.EventHeaders">StreamingEventItem.EventHeaders</see> property should be included to ensure proper routing of the response.
        /// </para>
        /// </param>
        void RespondWith<TResponse>(TResponse serializableObject, IDictionary<string, string> headers);
    }
}
