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

namespace GUI_Ex_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Sailboat myBoat = new Sailboat();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myBoat.Name = NameTextBox.Text;
            myBoat.Length = double.Parse(lengthTextBox.Text);
            hullSpeedTextBlock.Text = Math.Round(myBoat.Hullspeed(), 3).ToString();
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
