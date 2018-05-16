using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class ChatApiTests
    {
        public TestContext TestContext { get; set; }

        private LeagueClientApi client = GlobalContext.Client;

        [TestMethod]
        public async Task GetConfig()
        {
            var obj = await client.Chat.GetConfig();
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task GetFriends()
        {
            var obj = await client.Chat.GetFriends();
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task GetMe()
        {
            var obj = await client.Chat.GetMe();
            Assert.IsNotNull(obj);
        }
    }
}
