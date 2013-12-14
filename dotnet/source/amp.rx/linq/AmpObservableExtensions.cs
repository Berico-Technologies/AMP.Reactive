using amp.rx.eventing;
using cmf.bus;
using cmf.eventing;
using cmf.eventing.patterns.streaming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amp.rx.linq
{
    public static partial class AmpObservableExtensions
    {
        
        public static IObservable<StreamingEventItem<TEvent>> FromAmpEventPattern<TEvent>(this IEventBus eventBus, string topic)
        {
            //Register a subscriber of TEvent
            AmpObservableEventHandler<TEvent> ampObservableHandler = new AmpObservableEventHandler<TEvent>(eventBus, topic);

            return ampObservableHandler;
        }
    }
}
