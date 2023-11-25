using IdeaGenerator.Models;
using SQLite;

namespace IdeaGenerator.Repositories
{
    public class EngineRepository
    {
        string _dbPath;
        SQLiteAsyncConnection conn = null;

        public EngineRepository(string dbPath)
        {
            _dbPath = dbPath;
        }
        private async Task Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<Engine>();
        }

        public async Task<List<Engine>> GetAllEnginesAsync()
        {
            try
            {
                await Init();
                return await conn.Table<Engine>().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Engine> GetEngineAsync(string name)
        {
            await Init();
            return await conn.Table<Engine>().Where(a => a.Name == name).FirstOrDefaultAsync();
        }

        public async Task<bool> EngineExists(string name)
        {
            await Init();
            Engine Engine = await GetEngineAsync(name);
            return Engine == null ? false : true;
        }

        public async Task AddEngineAsync(string EngineName)
        {
            try
            {
                await Init();
                if (string.IsNullOrEmpty(EngineName))
                    throw new Exception("Engine name can't be empty");

                if (!await EngineExists(EngineName))
                    await conn.InsertAsync(new Engine { Name = EngineName });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
