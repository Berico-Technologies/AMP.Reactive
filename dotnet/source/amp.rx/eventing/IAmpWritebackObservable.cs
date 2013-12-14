﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amp.rx.eventing
{
    public interface IAmpWritebackObservable<TEvent> : IAmpObservable<TEvent>
    {
        void WriteBack<T>(T serializableObject);
        void WriteResponseTo<T>(T serializableObject);
    }
}
