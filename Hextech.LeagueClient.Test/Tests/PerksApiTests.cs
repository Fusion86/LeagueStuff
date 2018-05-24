using Hextech.LeagueClient.Exceptions;
using Hextech.LeagueClient.Models.Perks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class PerksApiTests
    {
        public TestContext TestContext { get; set; }

        private LeagueClientApi client = GlobalContext.Client;

        [TestMethod]
        public async Task GetPerks()
        {
            var obj = await client.Perks.GetPerks();
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task GetPerkPages()
        {
            var obj = await client.Perks.GetPerkPages();
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task GetPerkPage()
        {
            var obj = await client.Perks.GetPerkPage(50);
            Assert.IsTrue(obj.Name == "Resolve: The Colossus"); // Prebuilt pages could change, but for now this works
        }

        [TestMethod]
        public async Task SetPerkPage()
        {
            List<PerkPage> pages = await client.Perks.GetPerkPages();

            PerkPage page = pages.FirstOrDefault(x => x.IsEditable);

            if (page == null) throw new Exception("No editable page available to test");
            else
            {
                string oldName = page.Name;
                page.Name = "Test name";

                bool success = await client.Perks.SetPerkPage(page);
                Assert.IsTrue(success);

                page.Name = oldName;
                await Task.Delay(1000); // Client might be slow, so give it time to catch up. Maybe not needed.

                success = await client.Perks.SetPerkPage(page);
                Assert.IsTrue(success);
            }
        }

        [TestMethod]
        public async Task GetCurrentPage()
        {
            var obj = await client.Perks.GetCurrentPage();
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task SetCurrentPage()
        {
            var obj = await client.Perks.SetCurrentPage(50);
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task SetCurrentPageInvalid()
        {
            LeagueClientException exception = null;

            try
            {
                var obj = await client.Perks.SetCurrentPage(5);
            }
            catch (LeagueClientException ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception.Message == "Perk page not found");
        }

        [TestMethod]
        public async Task GetStyles()
        {
            var obj = await client.Perks.GetStyles();
            Assert.IsNotNull(obj);
        }
    }
}
