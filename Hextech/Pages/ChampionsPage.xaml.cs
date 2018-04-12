using Hextech.LeagueClient;
using Hextech.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hextech.Pages
{
    /// <summary>
    /// Interaction logic for ChampionsPage.xaml
    /// </summary>
    public partial class ChampionsPage : Page
    {
        private readonly ChampionsPageViewModel vm;

        public ChampionsPage(LeagueClientApi leagueClientApi)
        {
            InitializeComponent();

            DataContext = vm = new ChampionsPageViewModel(leagueClientApi);
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await vm.Load();
        }

        private void AutoCompleteBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AutoCompleteBox box = (AutoCompleteBox)sender;
                if (box.SelectedItem != null)
                {
                    box.Text = "";
                }
            }

            if (e.Key == Key.Escape)
            {
                AutoCompleteBox box = (AutoCompleteBox)sender;
                box.Text = "";
            }
        }
    }
}
