using Ahri.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Ahri.Tests
{
    [TestClass]
    public class ApiTests
    {
        private static LeagueClientApi api;

        [AssemblyInitialize]
        public static void Initialize(TestContext context)
        {
            string password = context.Properties["password"]?.ToString();

            if (password == null) throw new Exception("Password is not set!");

            if (int.TryParse(context.Properties["port"]?.ToString(), out int port) == false)
                throw new Exception("Port is not set!");

            api = new LeagueClientApi(password, port);
        }

        [TestMethod]
        public void GetApiDocs()
        {
            ApiDocs res = api.GetApiDocs();
            Assert.IsTrue(res.Apis.Count > 0);
        }

        [TestMethod]
        public void GetAppName()
        {
            string res = api.RiotClient.GetAppName();
            Assert.IsTrue(res == "LeagueClient");
        }

        [TestMethod]
        public void GetChampSelectSession()
        {
            ChampSelectSession res = api.ChampSelect.GetSession();
            Assert.Fail();
        }
    }
}
