using Hextech.Dialogs;
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

        public RelayCommand RefreshSummonerCommand { get; }
        public RelayCommand ShowAuthenticationDiagCommand { get; }

        private readonly LeagueClientApi LeagueClientApi;

        public DashboardPageViewModel(LeagueClientApi leagueClientApi)
        {
            LeagueClientApi = leagueClientApi;

            HomePage = new HomePage(leagueClientApi);
            LiveGamePage = new LiveGamePage(leagueClientApi);
            BuildsPage = new BuildsPage(leagueClientApi);
            ChampionsPage = new ChampionsPage(leagueClientApi);

            RefreshSummonerCommand = new RelayCommand(
                async (e) =>
                {
                    await Update();
                },
                (e) =>
                {
                    return LeagueClientApi.IsLoggedIn;
                });

            ShowAuthenticationDiagCommand = new RelayCommand(
                (e) =>
                {
                    new AuthenticationInfoDialog(leagueClientApi).Show();
                },
                (e) =>
                {
                    return true;
                });
        }

        public async Task Update()
        {
            var summoner = await LeagueClientApi.Summoner.GetCurrentSummoner();

            if (summoner != null)
            {
                SummonerName = summoner.DisplayName;
                SummonerIconUri = "http://ddragon.leagueoflegends.com/cdn/8.7.1/img/profileicon/" + summoner.ProfileIconId + ".png"; // FIXME: This could break in the future plus we can probably load this from the LeagueClientApi assets
            }
        }
    }
}
