using System;
using System.Collections.Generic;
using AutoFixture.Xunit2;
using Xunit;

namespace CluedIn.Provider.LatestWins.Unit.Test.LatestWinsProvider
{
    public static class WebhookManagementEndpoints
    {
        public class FailureCases : LatestWinsProviderTest
        {
            [Theory]
            [InlineData(null)]
            public void NullParameterThrowsArgumentNullException(IEnumerable<string> ids)
            {
                Assert.Throws<ArgumentNullException>(() => Sut.WebhookManagementEndpoints(ids));
            }
        }

        public class PassCases : LatestWinsProviderTest
        {
            [Theory]
            [InlineAutoData]
            public void PublicMethodThrowsNotImplementedException(IEnumerable<string> ids)
            {
                Assert.Throws<NotImplementedException>(() => Sut.WebhookManagementEndpoints(ids));
            }
        }
    }
}
