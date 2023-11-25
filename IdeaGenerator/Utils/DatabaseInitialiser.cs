using IdeaGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
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

            List<Engine> engines = await App.EngineRepo.GetAllEnginesAsync();
            if (!engines.Any())
                PopulateDefaultEngines();
        }

        private static async void PopulateDefaultAgents()
        {
            List<string> agentNames;
            var assembly = Assembly.GetExecutingAssembly();
            var nameSpace = "IdeaGenerator.Data";
            var fileName = $"{nameSpace}.Agents.json";
            using(Stream stream = assembly.GetManifestResourceStream(fileName))
            {
                using(StreamReader reader = new StreamReader(stream))
                {
                    string jsonString = reader.ReadToEnd();
                    agentNames = JsonSerializer.Deserialize<List<string>>(jsonString);
                }
            }
            foreach(var agentName in agentNames)
            {
                await App.AgentRepo.AddAgentAsync(agentName);
            }
        }

        private static async void PopulateDefaultEngines()
        {
            List<string> engineNames;
            var assembly = Assembly.GetExecutingAssembly();
            var nameSpace = "IdeaGenerator.Data";
            var fileName = $"{nameSpace}.Engines.json";
            using (Stream stream = assembly.GetManifestResourceStream(fileName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string jsonString = reader.ReadToEnd();
                    engineNames = JsonSerializer.Deserialize<List<string>>(jsonString);
                }
            }
            foreach (var engineName in engineNames)
            {
                await App.EngineRepo.AddEngineAsync(engineName);
            }
        }
    }
}
