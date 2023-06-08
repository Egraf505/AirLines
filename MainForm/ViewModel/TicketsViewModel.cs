using DB;
using DB.Model;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
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

        private DateTime _dateInput;
        public DateTime DateInput
        {
            get { return _dateInput; }
            set { _dateInput = value; OnPropertyChanged(); }
        }

        private DateTime _dateOutput;
        public DateTime DateOutput
        {
            get { return _dateOutput; }
            set { _dateOutput = value; OnPropertyChanged(); }
        }

        private ObservableCollection<TypeOfPlan> _typeOfPlans; 
        public ObservableCollection<TypeOfPlan> TypeOfPlans
        {
            get { return _typeOfPlans; }
            set { _typeOfPlans = value; OnPropertyChanged(); }
        }

        private TypeOfPlan _selectedTypeOfPlan;
        public TypeOfPlan SelectedTypeOfPlan
        {
            get { return _selectedTypeOfPlan; }
            set { _selectedTypeOfPlan = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Dinner> _dinners;
        public ObservableCollection<Dinner> Dinners
        {
            get { return _dinners; }
            set { _dinners = value; OnPropertyChanged(); }
        }

        private Dinner _selectedDinner;
        public Dinner SelectedDinner
        {
            get { return _selectedDinner; }
            set { _selectedDinner = value; OnPropertyChanged(); }
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
            try
            {
                if (_cityInput != null && _cityOupout != null)
                {
                    using (AirFligthsContext context = new AirFligthsContext())
                    {
                        City incity = context.Cities.FirstOrDefault(x => x.Tittle == _cityInput)!;
                        City outcity = context.Cities.FirstOrDefault(x => x.Tittle == _cityOupout)!;

                        DateTime departure = DateOutput;
                        DateTime arrival = DateInput;

                        var typeOfPlan = SelectedTypeOfPlan;
                        var dinner = SelectedDinner;

                        var airLines = context.AirLines.Include(x => x.Tickets).Where(
                            x => x.CityArrivalNavigation == incity && x.CityDepartureNavigation == outcity
                            && x.DatetimeDeparture == departure && x.DatetimeArrival == arrival
                            ).ToList();

                        if (airLines != null)
                        {
                            _airLines.Clear();
                            foreach (AirLine airLine in airLines)
                            {
                                var ticketList = context.Tickets.Where(
                                    x => x.IdAirLines == airLine.Id
                                    && x.IdUserNavigation == null
                                    && x.Dinner == SelectedDinner
                                    && x.TypeOfPlan == SelectedTypeOfPlan).Select(x => new { x.Id, x.Dinner, x.TypeOfPlan}).ToList();

                                City cityDeparture = context.Cities.FirstOrDefault(x => x.Id == airLine.CityDeparture)!;
                                City cityArrive = context.Cities.FirstOrDefault(x => x.Id == airLine.CityArrival)!;

                                Tickets ticket = new Tickets(_user);

                                ticket.Margin = new Thickness(10, 20, 10, 20);

                                ticket.Number = airLine.Id;
                                ticket.TimeDeparture = airLine.DatetimeDeparture!.Value.Date.ToString();
                                ticket.TimeArrive = airLine.DatetimeArrival!.Value.Date.ToString();
                                ticket.CityDeparture = cityDeparture.Tittle;
                                ticket.CityArrive = cityArrive.Tittle;
                                ticket.CountTickets = $"Билетов: {ticketList.Count}";
                                ticket.Dinner = ticketList.Select(x => x.Dinner.Title).FirstOrDefault();
                                ticket.TypePfPlan = ticketList.Select(x => x.TypeOfPlan.Title).FirstOrDefault();

                                ticket.AddHandler(Tickets.AccesButtonEvent, new RoutedEventHandler(AccessClickHandler)); 

                                _airLines.Add(ticket);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получение билетов");
            }
        }

        private void AccessClickHandler(object sender, RoutedEventArgs e)
        {
            ShowAirlines();
        }

        public TicketsViewModel(User user)
        {
            _user = user;
            _airLines = new ObservableCollection<Tickets>();  
            _dateInput = DateTime.Now;
            _dateOutput = DateTime.Now.AddDays(2);

            using (AirFligthsContext context = new AirFligthsContext())
            {
                _typeOfPlans = new ObservableCollection<TypeOfPlan>(context.TypeOfPlans.ToList());
                _dinners = new ObservableCollection<Dinner>(context.Dinners.ToList());
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
