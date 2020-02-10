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

namespace GUI_Ex_2_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Sailboat myboat = new Sailboat();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myboat.Length = double.Parse(LengthTextBox.Text);
            myboat.Name = NameTextBox.Text.ToString();
            HullSpeedTextBlock.Text = Math.Round(myboat.Hullspeed(), 3).ToString();
        }

        private void Picture_pressed(object sender, RoutedEventArgs e)
        {
            
        }
    }

    /// <summary>
    /// Simple class to use in lab 3.1.
    /// </summary>
    public class Sailboat
    {

        /// <summary>
        /// Gets or sets the name of the boat.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the length of the boat. Unit MUST be feets!.
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// Calculate the hull speed for the boat.
        /// </summary>
        /// <returns>Hull speed in knots</returns>
        public double Hullspeed()
        {
            return 1.34 * System.Math.Sqrt(Length);
        }

    }
}
