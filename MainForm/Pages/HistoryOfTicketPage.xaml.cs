using DB;
using DB.Model;
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

namespace MainForm.Pages
{
    /// <summary>
    /// Логика взаимодействия для HistoryOfTicketPage.xaml
    /// </summary>
    public partial class HistoryOfTicketPage : Page
    {
        private readonly User _user;

        public HistoryOfTicketPage(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void ShowHistory()
        {
            HistoriesStackP.Children.Clear();

            List<History> histories = new List<History>();

            using (AirFligthsContext context = new AirFligthsContext())
            {
                histories.AddRange(context.Histories
                    .Where(x => x.UserId == _user.Id)
                    .ToList());
            }

            foreach (var history in histories)
            {
                HistoriesStackP.Children.Add(new TicketOfHistory(history.TitleOfTicket, history.DateArrive, history.CityArrive, history.DateDeparture, history.CityDeparture, history.Dinner, history.TypeOfPlan));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowHistory();
        }
    }
}
