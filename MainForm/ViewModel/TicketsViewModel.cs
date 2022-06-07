using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
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
        public TicketsViewModel()
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
