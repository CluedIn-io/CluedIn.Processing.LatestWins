using CluedIn.Core;
using CluedIn.Crawling.LatestWins.Core;

using ComponentHost;

namespace CluedIn.Crawling.LatestWins
{
    [Component(LatestWinsConstants.CrawlerComponentName, "Crawlers", ComponentType.Service, Components.Server, Components.ContentExtractors, Isolation = ComponentIsolation.NotIsolated)]
    public class LatestWinsCrawlerComponent : CrawlerComponentBase
    {
        public LatestWinsCrawlerComponent([NotNull] ComponentInfo componentInfo)
            : base(componentInfo)
        {
        }
    }
}

