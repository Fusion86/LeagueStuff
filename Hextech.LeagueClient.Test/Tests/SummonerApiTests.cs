﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class SummonerApiTests
    {
        public TestContext TestContext { get; set; }

        private LeagueClientApi client = GlobalContext.Client;

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
