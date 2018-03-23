using Ahri.Models;
using RestSharp;

namespace Ahri.Apis
{
    public class ChampSelect : ApiBase
    {
        public ChampSelect(LeagueClientApi api) : base(api)
        {

        }

        public ChampSelectSession GetSession()
        {
            RestRequest request = new RestRequest();
            request.Resource = "/lol-champ-select/v1/session";
            return _api.Execute<ChampSelectSession>(request);
        }
    }
}
