using Hextech.LeagueClient.Models.ItemSets;
using System.Collections.Generic;
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
    }
}
