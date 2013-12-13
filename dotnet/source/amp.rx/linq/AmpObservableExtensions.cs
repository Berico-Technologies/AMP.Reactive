using amp.rx.eventing;
using cmf.bus;
using cmf.eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amp.rx.linq
{
    public partial class AmpObservableExtensions
    {
        public static IObservable<TEvent> FromAmpEventPattern<TEvent>(this IEventBus eventBus, Func<TEvent, IDictionary<string, string>, object> eventHandler, string topic)
        {
            return FromAmpEventPattern<TEvent>(eventBus, eventHandler, topic, null);
        }

        public static IObservable<TEvent> FromAmpEventPattern<TEvent>(this IEventBus eventBus, Func<TEvent, IDictionary<string, string>, object> eventHandler, string topic, Func<Envelope, Exception, object> failedHandler)
        {
            //Register a subscriber of TEvent
            ReactiveEventHandler<TEvent> handler = new ReactiveEventHandler<TEvent>(eventHandler, failedHandler, topic);
            //Add handler
            eventBus.Subscribe(handler);

            return null;
        }
    }
}
