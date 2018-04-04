using Hextech.LeagueClient;
using Hextech.LeagueClient.Models.System;
using Hextech.Pages;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Hextech.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsLoggedIn { get; set; }

        public Page LoginPage { get; set; }
        public Visibility LoginPageVisibility => IsLoggedIn ? Visibility.Collapsed : Visibility.Visible;
        public Visibility LoginRequiredPageVisibility => IsLoggedIn ? Visibility.Visible : Visibility.Collapsed;

        private LeagueClientApi LeagueClientApi = AppState.LeagueClientApi;

        public MainWindowViewModel()
        {
            #region Login

            LoginPage login = new LoginPage();
            login.OnAuthenticationFound += async (object loginSender, PasswordPort pp) =>
            {
                if (pp != null)
                {
                    IsLoggedIn = await LeagueClientApi.Login(pp.Password, pp.Port);

                    if (IsLoggedIn)
                    {
                        UpdateLeagueVersionString();
                    }
                    else
                    {
                        throw new Exception("Login failed!");
                    }
                }
            };

            LoginPage = login;

            #endregion
        }

        #region Status bar

        public string AppVersionString => "Version: " + Assembly.GetExecutingAssembly().GetName().Version;
        public string LeagueVersionString { get; private set; } = "League of Legends: not connected";

        public async void UpdateLeagueVersionString()
        {
            BuildInfo info = await LeagueClientApi.System.GetBuildInfo();
            LeagueVersionString = "League of Legends: " + info.Version;
        }

        #endregion
    }
}
