using Hextech.LeagueClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hextech.ViewModels
{
    public class ChampionsPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> Champions { get; } = new List<string>();
        public string SelectedChampion { get; set; }

        private LeagueClientApi LeagueClientApi;

        public ChampionsPageViewModel(LeagueClientApi leagueClientApi)
        {
            LeagueClientApi = leagueClientApi;

            Champions.Add("Karel");
            Champions.Add("Meneer");
            Champions.Add("Freek");
        }
    }
}
