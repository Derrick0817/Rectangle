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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            heightInput.TextChanged += heightInput_TextChanged;
            areaInput.TextChanged += areaInput_TextChanged;
        }

        public void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            // Only allow numeric input
            e.Handled = !double.TryParse(e.Text, out _);
        }

        public void heightInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(heightInput.Text, out double height) && height > 0)
            {
                double currentArea = double.Parse(areaInput.Text); //convert input to double
                double width = currentArea / (double)height;
                UpdateRectangleSize(width, (double)height);
            } 
        }

        public void areaInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(areaInput.Text, out double area) && area > 0)
            {
                double currentHeight = double.Parse(heightInput.Text); //  try convert input to double
                double width = (double)area / currentHeight;
                UpdateRectangleSize(width, currentHeight);
            }
        }

        public void UpdateRectangleSize(double width, double height)
        {
            // Check if the new size exceeds the window's dimensions and update rectangle size
            if (width > 0 && width <= this.Width && height > 0 && height <= this.Height)
            {
                rectangle.Width = width;
                rectangle.Height = height;
            }
        }

    }
}

