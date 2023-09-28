using IdeaGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaGenerator.Utils
{
    public class DatabaseInitialiser
    {
        public static async Task InitialiseDatabase()
        {
            List<Agent> agents = await App.AgentRepo.GetAllAgentsAsync();
            if (!agents.Any())
                PopulateDefaultAgents();
        }

        private static async void PopulateDefaultAgents()
        {
            for (int i = 0; i < 10; i++)
            {
                await App.AgentRepo.AddAgentAsync($"Agent {i}");
            }
        }
    }
}
