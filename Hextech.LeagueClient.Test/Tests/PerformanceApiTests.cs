using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class PerformanceApiTests
    {
        private LeagueClientApi client = GlobalContext.Client;

        [TestMethod]
        public async Task GetMemoryStatus()
        {
            var obj = await client.Performance.GetMemoryStatus();
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task GetCefReport()
        {
            var obj = await client.Performance.GetCefReport();
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task GetSystemInfo()
        {
            var obj = await client.Performance.GetSystemInfo();
            Assert.IsNotNull(obj);
        }
    }
}
