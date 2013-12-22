using cmf.eventing;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amp.rx.linq;
using amp.rx.eventing;
using System.Reactive.Linq;
using cmf.eventing.patterns.rpc;

namespace SimpleSubscriber
{
    public class NewsFeedReader
    {
        IRpcEventBus _eventBus;

        [Inject]
        public NewsFeedReader(IRpcEventBus eventBus)
        {
            _eventBus = eventBus;
            var newsFeed = _eventBus
                .FromAmpEventPattern<NewsArticle>("someTopic")
                .DistinctUntilChanged();

            newsFeed.Subscribe<NewsArticle>(
                article => Console.WriteLine("This just in! Headline: {0}\r\n Article: {1}", article.Headline, article.Article),
                error => Console.WriteLine("Uh oh!, ran into a hiccup! Error Details: {0}", error.Message),
                () => Console.WriteLine("Sorry folks, wait until the next edition is out!"));
        }
    }
}
