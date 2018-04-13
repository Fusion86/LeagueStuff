using Hextech.LeagueClient.Models.GameData;
using System.ComponentModel;

namespace Hextech.ViewModels
{
    public class ChampionInfoUserControlViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Champion Champion { get; }

        public ChampionInfoUserControlViewModel(Champion champion)
        {
            Champion = champion;
        }
    }
}
