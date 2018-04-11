using Hextech.LeagueClient;
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
    /// Interaction logic for BuildsPage.xaml
    /// </summary>
    public partial class BuildsPage : Page
    {
        //private readonly BuildsPageViewModel vm;

        public BuildsPage(LeagueClientApi leagueClientApi)
        {
            InitializeComponent();

            //DataContext = vm = new BuildsPageViewModel(leagueClientApi);
        }
    }
}
