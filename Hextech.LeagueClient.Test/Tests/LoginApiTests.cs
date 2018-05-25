using Hextech.LeagueClient.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class LoginApiTests
    {
        public TestContext TestContext { get; set; }

        private LeagueClientApi client = GlobalContext.Client;

        [TestMethod]
        public async Task GetSessionNoLogin()
        {
            LeagueClientException exception = null;

            try
            {
                var obj = await client.Login.GetSession();
            }
            catch (LeagueClientException ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception.Message == "No session currently exists, you must initiate a login first.");
        }

        [TestMethod]
        public async Task GetSession()
        {
            var obj = await client.Login.GetSession();
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task GetWallet()
        {
            var obj = await client.Login.GetWallet();
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task GetPlatformCredentials()
        {
            var obj = await client.Login.GetPlatformCredentials();
            Assert.IsNotNull(obj);
        }
    }
}
