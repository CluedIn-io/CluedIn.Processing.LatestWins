using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using CluedIn.Core.Crawling;
using CluedIn.Core.Providers;
using CluedIn.Crawling.LatestWins.Core;
using Xunit;

namespace CluedIn.Provider.LatestWins.Unit.Test.LatestWinsProvider
{
    public class GetCrawlJobDataBehaviour : LatestWinsProviderTest
    {
        private readonly ProviderUpdateContext _context;

        public GetCrawlJobDataBehaviour()
        {
            _context = null;
        }

        [Theory]
        [InlineAutoData]
        public async Task ReturnsData(Dictionary<string, object> dictionary, Guid organizationId, Guid userId, Guid providerDefinitionId)
        {
            Assert.NotNull(
                await Sut.GetCrawlJobData(_context, dictionary, organizationId, userId, providerDefinitionId));
        }

        [Theory]
        [InlineAutoData(LatestWinsConstants.KeyName.ApiKey, nameof(LatestWinsCrawlJobData.ApiKey))]
        public async Task InitializesProperties(string key, string propertyName, string sampleValue, Guid organizationId, Guid userId, Guid providerDefinitionId)
        {
            var dictionary = new Dictionary<string, object>()
            {
                [key] = sampleValue
            };

            var sut = await Sut.GetCrawlJobData(_context, dictionary, organizationId, userId, providerDefinitionId);
            Assert.Equal(sampleValue, sut.GetType().GetProperty(propertyName).GetValue(sut));
        }

        [Theory]
        [InlineAutoData]
        public async Task LatestWinsCrawlJobDataReturned(Dictionary<string, object> dictionary, Guid organizationId, Guid userId, Guid providerDefinitionId)
        {
            Assert.IsType<CluedIn.Crawling.LatestWins.Core.LatestWinsCrawlJobData>(
                await Sut.GetCrawlJobData(_context, dictionary, organizationId, userId, providerDefinitionId));
        }
    }
}
