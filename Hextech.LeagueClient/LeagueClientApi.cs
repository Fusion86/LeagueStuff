using Hextech.LeagueClient.Apis;
using System.Threading.Tasks;

namespace Hextech.LeagueClient
{
    public class LeagueClientApi
    {
        private LeagueHttpClient client;

        public SystemApi System;
        public ChatApi Chat;
        public SummonerApi Summoner;

        public LeagueClientApi()
        {
            client = new LeagueHttpClient();

            System = new SystemApi(client);
            Chat = new ChatApi(client);
            Summoner = new SummonerApi(client);
        }

        public async Task<bool> Login(string password, int port)
        {
            return await client.Login(password, port);
        }
    }
}
