using Hextech.LeagueClient.Models.Inventory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Apis
{
    public class InventoryApi : ApiBase
    {
        public override string Name => "lol-inventory";

        public InventoryApi(LeagueHttpClient client) : base(client)
        {

        }

        public async Task<bool> GetInitialConfigurationComplete()
        {
            var res = await m_client.GetAsync(GetUrl("/v1/initial-configuration-complete"));
            var str = await res.Content.ReadAsStringAsync();
            return str == "true";
        }

        public async Task<List<InventoryItem>> GetInventory(IEnumerable<string> types)
        {
            // TODO: Send inventoryTypes as parameter, and possibly list all types
            return await m_client.GetAsync<List<InventoryItem>>(GetUrl("/v1/inventory"));
        }

        public async Task<List<InventoryItem>> GetEmotes()
        {
            return await m_client.GetAsync<List<InventoryItem>>(GetUrl("/v1/inventory/emotes"));
        }
    }
}
