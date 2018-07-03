using Hextech.LeagueClient.Models.ItemSets;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Apis
{
    public class ItemSetsApi : ApiBase
    {
        public override string Name => "lol-item-sets";

        public ItemSetsApi(LeagueHttpClient client) : base(client)
        {
        }

        /// <summary>
        /// Get ItemSets
        /// </summary>
        /// <param name="summonerId">Probably unused, seems to always return the current logged in user's item sets</param>
        /// <returns></returns>
        public async Task<ItemSetsCollection> GetItemSets(long summonerId)
        {
            return await m_client.GetAsync<ItemSetsCollection>(GetPluginUrl($"/v1/item-sets/{summonerId}/sets"));
        }

        /// <summary>
        /// Doesn't actually work?
        /// </summary>
        /// <param name="summonerId">Probably unused</param>
        /// <param name="itemSet">Uid will be automatically generated</param>
        /// <returns></returns>
        public async Task<bool> SetItemSet(long summonerId, ItemSet itemSet)
        {
            StringContent content = new StringContent(itemSet.ToString());

            var res = await m_client.PostAsync(GetPluginUrl($"/v1/item-sets/{summonerId}/sets"), content);
            return res.IsSuccessStatusCode;
        }
    }
}
