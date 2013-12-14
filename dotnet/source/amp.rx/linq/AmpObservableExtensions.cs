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
        /// <summary>
        /// Bridges the AMPere Event Bus into the .NET Reactive extensions framework by providing extension methods allowing the 
        /// developer to create an IObservable from an instance of the <see cref="cmf.eventing.IEventBus">IEventBus</see>.
        /// </summary>
        /// <remarks>
        /// This extension method is best suited for dealing with the traditional observer pattern in AMPere. 
        /// </remarks>
        /// <para>
        /// To enable the Reactive Extensions for the <see cref="cmf.eventing.IEventBus">IEventBus</see>, add a using statement to 
        /// your code for the amp.rx.linq namespace
        /// </para>
        /// <para>
        /// <code>using amp.rx.linq;</code>
        /// </para>
        /// <para>
        /// From your code, you should now have the ability to call <see cref="AmpObservableExtensions.FromAmpEventPattern">FromAmpEventPattern()</see> as shown:
        /// </para>
        /// <para>
        /// <code>
        /// using amp.rx.linq;
        /// using cmf.eventing;
        /// 
        /// class MyReactiveObject
        /// {
        ///     public MyReactiveObject(IEventBus eventBus)
        ///     {
        ///         //Set up your subscription
        ///         string messageTopic = "mynamespace.Foo";
        ///         IAmpObservable<Foo> fooObservable = eventBus.FromAmpEventPattern<Foo>(messageTopic);
        ///     }
        /// }
        /// </code>
        /// </para>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="eventBus"></param>
        /// <param name="topic"></param>
        /// <returns>An instance of an <see cref="amp.rx.eventing.IAmpObservable">IAmpObservable</see> allowing the developer to subscribe to asynchronously delivered events from the AMPere messaging framework.
        /// 
        /// </returns>
        public static IAmpObservable<TEvent> FromAmpEventPattern<TEvent>(this IEventBus eventBus, string topic)
        {
            //Register a subscriber of TEvent
            AmpObservableEventHandler<TEvent> ampObservableHandler = new AmpObservableEventHandler<TEvent>(eventBus, topic);

            return ampObservableHandler;
        }
    }
}
