using Castle.Windsor;
using CluedIn.Core;
using CluedIn.Core.Providers;
using CluedIn.Crawling.LatestWins.Infrastructure.Factories;
using Moq;

namespace CluedIn.Provider.LatestWins.Unit.Test.LatestWinsProvider
{
    public abstract class LatestWinsProviderTest
    {
        protected readonly ProviderBase Sut;

        protected Mock<ILatestWinsClientFactory> NameClientFactory;
        protected Mock<IWindsorContainer> Container;

        protected LatestWinsProviderTest()
        {
            Container = new Mock<IWindsorContainer>();
            NameClientFactory = new Mock<ILatestWinsClientFactory>();
            var applicationContext = new ApplicationContext(Container.Object);
            //Sut = new LatestWins.LatestWinsProvider(applicationContext, NameClientFactory.Object);
        }
    }
}
