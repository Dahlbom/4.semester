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
using SIO = System.IO;


namespace BabyNames
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<BabyName> _babies;
        private string[,] rankMatrix = new string[11, 10];

        public MainWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
            DecadeListBox.SelectionChanged += new SelectionChangedEventHandler(DecadeListBox_SelectionChanged);
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            foreach (var baby in _babies)
            {
                BabyListBox.Items.Add(baby.Name);
            }
        }

        void DecadeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem item;

            item = DecadeListBox
                .SelectedItem as ListBoxItem; // Because the data entries is done by use of ListBoxItem in XAML
            if (item != null)
            {
                int decade = (Convert.ToInt32(item.Content) - 1900) / 10;
                BabyListBox.Items.Clear();
                for (int i = 1; i < 11; ++i)
                {
                    BabyListBox.Items.Add(string.Format("{0,2} {1}", i, rankMatrix[decade, i - 1]));
                }
            }
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string file = SIO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "babynames.txt");
            this._babies = Utility.LoadFromFile(file);

            foreach (BabyName name in _babies)
            {
                for (int decade = 1900; decade < 2010; decade += 10)
                {
                    int rank = name.Rank(decade);
                    int decadeIndex = (decade - 1900) / 10;
                    if (0 < rank && rank < 11)
                        if (rankMatrix[decadeIndex, rank - 1] == null)
                            rankMatrix[decadeIndex, rank - 1] = name.Name;
                        else
                            rankMatrix[decadeIndex, rank - 1] += " and " + name.Name;
                }
            }
        }
    }

    public class Utility
    {
        public static List<BabyName> LoadFromFile(string filename)
        {
            List<BabyName> babies = new List<BabyName>();
            string line;

            using (StreamReader sr = new StreamReader(filename))
            {
                line = sr.ReadLine();
                while (line != null)
                {
                    babies.Add(new BabyName(line));
                    line = sr.ReadLine();
                }
            }
            return babies;
        }


    }

}


