using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class InventoryApiTests
    {
        public TestContext TestContext { get; set; }

        private LeagueClientApi client = GlobalContext.Client;

        [TestMethod]
        public async Task GetInitialConfigurationComplete()
        {
            bool obj = await client.Inventory.GetInitialConfigurationComplete();
        }

        //[TestMethod]
        //public async Task GetInventory()
        //{
        //    var obj = await client.Inventory.GetInventory();
        //    Assert.IsNotNull(obj);
        //}

        [TestMethod]
        public async Task GetEmotes()
        {
            var obj = await client.Inventory.GetEmotes();
            Assert.IsNotNull(obj);
        }
    }
}
