using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amp.rx.eventing
{
    public interface IAmpObservable<TEvent> : IObservable<TEvent>
    {
    }
}
