using SQLite;

namespace IdeaGenerator.Models
{
    [Table("agents")]
    public class Agent
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250), Unique]
        public string Name { get; set; }
    }
}
