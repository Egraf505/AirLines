﻿using DB;
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

namespace MainForm.Page
{
    /// <summary>
    /// Логика взаимодействия для AirTicketsPage.xaml
    /// </summary>
    public partial class AirTicketsPage : System.Windows.Controls.Page
    {
        public AirTicketsPage()
        {
            InitializeComponent();
        }
        public AirTicketsPage(User user)
        {
            InitializeComponent();
        }
    }
}
