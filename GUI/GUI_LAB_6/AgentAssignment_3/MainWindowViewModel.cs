using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AgentAssignment_3
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Agent> _agents;

        public MainWindowViewModel()
        {
            _agents = new ObservableCollection<Agent>();
            _agents.Add(new Agent("007", "Mister", "killing", "assassination of Poul"));
            _agents.Add(new Agent("008", "Poul", "Baker", "assassination of Mister"));
            CurrentAgent = _agents[0];
        }

        #region Properties

        public ObservableCollection<Agent> _Agents
        {
            get { return _agents; }
        }

        private Agent currentAgent = null;

        public Agent CurrentAgent
        {
            get { return currentAgent; }
            set
            {
                if (currentAgent != value)
                {
                    currentAgent = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region Methods

        public void AddNewAgent()
        {
            _agents.Add(new Agent());
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion
    }
}
