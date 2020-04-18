using BoslaApp2.Models;
using SQLite;

namespace BoslaApp2.DB
{
    public class CoursesDatabase
    {
        public SQLiteConnection Connection { get; set; }
        public CoursesDatabase()
        {
            Initialize();  
        }

        void Initialize()
        {
            Connection = new SQLiteConnection(DbConstants.DatabasePath,
                SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite);

            Connection.CreateTable<Course>(CreateFlags.None);
            Connection.CreateTable<CourseImage>(CreateFlags.None);
            Connection.CreateTable<Trainer>(CreateFlags.None);
        }
    }
}
