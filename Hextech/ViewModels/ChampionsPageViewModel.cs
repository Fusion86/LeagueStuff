using Hextech.LeagueClient;
using Hextech.LeagueClient.Models.GameData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hextech.ViewModels
{
    public class ChampionsPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region AutoCompleteBox

        public List<Champion> Champions { get; private set; }
        public string SelectedChampion { get; set; }

        #endregion AutoCompleteBox

        public ObservableCollection<Champion> ChampionPages { get; } = new ObservableCollection<Champion>();
        public Champion SelectedPage { get; set; }

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

        // TODO: Make commands for this
        public void AddTab(Champion champion)
        {
            if (!ChampionPages.Contains(champion))
            {
                ChampionPages.Add(champion);
                SelectedPage = champion;
            }
        }

        public void RemoveTab(Champion champion)
        {
            ChampionPages.Remove(champion);
        }
    }
}
