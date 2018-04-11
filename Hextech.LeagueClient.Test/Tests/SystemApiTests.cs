using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class SystemApiTests
    {
        public TestContext TestContext { get; set; }

        private LeagueClientApi client = GlobalContext.Client;

        [TestMethod]
        public async Task SystemGetBuildInfo()
        {
            var obj = await client.System.GetBuildInfo();
            TestContext.WriteLine("Version: " + obj.Version); // Doesn't work
            Assert.IsNotNull(obj);
        }
    }
}
