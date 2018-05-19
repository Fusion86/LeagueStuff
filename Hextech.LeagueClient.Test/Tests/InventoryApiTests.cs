using Hextech.LeagueClient.Models.Inventory;
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

        [TestMethod]
        public async Task GetInventoryNoType()
        {
            var obj = await client.Inventory.GetInventory(new InventoryType[] { });
            Assert.IsTrue(obj.Count == 0); // No given types means that we don't give a filter in which case the LeagueClient will return 0 items
        }

        [TestMethod]
        public async Task GetInventoryEmoteType()
        {
            var obj = await client.Inventory.GetInventory(new [] { InventoryType.EMOTE });
            Assert.IsTrue(obj.Count > 0); // Everyone has at least the basic thumbs-up emote
        }

        [TestMethod]
        public async Task GetEmotes()
        {
            var obj = await client.Inventory.GetEmotes();
            Assert.IsNotNull(obj);
        }
    }
}
