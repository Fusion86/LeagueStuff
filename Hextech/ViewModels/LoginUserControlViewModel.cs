using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hextech.ViewModels
{
    public class LoginUserControlViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Status { get; set; } = "Press login to connect to the League of Legends client";
        public bool IsLoggingIn { get; set; }

        public Visibility LoginButtonVisibility => !IsLoggingIn ? Visibility.Visible : Visibility.Hidden;
    }
}
