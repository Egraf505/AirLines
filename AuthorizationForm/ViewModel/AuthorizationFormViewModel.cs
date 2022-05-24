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
            

            _loginR = "Логин";
            _passwordR = "Пароль";
            _firstnameR = "Имя";
        }    
        private string _login = "Логин";        

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        private string _password = "Пароль";

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private bool _rememberUser = false;
        public bool RememberUser
        {
            get { return _rememberUser; }
            set { _rememberUser = value; OnPropertyChanged();}
        }





        private string _loginR = "Логин";
        public string LoginR
        {
            get { return _loginR; }
            set { _loginR = value; OnPropertyChanged(); }
        }

        private string _passwordR = "Пароль";
        public string PasswordR
        {
            set { _passwordR = value;OnPropertyChanged(); }
            get { return _passwordR; }
        }

        private string _firstnameR = "Имя";
        public string FirstnameR
        {
            get { return _firstnameR; }
            set { _firstnameR = value; OnPropertyChanged();}
        }

        private string _lastnameR = "Фамилия";
        public string LastnameR
        {
            get { return _lastnameR; }
            set { _lastnameR = value; OnPropertyChanged();}
        }

        private string _middlenameR = "Отчество";
        public string MiddlenameR
        {
            get { return _middlenameR;}
            set { _middlenameR = value; OnPropertyChanged(); }
        }



        private void LogIn()
        {
            if (_rememberUser)
            {

            }
            OpenMain();
        }


        private void Reg()
        {

        }

        public ICommand OnLogIn
        {
            get
            {
                return new RelayCommand(LogIn);
            }
        }       

        public ICommand OnReg
        {
            get
            {
                return new RelayCommand(Reg);
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
