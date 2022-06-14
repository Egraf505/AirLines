using DB;
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
    /// Логика взаимодействия для UserTicket.xaml
    /// </summary>
    public partial class UserTicket : UserControl
    {
        private User _user;

        public UserTicket(User user)
        {
            InitializeComponent();
            _user = user;
            DataContext = this;
        }

        public int Number
        {
            get { return (int)this.GetValue(NumberProperty); }
            set { this.SetValue(NumberProperty, value); }
        }

        public string DatetimeDeparture
        {
            get { return (string)this.GetValue(DatetimeDepartureProperty); }
            set { this.SetValue(DatetimeDepartureProperty, value); }
        }

        public string DatetimeArrive
        {
            get { return (string)this.GetValue(DatetimeArriveProperty); }
            set { this.SetValue(DatetimeArriveProperty, value); }
        }

        public string CityDeparture
        {
            get { return (string)this.GetValue(CityDepartureProperty); }
            set { this.SetValue(CityDepartureProperty, value); }
        }

        public string CityArrive
        {
            get { return (string)this.GetValue(CityArriveProperty); }
            set { this.SetValue(CityArriveProperty, value); }
        }

        public event RoutedEventHandler Acces
        {
            add { AddHandler(AccesEvent, value); }
            remove { RemoveHandler(AccesEvent, value); }
        }

        public event RoutedEventHandler Cancel
        {
            add { AddHandler(CancelEvent, value); }
            remove { RemoveHandler(CancelEvent, value); }
        }

        public static readonly RoutedEvent AccesEvent = EventManager.RegisterRoutedEvent("AccesEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserTicket));
        public static readonly RoutedEvent CancelEvent = EventManager.RegisterRoutedEvent("CancelEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserTicket));

        public static readonly DependencyProperty NumberProperty = DependencyProperty.Register("Number", typeof(int), typeof(UserTicket));
        public static readonly DependencyProperty DatetimeDepartureProperty = DependencyProperty.Register("DatetimeDeparture", typeof(string), typeof(UserTicket));
        public static readonly DependencyProperty CityDepartureProperty = DependencyProperty.Register("CityDeparture", typeof(string), typeof(UserTicket));
        public static readonly DependencyProperty DatetimeArriveProperty = DependencyProperty.Register("DatetimeArrive", typeof(string), typeof(UserTicket));
        public static readonly DependencyProperty CityArriveProperty = DependencyProperty.Register("CityArrive", typeof(string), typeof(UserTicket));

        private void Access_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дальнейшая обработка");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {            
            using(AirFligthsContext context = new AirFligthsContext())
            {
                Ticket ticket = context.Tickets.FirstOrDefault(x => x.IdAirLines == Number && x.IdUser == _user.Id)!;
                ticket.IdUser = null;
                context.SaveChanges();
            }

            MessageBox.Show("Вы отменили бронь");

            RaiseEvent(new RoutedEventArgs(UserTicket.CancelEvent));            
        }
    }
}
