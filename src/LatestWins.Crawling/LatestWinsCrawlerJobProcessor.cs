using CluedIn.Crawling.LatestWins.Core;

namespace CluedIn.Crawling.LatestWins
{
    public class LatestWinsCrawlerJobProcessor : GenericCrawlerTemplateJobProcessor<LatestWinsCrawlJobData>
    {
        public LatestWinsCrawlerJobProcessor(LatestWinsCrawlerComponent component) : base(component)
        {
        }
    }
}
