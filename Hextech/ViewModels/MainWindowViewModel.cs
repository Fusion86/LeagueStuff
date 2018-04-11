using Hextech.LeagueClient;
using Hextech.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hextech.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Page Content {get;set;}

        private readonly LeagueClientApi LeagueClientApi;

        public MainWindowViewModel()
        {
            LeagueClientApi = new LeagueClientApi();
            LeagueClientApi.OnLoggedIn += LeagueClientApi_OnLoggedIn;
            LeagueClientApi.OnLoggedOut += LeagueClientApi_OnLoggedOut;

            Content = new LoginPage(LeagueClientApi);
        }

        private void LeagueClientApi_OnLoggedIn(object sender, EventArgs e)
        {
            Content = new DashboardPage(LeagueClientApi);
        }

        private void LeagueClientApi_OnLoggedOut(object sender, EventArgs e)
        {
            Content = new LoginPage(LeagueClientApi);
        }
    }
}
