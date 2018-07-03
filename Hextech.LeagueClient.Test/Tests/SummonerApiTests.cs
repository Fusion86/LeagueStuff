using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class SummonerApiTests
    {
        public TestContext TestContext { get; set; }

        private LeagueClientApi client = GlobalContext.Client;

        [TestMethod]
        public async Task GetCurrentSummoner()
        {
            var obj = await client.Summoner.GetCurrentSummoner();
            Console.WriteLine(obj.ToString());
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task GetSummoner()
        {
            var obj = await client.Summoner.GetSummoner("Fizz sucks");
            Console.WriteLine(obj.ToString());
            Assert.IsNotNull(obj);
        }
    }
}
