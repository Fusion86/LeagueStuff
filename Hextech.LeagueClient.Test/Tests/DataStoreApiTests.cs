using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class DataStoreApiTests
    {
        public TestContext TestContext { get; set; }

        private LeagueClientApi client = GlobalContext.Client;

        [TestMethod]
        public async Task GetInstallDir()
        {
            string obj = await client.DataStore.GetInstallDir();
            Assert.IsTrue(obj.Length > 0);
        }
    }
}
