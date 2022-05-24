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

namespace AuthorizationForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {      

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;  

            if (textBox.Text == textBox.Tag.ToString())
            {
                textBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                textBox.HorizontalContentAlignment = HorizontalAlignment.Left;           
                textBox.Text = String.Empty;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == String.Empty || textBox.Text == null)
            {
                textBox.Foreground = new SolidColorBrush(Color.FromRgb(109, 104, 104));
                textBox.HorizontalContentAlignment = HorizontalAlignment.Center;                
                textBox.Text = textBox.Tag.ToString();
            }
        }

        private void Minimezed_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();   
        }
    }
}
