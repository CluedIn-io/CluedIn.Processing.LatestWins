using System;
using System.Collections.Generic;
using CluedIn.Core.Net.Mail;
using CluedIn.Core.Providers;

namespace CluedIn.Crawling.LatestWins.Core
{
    public class LatestWinsConstants
    {
        public struct KeyName
        {
            public const string ApiKey = nameof(ApiKey);
        }

        // TODO Complete the following section
        // Please see https://cluedin-io.github.io/CluedIn.Documentation/docs/1-Integration/build-integration.html
        public const string CrawlerDescription = "LatestWins is a ... to be completed ...";
        public const string Instructions = "Provide authentication instructions here, if applicable";
        public const IntegrationType Type = IntegrationType.Cloud;
        public const string Uri = "http://www.sampleurl.com"; //Uri of remote tool if applicable

        // To change the icon see embedded resource
        // src\LatestWins.Provider\Resources\cluedin.png
        public const string IconResourceName = "Resources.cluedin.png";

        public static IList<string> ServiceType = new List<string> { "" };
        public static IList<string> Aliases = new List<string> { "" };
        public const string Category = "";
        public const string Details = "";
        public static AuthMethods AuthMethods = new AuthMethods()
        {
            token = new Control[]
            {
        // You can define controls to show in the GUI in order to authenticate with this integration
        //        new Control()
        //        {
        //            displayName = "API key",
        //            isRequired = false,
        //            name = "api",
        //            type = "text"
        //        }
            }
        };


        public const bool SupportsConfiguration = true;
        public const bool SupportsWebHooks = false;
        public const bool SupportsAutomaticWebhookCreation = true;

        public const bool RequiresAppInstall = false;
        public const string AppInstallUrl = null;
        public const string ReAuthEndpoint = null;

        #region Autogenerated constants
        public const string CodeOrigin = "LatestWins";
        public const string ProviderRootCodeValue = "LatestWins";
        public const string CrawlerName = "LatestWinsCrawler";
        public const string CrawlerComponentName = "LatestWinsCrawler";
        public static readonly Guid ProviderId = Guid.Parse("5274dc5d-0532-49cf-946b-1ec8f708da12");
        public const string ProviderName = "LatestWins";

        


        public static readonly ComponentEmailDetails ComponentEmailDetails = new ComponentEmailDetails
        {
            Features = new Dictionary<string, string>
            {
                                       { "Tracking",        "Expenses and Invoices against customers" },
                                       { "Intelligence",    "Aggregate types of invoices and expenses against customers and companies." }
                                   },
            Icon = ProviderIconFactory.CreateConnectorUri(ProviderId),
            ProviderName = ProviderName,
            ProviderId = ProviderId,
            Webhooks = SupportsWebHooks
        };

        public static IProviderMetadata CreateProviderMetadata()
        {
            return new ProviderMetadata
            {
                Id = ProviderId,
                ComponentName = CrawlerName,
                Name = ProviderName,
                Type = Type.ToString(),
                SupportsConfiguration = SupportsConfiguration,
                SupportsWebHooks = SupportsWebHooks,
                SupportsAutomaticWebhookCreation = SupportsAutomaticWebhookCreation,
                RequiresAppInstall = RequiresAppInstall,
                AppInstallUrl = AppInstallUrl,
                ReAuthEndpoint = ReAuthEndpoint,
                ComponentEmailDetails = ComponentEmailDetails
            };
        }
        #endregion
    }
}