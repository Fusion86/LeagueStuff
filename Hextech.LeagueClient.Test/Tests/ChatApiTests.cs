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
        public async Task ChatGetConfig()
        {
            var obj = await client.Chat.GetConfig();
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task ChatGetFriends()
        {
            var obj = await client.Chat.GetFriends();
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task ChatGetMe()
        {
            var obj = await client.Chat.GetMe();
            Assert.IsNotNull(obj);
        }
    }
}
