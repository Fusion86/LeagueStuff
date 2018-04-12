using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class GameDataTests
    {
        public TestContext TestContext { get; set; }

        private LeagueClientApi client = GlobalContext.Client;

        [TestMethod]
        public async Task GameDataGetChampionSummary()
        {
            var obj = await client.GameData.GetChampionSummary();
            Assert.IsNotNull(obj);
        }
    }
}
