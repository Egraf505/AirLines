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
    }

    public class WatermarkedTextBox : DependencyObject
    {
        #region Fields

        private const string _defaultWatermark = "None";

        public static readonly DependencyProperty WatermarkTextProperty = DependencyProperty.Register("WatermarkText", typeof(string), typeof(WatermarkedTextBox), new UIPropertyMetadata(string.Empty, OnWatermarkTextChanged));

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="WatermarkedTextBox"/> class with default watermark text.
        /// </summary>
        public WatermarkedTextBox()
          : this(_defaultWatermark)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WatermarkedTextBox"/> class.
        /// </summary>
        /// <param name="watermark">The watermark to show when value is <c>null</c> or empty.</param>
        public WatermarkedTextBox(string watermark)
        {
            WatermarkText = watermark;
        }

        #endregion

        #region Properties

        public string WatermarkText
        {
            get { return (string)GetValue(WatermarkTextProperty); }
            set { SetValue(WatermarkTextProperty, value); }
        }

        #endregion

        #region Methods

        public static void OnWatermarkTextChanged(DependencyObject box, DependencyPropertyChangedEventArgs e)
        {
            //Add changed functionality here
        }

        #endregion
    }

}
