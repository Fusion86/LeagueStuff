using Ahri.Models;
using Xunit;

namespace Ahri.Tests
{
    public class ApiTests
    {
        [Fact]
        public void GetApiDocs()
        {
            LeagueClientApi api = new LeagueClientApi("", 1234);
            ApiDocs res = api.GetApiDocs();
            Assert.True(res.Apis.Count > 0);
        }

        [Fact]
        public void GetAppName()
        {
            LeagueClientApi api = new LeagueClientApi("", 1234);
            string res = api.RiotClient.GetAppName();
            Assert.True(res == "LeagueClient");
        }
    }
}
