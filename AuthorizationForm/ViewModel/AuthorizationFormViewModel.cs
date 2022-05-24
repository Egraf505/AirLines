using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AuthorizationForm
{
    internal class AuthorizationFormViewModel : INotifyPropertyChanged
    {
        public AuthorizationFormViewModel()
        {
            _login = "Логин";
            _password = "Пароль";
            _rememberUser = false;
        }    
        private string _login;        

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private bool _rememberUser;
        public bool RememberUser
        {
            get { return _rememberUser; }
            set { _rememberUser = value; OnPropertyChanged();}
        }
        private void LogIn()
        {
            if (_rememberUser)
            {

            }
            OpenMain();
        }

        public ICommand OnLogIn
        {
            get
            {
                return new RelayCommand(LogIn);
            }
        }

        public void OpenMain()
        {
            MainForm.MainWindow mainWindow = new();
            mainWindow.Show();
            Application.Current.MainWindow.Close();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
