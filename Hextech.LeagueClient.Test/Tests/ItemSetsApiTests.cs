using Hextech.LeagueClient.Models.ItemSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

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
            var obj = await client.ItemSets.GetItemSets(0);
            Assert.IsNotNull(obj);
        }
    }
}
