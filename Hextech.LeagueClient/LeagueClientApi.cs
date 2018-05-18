﻿using Hextech.LeagueClient.Apis;
using System.Threading.Tasks;

namespace Hextech.LeagueClient
{
    public class LeagueClientApi
    {
        public readonly LeagueHttpClient HttpClient;

        public readonly AssetsApi Assets;
        public readonly ChatApi Chat;
        public readonly DataStoreApi DataStore;
        public readonly GameDataApi GameData;
        public readonly MatchmakingApi Matchmaking;
        public readonly MissionsApi Missions;
        public readonly SummonerApi Summoner;
        public readonly SystemApi System;

        public bool IsConnected { get; private set; }

        public LeagueClientApi()
        {
            HttpClient = new LeagueHttpClient();

            Assets = new AssetsApi(HttpClient);
            Chat = new ChatApi(HttpClient);
            DataStore = new DataStoreApi(HttpClient);
            GameData = new GameDataApi(HttpClient);
            Matchmaking = new MatchmakingApi(HttpClient);
            Missions = new MissionsApi(HttpClient);
            Summoner = new SummonerApi(HttpClient);
            System = new SystemApi(HttpClient);
        }

        public async Task<bool> Initialize()
        {
            PasswordPort pp = Utility.GetPasswordPort();
            if (pp == null) return false;
            return IsConnected = await HttpClient.Login(pp.Password, pp.Port);
        }
    }
}
