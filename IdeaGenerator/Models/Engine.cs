using SQLite;

namespace IdeaGenerator.Models
{
    [Table("engines")]
    public class Engine
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250), Unique]
        public string Name { get; set; }
    }
}
