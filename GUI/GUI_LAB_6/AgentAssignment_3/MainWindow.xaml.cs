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
        public MainWindow()
        {
            InitializeComponent();


            DataContext = new MainWindowViewModel();
        }

        private void Button_Click_left(object sender, RoutedEventArgs e)
        {
            if (Agent_ListBox.SelectedIndex > 0)
                Agent_ListBox.SelectedIndex = --Agent_ListBox.SelectedIndex;
        }

        private void Button_Click_right(object sender, RoutedEventArgs e)
        {
            if (Agent_ListBox.SelectedIndex < Agent_ListBox.SelectedIndex+1)
                Agent_ListBox.SelectedIndex = ++Agent_ListBox.SelectedIndex;
        }

        private void Button_Click_add_new_agent(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainWindowViewModel;
            vm.AddNewAgent();
            Agent_ListBox.SelectedIndex = Agent_ListBox.Items.Count - 1;
            IDTxtBox.Focus();
        }
    }
}