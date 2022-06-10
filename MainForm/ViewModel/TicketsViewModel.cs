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
using System.Windows.Input;

namespace MainForm.ViewModel
{
    internal class TicketsViewModel : INotifyPropertyChanged
    {
        private readonly User _user;

        private ObservableCollection<AirLine> _airLines;
        public ObservableCollection<AirLine> AirLines
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
                            foreach (AirLine airLine in airLines)
                            {
                                List<Ticket> ticketList = new List<Ticket>(context.Tickets.Where(x => x.IdAirLinesNavigation == airLine));
                                _airLines.Add(airLine);
                            }
                        }                        
                    }
                }
            });
        }

        public TicketsViewModel(User user)
        {
            _user = user;
            _airLines = new ObservableCollection<AirLine>();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
