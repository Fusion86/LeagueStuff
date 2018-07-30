using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using static Hextech.LeagueClient.Test.Utils;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class SummonerApiTests
    {
        private LeagueClientApi client = GlobalContext.Client;

        [TestMethod]
        public async Task GetCurrentSummoner()
        {
            var obj = await client.Summoner.GetCurrentSummoner();
            JsonPrintAndVerify(obj);
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task GetSummoner()
        {
            var obj = await client.Summoner.GetSummoner("Fizz sucks");
            JsonPrintAndVerify(obj);
            Assert.IsNotNull(obj);
        }
    }
}
