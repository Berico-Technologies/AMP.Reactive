using cmf.eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amp.rx.eventing
{
    /// <summary>
    /// An AMPere specific implementation of the <see cref="System.IObservable<out T>">System.Observable</see> interface used in reactive extensions.
    /// </summary>
    /// <remarks>By defining this type, other extension methods in the amp.rx namespace can be utilized to gain additional behavior.</remarks>
    /// <typeparam name="TEvent"></typeparam>
    public interface IAmpObservable<TEvent> : IObservable<TEvent>
    {
        /// <summary>
        /// The AMPere event bus used to receive TEvent messages.
        /// </summary>
        IEventBus EventBus { get; }
    }
}
