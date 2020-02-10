using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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


namespace BabyNames
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<BabyName> _babies = new List<BabyName>();
        private Utility _utility = new Utility();
        public MainWindow()
        {
            InitializeComponent();
            _babies.AddRange(_utility.LoadFromFile(@"C:\Users\Frederik Dahlbom\source\repos\Dahlbom\4.semester\GUI\GUI_LAB_Ex_5\BabyNames\babynames.txt", 15));
        }
        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            foreach (var baby in _babies)
            {
                BabyListBox.Items.Add(baby.Name);
            }
        }
    }

    public class Utility
    {
        public List<BabyName> LoadFromFile(string file, int numlines)
        {
            List<BabyName> babies = new List<BabyName>();
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                for (int i = 0; i < numlines; ++i)
                {
                    line = sr.ReadLine();
                    babies.Add(new BabyName(line));
                }
            }

            return babies;
        }
    }

}
