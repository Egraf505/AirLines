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
    /// Логика взаимодействия для TicketOfHistory.xaml
    /// </summary>
    public partial class TicketOfHistory : UserControl
    {
        public TicketOfHistory(string title, string datearrive, string cityarrive, string datedeparture, string citydeparture)
        {
            InitializeComponent();

            TitleTB.Text = title;
            DateDeparture.Text = datedeparture;
            CityDepartureTB.Text = citydeparture;

            DateArrive.Text = datearrive;
            CityArriveTB.Text = cityarrive;
        }
    }
}
