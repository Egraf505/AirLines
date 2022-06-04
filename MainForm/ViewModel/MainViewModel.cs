using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DB;
using GalaSoft.MvvmLight.Command;
using MainForm.Page;

namespace MainForm.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private System.Windows.Controls.Page _airTicketsPage;
        private System.Windows.Controls.Page _userTicketsPage;
        private System.Windows.Controls.Page _exitPage;

        private User _user;
        public User User
        {
            get { return _user; }
            set { _user = value;  OnPropertyChanged(); }
        }

        private string _name;
        public string Name
        {
            get { return User.Firstname; }
            set { _name = value; OnPropertyChanged();}
        }

        private string _lastname;
        public string LastName
        {
            get { return User.Lastname; }
            set { _lastname = value; OnPropertyChanged();}
        }

        private string _cut;
        public string Cut
        {
            get { return (Name[0].ToString()+LastName[0]).ToUpper(); }
            set { _cut = value; OnPropertyChanged();}
        }

        private System.Windows.Controls.Page _currentPage;
        public System.Windows.Controls.Page CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; OnPropertyChanged();}
        }

        public ICommand ToAirTicketFrame
        {
            get
            {
                return new RelayCommand(() => 
                {
                    CurrentPage = _airTicketsPage;
                });
            }
        }

        public ICommand ToUserTicketFrame
        {
            get
            {
                return new RelayCommand(() =>
                {
                    CurrentPage = _userTicketsPage;
                });
            }
        }

        public ICommand ToExitFrame
        {
            get
            {
                return new RelayCommand(() =>
                {
                    CurrentPage = _exitPage;
                });
            }
        }

        public MainViewModel(string login, string password)
        {
            using(AirFligthsContext contex = new AirFligthsContext())
            {
                _user = contex.Users.FirstOrDefault(u => u.Login == login && u.Password == password)!;
                if (_user == null)
                {
                    MessageBox.Show("Ошибка пользователь отсутсвует");
                    Application.Current.Shutdown();
                }

                _airTicketsPage = new AirTicketsPage(_user!);
                _userTicketsPage = new UserTicketsPage(_user!);
                _exitPage = new ExitPage(_user!);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
