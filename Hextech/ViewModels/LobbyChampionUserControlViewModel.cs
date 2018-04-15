using Hextech.LeagueClient.Models.GameData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hextech.ViewModels
{
    class LobbyChampionUserControlViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Champion Champion { get; }

        public LobbyChampionUserControlViewModel(Champion champion)
        {
            Champion = champion;
        }
    }
}
