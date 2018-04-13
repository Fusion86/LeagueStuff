using Hextech.LeagueClient;
using Hextech.ViewModels;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        private readonly DashboardPageViewModel vm;

        public DashboardPage(LeagueClientApi leagueClientApi)
        {
            InitializeComponent();

            DataContext = vm = new DashboardPageViewModel(leagueClientApi);
        }

        private void txtHome_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tabControl.SelectedIndex = 0;
        }

        private void txtLiveGame_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void txtBuilds_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tabControl.SelectedIndex = 2;
        }

        private void txtChampions_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tabControl.SelectedIndex = 3;
        }

        private async void Ellipse_MouseUp(object sender, MouseButtonEventArgs e)
        {
            await vm.Update();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await vm.Update();
        }
    }
}
