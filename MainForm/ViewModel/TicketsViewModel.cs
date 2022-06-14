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
    internal class TicketsViewModel : INotifyPropertyChanged
    {
        private readonly User _user;

        private ObservableCollection<Tickets> _airLines;
        public ObservableCollection<Tickets> AirLines
        {
            get { return _airLines; }
            set { _airLines = value;  OnPropertyChanged(); }
        }

        private string _cityOupout = "Город отбития";
        public string CityOupout
        {
            get { return _cityOupout; }
            set { _cityOupout = value; OnPropertyChanged(); }
        }

        private string _cityInput = "Город прибития";
        public string CityInput
        {
            get { return _cityInput; }
            set { _cityInput = value; OnPropertyChanged(); }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(); }
        }

        public ICommand OnTransfer
        {
            get
            {
                return new RelayCommand(() => 
                {
                    (CityOupout, CityInput) = (CityInput, CityOupout);
                });
            }
        }

        public ICommand OnSearch
        {
            get => new RelayCommand(() => 
            {
                ShowAirlines();
            });
        }

        private void ShowAirlines()
        {
            if (_cityInput != null && _cityOupout != null)
            {
                using (AirFligthsContext context = new AirFligthsContext())
                {
                    City incity = context.Cities.FirstOrDefault(x => x.Tittle == _cityInput)!;
                    City outcity = context.Cities.FirstOrDefault(x => x.Tittle == _cityOupout)!;

                    DateTime departure = Date;
                    DateTime arrival = departure;
                    arrival = arrival.AddDays(1);

                    List<AirLine> airLines = new List<AirLine>(context.AirLines.Where(x => x.CityArrivalNavigation == incity && x.CityDepartureNavigation == outcity && x.DatetimeDeparture == departure && x.DatetimeArrival == arrival));

                    if (airLines != null)
                    {
                        _airLines.Clear();
                        foreach (AirLine airLine in airLines)
                        {
                            int ticketList = context.Tickets.Count(x => x.IdAirLinesNavigation == airLine && x.IdUser == null);
                            City cityDeparture = context.Cities.FirstOrDefault(x => x.Id == airLine.CityDeparture)!;
                            City cityArrive = context.Cities.FirstOrDefault(x => x.Id == airLine.CityArrival)!;

                            Tickets tickets = new Tickets(_user);

                            tickets.Margin = new Thickness(10, 20, 10, 20);

                            tickets.Number = airLine.Id;
                            tickets.TimeDeparture = airLine.DatetimeDeparture.ToString()!;
                            tickets.TimeArrive = airLine.DatetimeArrival.ToString()!;
                            tickets.CityDeparture = cityDeparture.Tittle;
                            tickets.CityArrive = cityArrive.Tittle;
                            tickets.CountTickets = $"Билетов: {ticketList}";

                            tickets.AddHandler(Tickets.AccesButtonEvent, new RoutedEventHandler(AccessClickHandler));

                            _airLines.Add(tickets);
                        }
                    }
                }
            }
        }

        private void AccessClickHandler(object sender, RoutedEventArgs e)
        {

            ShowAirlines();
            MessageBox.Show("Вы забронировали");
        }

        public TicketsViewModel(User user)
        {
            _user = user;
            _airLines = new ObservableCollection<Tickets>();  
            _date = DateTime.Now;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
