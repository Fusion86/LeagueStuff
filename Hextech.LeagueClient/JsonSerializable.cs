using Newtonsoft.Json;

namespace Hextech.LeagueClient
{
    public class JsonSerializable
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, LeagueClientApi.JsonSerializerSettings);
        }
    }
}
