using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class MatchmakingApiTests
    {
        public TestContext TestContext { get; set; }

        private LeagueClientApi client = GlobalContext.Client;

        [TestMethod]
        public async Task GetReadyCheck()
        {
            var obj = await client.Matchmaking.GetReadyCheck();
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task GetSearchData()
        {
            var obj = await client.Matchmaking.GetSearchData();
            Assert.IsNotNull(obj);
        }
    }
}
