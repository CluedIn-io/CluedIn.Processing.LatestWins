using CluedIn.Core.Crawling;
using CluedIn.Crawling;
using CluedIn.Crawling.LatestWins;
using CluedIn.Crawling.LatestWins.Infrastructure.Factories;
using Moq;
using Shouldly;
using Xunit;

namespace Crawling.LatestWins.Unit.Test
{
    public class LatestWinsCrawlerBehaviour
    {
        private readonly ICrawlerDataGenerator _sut;

        public LatestWinsCrawlerBehaviour()
        {
            var nameClientFactory = new Mock<ILatestWinsClientFactory>();

            _sut = new LatestWinsCrawler(nameClientFactory.Object);
        }

        [Fact]
        public void GetDataReturnsData()
        {
            var jobData = new CrawlJobData();

            _sut.GetData(jobData)
                .ShouldNotBeNull();
        }
    }
}
