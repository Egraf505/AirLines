using DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
            using (AirFligthsContext context = new AirFligthsContext())
            {

            }
        }
        public MyTicketsViewModel(User user)
        {
            _user = user;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
