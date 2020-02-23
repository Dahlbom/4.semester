﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace Lab1
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<Agent> agents;
        private string filename = "";
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindowViewModel()
        {
            agents = new ObservableCollection<Agent>();
            {
                #if DEBUG
                new Agent("007", "Mister", "killing", "assassination of Poul");
                new Agent("008", "Poul", "Baker", "assassination of Mister");
                #endif
            };
            CurrentAgent = null;

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            clock.Update();
        }

        #region Properties

        public ObservableCollection<Agent> Agents
        {
            get { return agents; }
            set { SetProperty(ref agents, value); }
        }

        Agent currentAgent = null;

        public Agent CurrentAgent
        {
            get { return currentAgent; }
            set
            {
                SetProperty(ref currentAgent, value);
            }
        }

        int currentIndex = -1;
        
        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                SetProperty(ref currentIndex, value);
            }
        }

        Clock clock = new Clock();

        public Clock Clock { get => clock; set => clock = value; }

        #endregion

        #region Commands

        ICommand _PreviousCommand;
        public ICommand PreviousCommand
        {
            get
            {
                return _PreviousCommand ??
                (_PreviousCommand = new DelegateCommand(PreviousCommandExecute, PreviousCommandCanExecute).ObservesProperty(() => CurrentIndex));
            }
        }

        private bool PreviousCommandCanExecute()
        {
            if (CurrentIndex > 0)
                return true;
            else
                return false;
        }

        private void PreviousCommandExecute()
        {
            if (CurrentIndex > 0)
                --CurrentIndex;
        }

        ICommand _nextCommand;

        public ICommand NextCommand
        {
            get
            {
                return _nextCommand ?? (_nextCommand = new DelegateCommand(
                    () => ++currentIndex,
                    () => CurrentIndex < (Agents.Count - 1)).ObservesProperty(() => CurrentIndex));
            }
        }

        ICommand _newCommand;

        public ICommand AddNewAgentCommand
        {
            get
            {
                return _newCommand ?? (_newCommand = new DelegateCommand(() =>
                {
                    Agents.Add(new Agent());
                    CurrentIndex = Agents.Count - 1;
                }));
            }
        }

        ICommand _deleteCommand;

        public ICommand DeleteAgentCommand => _deleteCommand ?? (_deleteCommand = 
            new DelegateCommand(DeleteAgent, DeleteAgent_CanExecute)
            .ObservesProperty(() => CurrentIndex));

        private bool DeleteAgent_CanExecute()
        {
            if (Agents.Count > 0 && CurrentIndex >= 0)
                return true;
            else
                return false;
        }

        private void DeleteAgent()
        {
            Agents.RemoveAt(CurrentIndex);
        }

        ICommand _closeCommand;

        public ICommand CloseAppCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new DelegateCommand(() =>
                {
                    App.Current.MainWindow.Close();
                }));
            }
        }

        ICommand _SaveasCommand;

        public ICommand SaveAsCommand
        {
            get { return _SaveasCommand ?? (_SaveasCommand = new DelegateCommand<string>(SaveAsCommand_Execute)); }
        }

        private void SaveAsCommand_Execute(string argFilename)
        {
            if(argFilename == "")
            {
                MessageBox.Show("You must enter a file name in the File Name textbox!", "Unable to save file",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                filename = argFilename;
                SaveAsCommand_Execute(filename);
            }
        }

        ICommand _SaveCommand;

        public ICommand SaveCommand
        {
            get {
                return _SaveCommand ?? (_SaveCommand = new DelegateCommand(SaveFileCommand_Execute, SaveFileCommand_CanExecute)
                  .ObservesProperty(() => Agents.Count));
            }
        }

        private bool SaveFileCommand_CanExecute()
        {
            return (filename != "") && (Agents.Count > 0);
        }

        private void SaveFileCommand_Execute()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Agent>));
            TextWriter writer = new StreamWriter(filename);
            // Serialize all the agents.
            serializer.Serialize(writer, Agents);
            writer.Close();
        }

        ICommand _NewFileCommand;
        public ICommand NewFileCommand
        {
            get { return _NewFileCommand ?? (_NewFileCommand = new DelegateCommand(NewFileCommand_Execute)); }
        }

        private void NewFileCommand_Execute()
        {
            MessageBoxResult res = MessageBox.Show("Any unsaved data will be lost. Are you sure you want to initiate a new file?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                Agents.Clear();
                filename = "";
            }
        }


        ICommand _OpenFileCommand;
        public ICommand OpenFileCommand
        {
            get { return _OpenFileCommand ?? (_OpenFileCommand = new DelegateCommand<string>(OpenFileCommand_Execute)); }
        }

        private void OpenFileCommand_Execute(string argFilename)
        {
            if (argFilename == "")
            {

                MessageBox.Show("You must enter a file name in the File Name textbox!", "Unable to save file",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                filename = argFilename;
                var tempAgents = new ObservableCollection<Agent>();

                // Create an instance of the XmlSerializer class and specify the type of object to deserialize.
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Agent>));
                try
                {
                    TextReader reader = new StreamReader(filename);
                    // Deserialize all the agents.
                    tempAgents = (ObservableCollection<Agent>)serializer.Deserialize(reader);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Agents = tempAgents;

                // We have to insert the agents in the existing collection. 
                //Agents.Clear();
                //foreach (var agent in tempAgents)
                //    Add(agent);
            }
        }

        #endregion

    }
}
