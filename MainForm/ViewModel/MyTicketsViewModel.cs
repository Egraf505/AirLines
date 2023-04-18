using DB;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MainForm.ViewModel
{
    internal class MyTicketsViewModel : INotifyPropertyChanged
    {
        private User _user;

        private ObservableCollection<UserTicket> _userTickets;
        public ObservableCollection<UserTicket> UserTickets
        {
            get { return _userTickets; }
            set { _userTickets = value; OnPropertyChanged(); }
        }        

        public void ShowUserTickets()
        {
            _userTickets.Clear();
            List<AirLine> airLines = new List<AirLine>();
            using (AirFligthsContext context = new AirFligthsContext())
            {
                List<Ticket> tickets = new List<Ticket>(context.Tickets.Where(x => x.IdUserNavigation == _user));                
                foreach (Ticket ticket in tickets)
                {
                    AirLine airLine = context.AirLines.FirstOrDefault(x => x.Id == ticket.IdAirLines)!;
                    if (airLine != null)
                    {
                        airLines.Add(airLine);
                    }
                }

                foreach (AirLine airline in airLines)
                {
                    UserTicket userTicket = new UserTicket(_user);

                    userTicket.Margin = new Thickness(10, 20, 10, 20);

                    userTicket.Number = airline.Id;
                    userTicket.DatetimeDeparture = airline.DatetimeDeparture!.Value.ToShortDateString();
                    userTicket.DatetimeArrive = airline.DatetimeArrival!.Value.ToShortDateString();
                    userTicket.CityArrive = context.Cities.FirstOrDefault(x => x.Id == airline.CityArrival)!.Tittle;
                    userTicket.CityDeparture = context.Cities.FirstOrDefault(x => x.Id == airline.CityDeparture)!.Tittle;
                    userTicket.AddHandler(UserTicket.CancelEvent, new RoutedEventHandler(Cancelhandler));

                    _userTickets.Add(userTicket);
                }
            }           
        }

        public ICommand OnUpdate
        {
            get { return new RelayCommand(() => 
            {
                ShowUserTickets();
            }); }
        }

        private void Cancelhandler(object sender, RoutedEventArgs e)
        {
            ShowUserTickets();
        }

        public MyTicketsViewModel(User user)
        {
            _userTickets = new ObservableCollection<UserTicket>();
            _user = user;
            ShowUserTickets();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
