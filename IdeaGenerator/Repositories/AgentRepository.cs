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

        public async Task AddAgentAsync(string agentName)
        {
            int result = 0;
            try
            {
                await Init();
                if (string.IsNullOrEmpty(agentName))
                    throw new Exception("Agent name can't be empty");

                result = await conn.InsertAsync(new Agent { Name = agentName });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
