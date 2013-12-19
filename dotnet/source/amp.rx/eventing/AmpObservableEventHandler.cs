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
    public class AmpObservableEventHandler<TEvent> : IEventHandler, IAmpObservable<TEvent>, IAmpWritebackObservable<TEvent>
    {
        private static readonly object _lock = new object();
        private readonly List<IObserver<TEvent>> _observers = new List<IObserver<TEvent>>();
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
            
            _observers.ForEach(obs => obs.OnNext(typedEvent));
           
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
        public IDisposable Subscribe(IObserver<TEvent> observer)
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


        #region IAmpObservable Methods
        public IEventBus EventBus
        {
            get
            {
                return _eventBus;
            }
        }
        #endregion

        private class Subscription : IDisposable
        {
            private readonly List<IObserver<TEvent>> _subscriptions = new List<IObserver<TEvent>>();

            private readonly IObserver<TEvent> _subscriber;

            public Subscription(List<IObserver<TEvent>> subscriptions, IObserver<TEvent> subscriber)
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

        #region IAmpWritebackObservable Methods

        public void Write<TMessage>(TMessage serializableObject)
        {
            _eventBus.Publish(serializableObject);
        }

        #endregion


    }
}
