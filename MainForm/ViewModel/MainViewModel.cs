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
using MainForm.Pages;

namespace MainForm.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private Page _airTicketsPage;
        private Page _userTicketsPage;
        private Page _historyOfTicektPage;

        private User _user;
        public User User
        {
            get { return _user; }
            set { _user = value;  OnPropertyChanged(); }
        }

        public string Name
        {
            get { return User.Firstname; }
        }

        public string LastName
        {
            get { return User.Lastname; }            
        }

        public string Cut
        {
            get { return (Name[0].ToString()+LastName[0]).ToUpper(); }
        }

        private Page _currentPage;
        public Page CurrentPage
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

        public ICommand ToHistoryOfTicketFrame
        {
            get
            {
                return new RelayCommand(() =>
                {
                    CurrentPage = _historyOfTicektPage;
                });
            }
        }

        public ICommand ToExitFrame
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Application.Current.Shutdown();
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
                _historyOfTicektPage = new HistoryOfTicketPage(_user!);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
