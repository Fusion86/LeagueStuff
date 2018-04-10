using Hextech.Models;
using Hextech.Utilities;
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
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        public LoginUserControl()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await Login();
        }

        private async Task Login()
        {
            Progress<string> progress = new Progress<string>();
            progress.ProgressChanged += (sender, e) =>
            {
                vm.Status = e;
            };

            LeagueClientPassport pp = await LeagueClientApiUtilities.GetPassport(progress);

            if (pp != null)
            {
                bool succeeded = await AppState.LeagueClientApi.Login(pp.Password, pp.Port);
            }
        }
    }
}
