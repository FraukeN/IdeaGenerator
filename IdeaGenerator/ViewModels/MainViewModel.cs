using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeaGenerator.Models;
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
            List<Agent> agents = await App.AgentRepo.GetAllAgents();
            if (!agents.Any())
                LoadDefaultAgents();
            else
            {
                _agents.Clear();
                foreach (Agent agent in agents)
                {
                    _agents.Add(agent.Name);
                }
            }
            //int randomIndex = random.Next(Agents.Count);
            //string intro = Agents[randomIndex];
            Debug.WriteLine("Idea generated!");
        }

        private void LoadDefaultAgents()
        {
            for (int i = 0; i < 10; i++)
            {
                _agents.Add($"Agent {i}");
            }
        }
    }
}
