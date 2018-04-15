using Hextech.LeagueClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hextech.ViewModels
{
    public class AuthenticationInfoDialogViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Password { get; }
        public int Port { get; }

        public AuthenticationInfoDialogViewModel(LeagueClientApi leagueClientApi)
        {
            Password = leagueClientApi.Password;
            Port = leagueClientApi.Port;
        }
    }
}
