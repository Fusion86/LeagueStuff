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
            string password = context.Properties["password"].ToString();
            int port = int.Parse(context.Properties["port"].ToString());

            bool isLoggedIn = await Client.Login(password, port);
            
            if (!isLoggedIn)
                throw new Exception("Password and/or port is invalid!");
        }
    }
}
