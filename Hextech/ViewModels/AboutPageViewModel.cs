using Hextech.LeagueClient;
using System.ComponentModel;

namespace Hextech.ViewModels
{
    public class AboutPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private LeagueClientApi LeagueClientApi = AppState.LeagueClientApi;
    }
}
