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

        public bool ShowLogin { get; set; } = true;

        public Visibility LoginFrameVisibility => ShowLogin ? Visibility.Visible : Visibility.Collapsed;

        public MainWindowViewModel()
        {
            AppState.LeagueClientApi.OnLoggedIn += LeagueClientApi_OnLoggedIn;
        }

        private void LeagueClientApi_OnLoggedIn(object sender, EventArgs e)
        {
            ShowLogin = false;
        }
    }
}
