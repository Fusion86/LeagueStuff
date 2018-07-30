using Hextech.LeagueClient.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class PlayerBehaviorApiTests
    {
        // All tests assume that you are not banned

        private LeagueClientApi client = GlobalContext.Client;

        [TestMethod]
        public async Task GetBan()
        {
            LeagueClientException exception = null;

            try
            {
                var obj = await client.PlayerBehavior.GetBan();
            }
            catch (LeagueClientException ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception.Message == "Not found");
        }

        [TestMethod]
        public async Task GetChatRestriction()
        {
            LeagueClientException exception = null;

            try
            {
                var obj = await client.PlayerBehavior.GetChatRestriction();
            }
            catch (LeagueClientException ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception.Message == "Not found");
        }

        [TestMethod]
        public async Task GetRankedRestriction()
        {
            LeagueClientException exception = null;

            try
            {
                var obj = await client.PlayerBehavior.GetRankedRestriction();
            }
            catch (LeagueClientException ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception.Message == "Not found");
        }

        [TestMethod]
        public async Task GetConfig()
        {
            var obj = await client.PlayerBehavior.GetConfig();
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task GetReformCard()
        {
            LeagueClientException exception = null;

            try
            {
                var obj = await client.PlayerBehavior.GetReformCard();
            }
            catch (LeagueClientException ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception.Message == "Not found");
        }

        [TestMethod]
        public async Task GetReporterFeedback()
        {
            var obj = await client.PlayerBehavior.GetReporterFeedback();
        }
    }
}
