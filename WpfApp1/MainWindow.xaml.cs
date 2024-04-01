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
            menu.SelectionChanged += menu_SelectionChanged;
        }

        public void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            // Only allow numeric input
            e.Handled = !double.TryParse(e.Text, out _);
        }

        public void heightInput_TextChanged(object sender, TextChangedEventArgs e) //calculate width and height base on shape and text entries when height is changed
        {
            if (double.TryParse(heightInput.Text, out double height) && height > 0)
            {
                string selectedShapeType = (menu.SelectedItem as ComboBoxItem)?.Content.ToString();
                double currentArea = 0;
                double width = 0;
                switch (selectedShapeType)
                {
                    case "Rectangle":
                        currentArea = double.Parse(areaInput.Text); //  try convert input to double
                        width = currentArea / height;
                        break;
                    case "Ellipse":
                        currentArea = double.Parse(areaInput.Text); //  try convert input to double
                        width = currentArea / height / Math.PI;
                        break;
                }
                UpdateSize(width, (double)height);
            } 
        }

        public void areaInput_TextChanged(object sender, TextChangedEventArgs e) //calculate width and height base on shape and text entries when area is changed
        {
            if (double.TryParse(areaInput.Text, out double area) && area > 0)
            {
                string selectedShapeType = (menu.SelectedItem as ComboBoxItem)?.Content.ToString();
                double currentHeight = 0;
                double width = 0;
                switch (selectedShapeType)
                {
                    case "Rectangle":
                        currentHeight = double.Parse(heightInput.Text); //  try convert input to double
                        width = (double)area / currentHeight;
                        break;
                    case "Ellipse":
                        currentHeight = double.Parse(heightInput.Text); //  try convert input to double
                        width = (double)area / currentHeight /Math.PI;
                        break;
                }
                UpdateSize(width, currentHeight);
            }
        }


        public void menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateShape();
        }

        public void UpdateShape() // change shape by changing visibility
        {
            string selectedShapeType = (menu.SelectedItem as ComboBoxItem)?.Content.ToString();
            switch (selectedShapeType)
            {
                case "Rectangle":
                    rectangle.Visibility = Visibility.Visible;
                    ellipse.Visibility = Visibility.Hidden;
                    break;
                case "Ellipse":
                    rectangle.Visibility = Visibility.Hidden;
                    ellipse.Visibility = Visibility.Visible;
                    break;
            }
        }

        
        public void UpdateSize(double width, double height) // update size base on current selected shape
        {
            if (width > 0 && width <= this.Width && height > 0 && height <= this.Height)
            {
                string selectedShapeType = (menu.SelectedItem as ComboBoxItem)?.Content.ToString();
                switch (selectedShapeType)
                {
                    case "Rectangle":
                        rectangle.Width = width;
                        rectangle.Height = height;
                        break;
                    case "Ellipse":
                        ellipse.Width = width;
                        ellipse.Height = height;
                        break;
                }
            }
        }

    }
}

