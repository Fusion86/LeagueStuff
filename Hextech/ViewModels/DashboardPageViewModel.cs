using Hextech.LeagueClient;
using Hextech.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hextech.ViewModels
{
    public class DashboardPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string SummonerName { get; set; } = "Loading name...";
        public string SummonerIconUri { get; set; }

        public HomePage HomePage { get; private set; }
        public LiveGamePage LiveGamePage { get; private set; }
        public BuildsPage BuildsPage { get; private set; }
        public ChampionsPage ChampionsPage { get; private set; }

        private readonly LeagueClientApi LeagueClientApi;

        public DashboardPageViewModel(LeagueClientApi leagueClientApi)
        {
            LeagueClientApi = leagueClientApi;

            HomePage = new HomePage(leagueClientApi);
            LiveGamePage = new LiveGamePage(leagueClientApi);
            BuildsPage = new BuildsPage(leagueClientApi);
            ChampionsPage = new ChampionsPage(leagueClientApi);

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            Update();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        public async Task Update()
        {
            var summoner = await LeagueClientApi.Summoner.GetCurrentSummoner();
            SummonerName = summoner.DisplayName;
            SummonerIconUri = "http://ddragon.leagueoflegends.com/cdn/8.7.1/img/profileicon/" + summoner.ProfileIconId + ".png"; // FIXME: This could break in the future plus we can probably load this from the LeagueClientApi assets
        }
    }
}
