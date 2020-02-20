using System.Collections.Generic;
using System.Windows;
using AgentAssignement_2;

namespace AgentAssignement_2
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
            agents.Add(new Agent("007", "Mister", "killing", "assassination of Poul"));
            agents.Add(new Agent("008", "Poul", "Baker", "assassination of Mister"));

            DataContext = agents;
        }
    }
}