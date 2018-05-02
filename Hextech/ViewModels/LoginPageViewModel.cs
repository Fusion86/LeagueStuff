using Hextech.LeagueClient;
using Hextech.Models;
using Hextech.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hextech.ViewModels
{
    class LoginPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Double ButtonWidth => EnlargeButton ? 700 : 180;
        public string ButtonText { get; set; } = "Login";

        private bool EnlargeButton { get; set; }

        private readonly LeagueClientApi LeagueClientApi;

        public LoginPageViewModel(LeagueClientApi leagueClientApi)
        {
            LeagueClientApi = leagueClientApi;
        }

        public async Task Login()
        {
            EnlargeButton = true;

            Progress<string> progress = new Progress<string>();
            progress.ProgressChanged += (sender, e) =>
            {
                ButtonText = e;
            };

            LeagueClientPassport pp = LeagueClientApiUtilities.GetPassport();

            if (pp != null)
            {
                await LeagueClientApi.Login(pp.Password, pp.Port);
            }
        }
    }
}
