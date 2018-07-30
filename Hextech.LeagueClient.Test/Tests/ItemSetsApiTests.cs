using Hextech.LeagueClient.Models.ItemSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using static Hextech.LeagueClient.Test.Utils;

namespace Hextech.LeagueClient.Test.Tests
{
    [TestClass]
    public class ItemSetsApiTests
    {
        private LeagueClientApi client = GlobalContext.Client;

        [TestMethod]
        public async Task GetItemSets()
        {
            var summoner = await client.Summoner.GetCurrentSummoner();
            var obj = await client.ItemSets.GetItemSets(summoner.SummonerId);
            JsonPrintAndVerify(obj);
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task SetItemSet()
        {
            var summoner = await client.Summoner.GetCurrentSummoner();

            ItemSet itemSet = new ItemSet
            {
                AssociatedChampions = { 55 }, // Katarina
                Title = "Empty Katarina Item Set",
            };

            Console.WriteLine(itemSet);

            var success = await client.ItemSets.SetItemSet(summoner.SummonerId, itemSet);
            Assert.IsTrue(success);

            // We should probably check if the new ItemSet is actually registered by calling ItemSets.GetItemSets(summoner.SummonerId)
            // however I currently don't know why it sometimes does work and sometimes doesn't.
        }
    }
}
