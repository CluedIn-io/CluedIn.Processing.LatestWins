using CluedIn.Crawling.LatestWins.Core;

namespace CluedIn.Crawling.LatestWins.Infrastructure.Factories
{
    public interface ILatestWinsClientFactory
    {
        LatestWinsClient CreateNew(LatestWinsCrawlJobData LatestWinsCrawlJobData);
    }
}
