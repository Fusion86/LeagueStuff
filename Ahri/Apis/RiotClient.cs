using RestSharp;

namespace Ahri.Apis
{
    public class RiotClient : ApiBase
    {
        public RiotClient(LeagueClientApi api) : base(api)
        {

        }

        public string GetAppName()
        {
            RestRequest request = new RestRequest();
            request.Resource = "/riotclient/app-name";
            return _api.Execute(request);
        }
    }
}
