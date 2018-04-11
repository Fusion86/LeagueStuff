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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly LoginPageViewModel vm;

        public LoginPage(LeagueClientApi leagueClientApi)
        {
            InitializeComponent();

            DataContext = vm = new LoginPageViewModel(leagueClientApi);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await vm.Login();
        }
    }
}
