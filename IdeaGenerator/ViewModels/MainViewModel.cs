using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeaGenerator.Models;
using IdeaGenerator.Utils;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace IdeaGenerator.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private Random random = new Random((int)DateTime.Now.Ticks);

        private ObservableCollection<string> _agents;
        public ObservableCollection<string> Agents
        {
            get => _agents;
            set => SetProperty(ref _agents, value);
        }

        private ObservableCollection<string> _engines;
        public ObservableCollection<string> Engines
        {
            get => _engines;
            set => SetProperty(ref _engines, value);
        }

        public MainViewModel()
        {
            _agents = new ObservableCollection<string>();
            _engines = new ObservableCollection<string>();
        }

        [ObservableProperty]
        private string _adventure;

        [RelayCommand]
        private async void GenerateIdea()
        {
            List<Agent> agents = await App.AgentRepo.GetAllAgentsAsync();
            List<Engine> engines = await App.EngineRepo.GetAllEnginesAsync();

            _agents.Clear();
            foreach (Agent agent in agents)
            {
                _agents.Add(agent.Name);
            }
            int randomIndex = random.Next(Agents.Count);
            string agentName = Agents[randomIndex];

            _engines.Clear();
            foreach (Engine engine in engines)
            {
                _engines.Add(engine.Name);
            }
            randomIndex = random.Next(Engines.Count);
            string engineName = Engines[randomIndex];
            Adventure = $"{Grammar.DeterminerFor(agentName)} {agentName} wants to {engineName}";
        }
    }
}
