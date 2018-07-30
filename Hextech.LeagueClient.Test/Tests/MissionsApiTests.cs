using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class MissionsApiTests
    {
        private LeagueClientApi client = GlobalContext.Client;

        [TestMethod]
        public async Task GetMissions()
        {
            var obj = await client.Missions.GetMissions();
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task GetSeries()
        {
            var obj = await client.Missions.GetSeries();
            Assert.IsNotNull(obj);
        }
    }
}
