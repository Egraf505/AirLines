using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using DB;
using Newtonsoft.Json;

namespace AuthorizationForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {      

        public MainWindow()
        {
            ConfigUser? currentUser = File.Exists("config.json") ? JsonConvert.DeserializeObject<ConfigUser>(File.ReadAllText("config.json")) : null;

            if (currentUser != null)
            {
                using (AirFligthsContext context = new AirFligthsContext())
                {
                    User user = context.Users.FirstOrDefault(x => x.Login == currentUser.l_name && x.Password == currentUser.p_name)!;

                    if (user != null)
                    {
                        MainForm.MainWindow mainWindow = new(user.Login, user.Password);                        
                        Application.Current.MainWindow.Close();
                        mainWindow.Show();
                    }
                }
            }

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

        private void LogInMov_Click(object sender, RoutedEventArgs e)
        {
            RegistrationBorder.Visibility = Visibility.Collapsed;
            LoginBorder.Visibility = Visibility.Visible;
        }

        private void RegMov_Click(object sender, RoutedEventArgs e)
        {
            RegistrationBorder.Visibility = Visibility.Visible;
            LoginBorder.Visibility = Visibility.Collapsed;
        }
    }
}
