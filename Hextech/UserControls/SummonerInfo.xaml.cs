using Hextech.LeagueClient.Models.Summoner;
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
    /// Interaction logic for SummonerInfo.xaml
    /// </summary>
    public partial class SummonerInfo : UserControl
    {
        public SummonerInfo(Summoner summoner)
        {
            InitializeComponent();
        }
    }
}
