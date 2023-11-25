using IdeaGenerator.Models;
using SQLite;

namespace IdeaGenerator.Repositories
{
    public class AgentRepository
    {
        string _dbPath;
        SQLiteAsyncConnection conn = null;

        public AgentRepository(string dbPath)
        {
            _dbPath = dbPath;
        }
        private async Task Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<Agent>();
        }

        public async Task<List<Agent>> GetAllAgentsAsync()
        {
            try
            {
                await Init();
                return await conn.Table<Agent>().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Agent> GetAgentAsync(string name)
        {
            await Init();
            return await conn.Table<Agent>().Where(a => a.Name == name).FirstOrDefaultAsync();
        }

        public async Task<bool> AgentExists(string name)
        {
            await Init();
            Agent agent = await GetAgentAsync(name);
            return agent == null ? false : true;
        }

        public async Task AddAgentAsync(string agentName)
        {
            try
            {
                await Init();
                if (string.IsNullOrEmpty(agentName))
                    throw new Exception("Agent name can't be empty");

                if (!await AgentExists(agentName))
                    await conn.InsertAsync(new Agent { Name = agentName });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
