using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class GameDataApiTests
    {
        private LeagueClientApi client = GlobalContext.Client;

        [TestMethod]
        public async Task GetChampionSummary()
        {
            var obj = await client.GameData.GetChampionSummary();
            Assert.IsTrue(obj.Count > 0);
        }
    }
}
