using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Test
{
    [TestClass]
    public static class GlobalContext
    {
        //public TestContext TestContext { get; set; }

        public static LeagueClientApi Client = new LeagueClientApi();

        [AssemblyInitialize]
        public static async Task Initialize(TestContext context)
        {
            bool success = await Client.Initialize();
            
            if (!success)
                throw new Exception("Couldn't initialize LeagueClientApi. Is the LeagueClient not running?");
        }
    }
}
