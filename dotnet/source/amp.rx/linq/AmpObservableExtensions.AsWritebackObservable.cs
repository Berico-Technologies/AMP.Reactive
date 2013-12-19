using amp.rx.eventing;
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

        public static IAmpWritebackObservable<TEvent> WithWriteback<TEvent>(this IAmpObservable<TEvent> ampObservable)
        {
            IEventBus eventBus = ampObservable.EventBus;
            string topic = ampObservable.Topic;

            if (ampObservable is IAmpWritebackObservable<TEvent>)
            {
                return ampObservable as IAmpWritebackObservable<TEvent>;
            }
            else
            {
                AmpObservableEventHandler<TEvent> ampWritebackObservable = new AmpObservableEventHandler<TEvent>(eventBus, topic);
                return ampWritebackObservable;
            }
        }
    }
}
