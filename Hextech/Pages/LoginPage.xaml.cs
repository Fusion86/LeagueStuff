using System;
using System.Windows.Controls;

namespace Hextech.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public EventHandler<PasswordPort> OnAuthenticationFound;

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            PasswordPort pp = await vm.GetPasswordPort();
            OnAuthenticationFound(this, pp);
        }
    }
}
