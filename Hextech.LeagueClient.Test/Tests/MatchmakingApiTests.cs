using Hextech.LeagueClient.Exceptions;
using Hextech.LeagueClient.Models.Matchmaking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class MatchmakingApiTests
    {
        private LeagueClientApi client = GlobalContext.Client;

        [TestMethod]
        public async Task GetReadyCheck()
        {
            ReadyCheck obj = null;

            try
            {
                obj = await client.Matchmaking.GetReadyCheck();
            }
            catch (LeagueClientException ex)
            {
                if (ex.Message == "Not attached to a matchmaking queue.")
                    Assert.Inconclusive(ex.Message);
                else
                    throw;
            }

            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task GetSearchData()
        {
            SearchResource obj = null;

            try
            {
                obj = await client.Matchmaking.GetSearchData();
            }
            catch (LeagueClientException ex)
            {
                if (ex.Message == "No matchmaking search exists.")
                    Assert.Inconclusive(ex.Message);
                else
                    throw;
            }

            Assert.IsNotNull(obj);
        }
    }
}
