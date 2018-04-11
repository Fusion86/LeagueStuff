using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class AssetsApiTests
    {
        public TestContext TestContext { get; set; }

        private LeagueClientApi client = GlobalContext.Client;

        [TestMethod]
        public async Task AssetsGetAsset()
        {
            var obj = await client.Assets.GetAsset("/lol-game-data/assets/v1/champion-icons/1.png");
            Assert.IsNotNull(obj);
        }
    }
}
