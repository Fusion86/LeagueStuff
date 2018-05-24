using Hextech.LeagueClient.Models.Perks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Apis
{
    public class PerksApi : ApiBase
    {
        public override string Name => "lol-perks";

        public PerksApi(LeagueHttpClient client) : base(client)
        {

        }

        public async Task<List<UIPerk>> GetPerks()
        {
            return await m_client.GetAsync<List<UIPerk>>(GetPluginUrl("/v1/perks"));
        }

        public async Task<List<PerkPage>> GetPerkPages()
        {
            return await m_client.GetAsync<List<PerkPage>>(GetPluginUrl("/v1/pages"));
        }

        public async Task<PerkPage> GetPerkPage(int id)
        {
            return await m_client.GetAsync<PerkPage>(GetPluginUrl("/v1/pages/" + id));
        }

        public async Task<bool> SetPerkPage(PerkPage page)
        {
            string json = JsonConvert.SerializeObject(page, LeagueClientApi.JsonSerializerSettings);
            var res = await m_client.PutAsync(GetPluginUrl("/v1/pages/" + page.Id), new StringContent(json));

            return res.IsSuccessStatusCode;
        }

        public async Task<PerkPage> GetCurrentPage()
        {
            return await m_client.GetAsync<PerkPage>(GetPluginUrl("/v1/currentpage"));
        }

        public async Task<bool> SetCurrentPage(int id)
        {
            StringContent content = new StringContent(id.ToString());

            var res = await m_client.PutAsync(GetPluginUrl("/v1/currentpage"), content);
            return res.IsSuccessStatusCode;
        }
    }
}
