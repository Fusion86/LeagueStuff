using Hextech.LeagueClient;
using Hextech.LeagueClient.Models.System;
using Hextech.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hextech.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public LeagueClientApi LeagueClientApi { get; set; }

        public Page Content { get; set; }

        public MainWindowViewModel()
        {
            #region Login

            LoginPage login = new LoginPage();
            login.OnAuthenticationFound += async (object loginSender, PasswordPort pp) =>
            {
                if (pp != null)
                {
                    LeagueClientApi client = new LeagueClientApi();
                    bool isLoggedIn = await client.Login(pp.Password, pp.Port);

                    if (isLoggedIn)
                    {
                        LeagueClientApi = client;
                        UpdateLeagueVersionString();
                    }
                    else
                    {
                        throw new Exception("Login failed!");
                    }
                }
            };

            Content = login;

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
