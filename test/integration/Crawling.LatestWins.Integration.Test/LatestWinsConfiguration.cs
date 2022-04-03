using System.Collections.Generic;
using CluedIn.Crawling.LatestWins.Core;

namespace CluedIn.Crawling.LatestWins.Integration.Test
{
  public static class LatestWinsConfiguration
  {
    public static Dictionary<string, object> Create()
    {
      return new Dictionary<string, object>
            {
                { LatestWinsConstants.KeyName.ApiKey, "demo" }
            };
    }
  }
}
