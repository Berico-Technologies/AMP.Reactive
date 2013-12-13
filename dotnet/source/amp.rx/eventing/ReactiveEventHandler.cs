using cmf.bus;
using cmf.eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amp.rx.eventing
{
    public class ReactiveEventHandler<TEvent> : IEventHandler
    {
        private readonly Func<TEvent, IDictionary<string, string>, object> _handle;
        private readonly Func<Envelope, Exception, object> _handleFailed;
        private readonly string _topic;

        public ReactiveEventHandler(Func<TEvent, IDictionary<string, string>, object> handle,
            Func<Envelope, Exception, object> handleFailed,
            string topic)
        {
            _handle = handle;
            _handleFailed = handleFailed;
            _topic = topic;
        }

        public object Handle(TEvent ev, IDictionary<string, string> headers)
        {
            return _handle(ev, headers);
        }

        public object HandleFailed(Envelope env, Exception ex)
        {
            return _handleFailed(env, ex);
        }

        public string Topic
        {
            get { return _topic; }
        }
    }
}
