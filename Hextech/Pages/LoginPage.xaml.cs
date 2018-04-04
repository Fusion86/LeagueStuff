using System;
using System.ComponentModel;
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
            // Don't try to grab auth details when in design mode
            if (DesignerProperties.GetIsInDesignMode(this)) return;

            PasswordPort pp = await vm.GetPasswordPort();
            OnAuthenticationFound(this, pp);
        }
    }
}
