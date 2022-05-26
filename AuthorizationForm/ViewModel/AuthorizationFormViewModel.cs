using DB;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json;

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

            if (_login != null && _password != null)
            {
                User user;

                using (AirFligthsContext context = new AirFligthsContext())
                {
                    user = context.Users.FirstOrDefault(x => x.Login == _login && x.Password == _password)!;
                    if (user != null)
                    {
                        if (_rememberUser)
                        {
                            File.WriteAllText("config.json", JsonConvert.SerializeObject(user));                            
                        }
                        OpenMain(user.Login, user.Password);
                    }
                    else
                    {
                        MessageBox.Show("Не правильный логин или пароль");
                    }
                }
            }
        }


        private void Reg()
        {
            string[] data = { _loginR,  _passwordR,  _firstnameR, _lastnameR };
            if (OnCheck(data))
            {
                User user = new() { Login = _loginR, Password = _passwordR, Firstname = _firstnameR, Lastname = _lastnameR, Middlename = _middlenameR };

                using (AirFligthsContext context = new AirFligthsContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    MessageBox.Show("Регистрация успешна");
                }
            }
            else
            {
                MessageBox.Show("Некоректно ведённые данные");
            }
        }
    
        private bool OnCheck(string[] data)
        {
            foreach (var item in data)
            {
                if (String.IsNullOrEmpty(item))
                {
                    return false;
                }
            }
            return true;
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
        public void OpenMain(string login, string password)
        {
            MainForm.MainWindow mainWindow = new(login, password);
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
