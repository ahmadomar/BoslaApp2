using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoslaApp2.Models
{
    public class Trainer
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
