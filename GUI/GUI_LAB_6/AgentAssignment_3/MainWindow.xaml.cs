using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using AgentAssignment_3;

namespace AgentAssignment_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Agent> agents = new List<Agent>();
        private Agent myAgent = new Agent();

        public MainWindow()
        {
            InitializeComponent();


            DataContext = new MainWindowViewModel();
        }
    }
}