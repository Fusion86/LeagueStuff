using Hextech.LeagueClient;
using Hextech.LeagueClient.Models.GameData;
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

        public List<Champion> Champions { get; private set; }
        public string SelectedChampion { get; set; }

        private LeagueClientApi LeagueClientApi;

        public ChampionsPageViewModel(LeagueClientApi leagueClientApi)
        {
            LeagueClientApi = leagueClientApi;
        }

        public async Task Load()
        {
            List<Champion> champs = await LeagueClientApi.GameData.GetChampionSummary();
            Champions = champs.Skip(1).ToList(); // Skip the 'None' champion
        }
    }
}
