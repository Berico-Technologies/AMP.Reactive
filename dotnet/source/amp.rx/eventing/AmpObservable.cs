using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amp.rx.eventing
{
    public class AmpObservable<TEvent> : IObservable<TEvent>
    {
        public IDisposable Subscribe(IObserver<TEvent> observer)
        {
            throw new NotImplementedException();
        }
    }
}
