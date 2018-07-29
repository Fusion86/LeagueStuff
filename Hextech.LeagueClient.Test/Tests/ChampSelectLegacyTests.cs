using Hextech.LeagueClient.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class ChampSelectLegacyTests
    {
        public TestContext TestContext { get; set; }

        private LeagueClientApi client = GlobalContext.Client;

        [TestMethod]
        public async Task GetSessionNotInChampSelect()
        {
            LeagueClientException exception = null;

            try
            {
                var obj = await client.ChampSelectLegacy.GetSession();
            }
            catch (LeagueClientException ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null);
            Assert.IsTrue(exception.Message == "Not in Champ Select");
        }
    }
}
