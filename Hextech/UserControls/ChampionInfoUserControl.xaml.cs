using Bindables;
using Hextech.LeagueClient.Models.GameData;
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

namespace Hextech.UserControls
{
    /// <summary>
    /// Interaction logic for ChampionInfoUserControl.xaml
    /// </summary>
    public partial class ChampionInfoUserControl : UserControl
    {
        [DependencyProperty]
        public Champion Champion { get; set; }

        private ChampionInfoUserControlViewModel vm;

        public ChampionInfoUserControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = vm = new ChampionInfoUserControlViewModel(Champion);
        }
    }
}
