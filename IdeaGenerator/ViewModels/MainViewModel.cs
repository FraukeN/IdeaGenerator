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

        public MainViewModel()
        {
            _agents = new ObservableCollection<string>();
        }

        [ObservableProperty]
        private string _adventure;

        [RelayCommand]
        private async void GenerateIdea()
        {
            List<Agent> agents = await App.AgentRepo.GetAllAgentsAsync();

            _agents.Clear();
            foreach (Agent agent in agents)
            {
                _agents.Add(agent.Name);
            }
            int randomIndex = random.Next(Agents.Count);
            string agentName = Agents[randomIndex];
            Adventure = $"{Grammar.DeterminerFor(agentName)} {agentName} wants to ";
            Debug.WriteLine("Idea generated!");
        }
    }
}
