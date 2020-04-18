using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoslaApp2.Models
{
    public class CourseImage
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Image { get; set; }
    }
}
