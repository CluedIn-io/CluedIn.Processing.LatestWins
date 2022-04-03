using System.Collections.Generic;

using CluedIn.Core.Crawling;
using CluedIn.Crawling.LatestWins.Core;
using CluedIn.Crawling.LatestWins.Infrastructure.Factories;

namespace CluedIn.Crawling.LatestWins
{
    public class LatestWinsCrawler : ICrawlerDataGenerator
    {
        private readonly ILatestWinsClientFactory clientFactory;
        public LatestWinsCrawler(ILatestWinsClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public IEnumerable<object> GetData(CrawlJobData jobData)
        {
            if (!(jobData is LatestWinsCrawlJobData LatestWinscrawlJobData))
            {
                yield break;
            }

            var client = clientFactory.CreateNew(LatestWinscrawlJobData);

            //retrieve data from provider and yield objects
            
        }       
    }
}
