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

        public async Task<List<Agent>> GetAllAgents()
        {
            try
            {
                await Init();
                return await conn.Table<Agent>().ToListAsync();
            }
            catch (Exception ex)
            {
            }

            return new List<Agent>();
        }
    }
}
