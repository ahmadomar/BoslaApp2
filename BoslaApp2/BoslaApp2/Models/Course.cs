using SQLite;

namespace BoslaApp2.Models
{
    public class Course
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Trainer_Id { get; set; }
    }
}
