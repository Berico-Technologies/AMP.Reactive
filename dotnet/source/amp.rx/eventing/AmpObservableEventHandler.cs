using cmf.bus;
using cmf.eventing;
using cmf.eventing.patterns.streaming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amp.rx.eventing
{
    public class AmpObservableEventHandler<TEvent> : IEventHandler, IAmpObservable<StreamingEventItem<TEvent>>
    {
        private static readonly object _lock = new object();
        private readonly List<IObserver<StreamingEventItem<TEvent>>> _observers = new List<IObserver<StreamingEventItem<TEvent>>>();
        private readonly IEventBus _eventBus;
        private readonly string _topic;


        public AmpObservableEventHandler(
            IEventBus eventBus,
            string topic)
        {
            _eventBus = eventBus;
            _eventBus.Subscribe(this);

            _topic = topic;
        }

        #region AMPere IEventHandler Methods
        public object Handle(object ev, IDictionary<string, string> headers)
        {
            TEvent typedEvent = (TEvent)ev;
            StreamingEventItem<TEvent> eventData = new StreamingEventItem<TEvent>(typedEvent, headers);
            _observers.ForEach(obs => obs.OnNext(eventData));
            return null;
        }

        public object HandleFailed(Envelope env, Exception ex)
        {
            _observers.ForEach(obs => obs.OnError(ex));
            return null;
        }

        public string Topic
        {
            get { return _topic; }
        }
        #endregion

        #region Reactive IObservable Methods
        public IDisposable Subscribe(IObserver<StreamingEventItem<TEvent>> observer)
        {
            lock (_lock)
            {
                if (false == _observers.Contains(observer))
                {
                    _observers.Add(observer);
                }
            }

            return new Subscription(_observers, observer);
        }
        #endregion

        private class Subscription : IDisposable
        {
            private readonly List<IObserver<StreamingEventItem<TEvent>>> _subscriptions = new List<IObserver<StreamingEventItem<TEvent>>>();

            private readonly IObserver<StreamingEventItem<TEvent>> _subscriber;

            public Subscription(List<IObserver<StreamingEventItem<TEvent>>> subscriptions, IObserver<StreamingEventItem<TEvent>> subscriber)
            {
                _subscriptions = subscriptions;
                _subscriber = subscriber;
                if (null == subscriptions)
                {
                    throw new ArgumentException("Must supply the list of subscribers");
                }
            }

            public void Dispose()
            {
                if (null != _subscriber && _subscriptions.Contains(_subscriber))
                {
                    _subscriptions.Remove(_subscriber);
                }
            }
        }

        
    }
}
