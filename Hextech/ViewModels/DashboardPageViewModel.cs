using Hextech.LeagueClient;
using System.ComponentModel;

namespace Hextech.ViewModels
{
    public class DashboardPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private LeagueClientApi LeagueClientApi = AppState.LeagueClientApi;
    }
}
