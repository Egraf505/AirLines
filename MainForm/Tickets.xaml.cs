using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainForm
{
    /// <summary>
    /// Логика взаимодействия для Tickets.xaml
    /// </summary>
    public partial class Tickets : UserControl
    {
        public Tickets()
        {
            InitializeComponent();
        }

        public int Number
        {
            get { return (int)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        public string TimeArrive
        {
            get { return (string)GetValue(TimeArriveProperty); }
            set { SetValue(TimeArriveProperty, value); }
        }

        public string TimeDeparture
        {
            get { return (string)GetValue(TimeDepartureProperty); }
            set { SetValue(TimeDepartureProperty, value); }
        }
        public string DateArrive
        {
            get { return(string)GetValue(DateArriveProperty);}
            set { SetValue(DateArriveProperty,value); }
        }
        public string DateDeparture
        {
            get { return (string)GetValue(DateDepartureProperty); }
            set { SetValue(DateDepartureProperty, value); }
        }

        public string CityArrive
        {
            get { return (string)GetValue(CityArriveProperty); }
            set { SetValue(CityArriveProperty, value); }
        }
        public string CityDeparture
        {
            get { return (string)GetValue(CityDepartureProperty); }
            set { SetValue(CityDepartureProperty, value); }
        }
        public string CountTickets
        {
            get { return (string)GetValue(CountTicketsProperty); }
            set { SetValue(CountTicketsProperty, value); }
        }
        public event RoutedEventHandler AccesClick
        {
            add { AddHandler(AccesButtonEvent, value); }
            remove { RemoveHandler(AccesButtonEvent, value); }
        }


        RoutedEvent AccesButtonEvent = EventManager.RegisterRoutedEvent("AccesClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Tickets));
        DependencyProperty CountTicketsProperty = DependencyProperty.Register("CountTickets", typeof(string), typeof(Tickets));
        DependencyProperty CityDepartureProperty = DependencyProperty.Register("CityDeparture", typeof(string), typeof(Tickets));
        DependencyProperty CityArriveProperty = DependencyProperty.Register("CityArrive", typeof(string), typeof(Tickets));
        DependencyProperty DateDepartureProperty = DependencyProperty.Register("DateDeparture", typeof(string), typeof(Tickets));
        DependencyProperty DateArriveProperty = DependencyProperty.Register("DateArrive", typeof(string), typeof(Tickets));
        DependencyProperty TimeDepartureProperty = DependencyProperty.Register("Departure", typeof(string), typeof(Tickets));
        DependencyProperty TimeArriveProperty = DependencyProperty.Register("TimeArrive", typeof(string), typeof(Tickets));
        DependencyProperty NumberProperty = DependencyProperty.Register("Number", typeof(int), typeof(Tickets));
    }
}
