using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class SystemApiTests
    {
        private LeagueClientApi client = GlobalContext.Client;

        [TestMethod]
        public async Task GetBuildInfo()
        {
            var obj = await client.System.GetBuildInfo();
            Console.WriteLine("Version: " + obj.Version); // Doesn't work
            Assert.IsNotNull(obj);
        }
    }
}
