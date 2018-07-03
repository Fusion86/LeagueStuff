using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using static Hextech.LeagueClient.Test.Utils;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class ItemSetsApiTests
    {
        public TestContext TestContext { get; set; }

        private LeagueClientApi client = GlobalContext.Client;

        [TestMethod]
        public async Task GetItemSets()
        {
            var summoner = await client.Summoner.GetCurrentSummoner();
            var obj = await client.ItemSets.GetItemSets(summoner.SummonerId);
            JsonPrintAndVerify(obj);
            Assert.IsNotNull(obj);
        }
    }
}
