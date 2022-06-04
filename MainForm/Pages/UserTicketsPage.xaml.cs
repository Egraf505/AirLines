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

namespace MainForm.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserTicketsPage.xaml
    /// </summary>
    public partial class UserTicketsPage : Page
    {
        public UserTicketsPage()
        {
            InitializeComponent();
        }

        public UserTicketsPage(User user)
        {
            InitializeComponent();
        }
    }
}
