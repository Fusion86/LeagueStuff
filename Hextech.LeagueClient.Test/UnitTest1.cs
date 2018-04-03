using Hextech.LeagueClient.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Test
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }

        private static LeagueClientApi client = new LeagueClientApi();

        [AssemblyInitialize]
        public static async Task Initialize(TestContext context)
        {
            string password = context.Properties["password"].ToString();
            int port = int.Parse(context.Properties["port"].ToString());

            bool isLoggedIn = await client.Login(password, port);
            
            if (!isLoggedIn)
                throw new Exception("Password and/or port is invalid!");
        }

        [TestMethod]
        public async Task SystemGetBuildInfo()
        {
            var obj = await client.System.GetBuildInfo();
            TestContext.WriteLine("Version: " + obj.Version); // Doesn't work
            Assert.IsNotNull(obj);
        }

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

        [TestMethod]
        public async Task SummonerGetCurrentSummoner()
        {
            var obj = await client.Summoner.GetCurrentSummoner();
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task SummonerGetSummoner()
        {
            var obj = await client.Summoner.GetSummoner("Fizz sucks");
            Assert.IsNotNull(obj);
        }
    }
}
