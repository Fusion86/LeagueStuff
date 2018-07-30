using Hextech.LeagueClient.Exceptions;
using Hextech.LeagueClient.Models.ChampSelect;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class ChampSelectTests
    {
        private LeagueClientApi client = GlobalContext.Client;

        [TestMethod]
        public async Task GetSession()
        {

            ChampSelectSession obj = null;

            try
            {
                obj = await client.ChampSelect.GetSession();
            }
            catch (LeagueClientException ex)
            {
                if (ex.Message == "No active delegate")
                    Assert.Inconclusive("Not in Champ Select");
                else
                    throw;
            }

            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task GetSessionNotInChampSelect()
        {
            LeagueClientException exception = null;

            try
            {
                var obj = await client.ChampSelect.GetSession();
            }
            catch (LeagueClientException ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null);
            Assert.IsTrue(exception.Message == "No active delegate");
        }
    }
}
