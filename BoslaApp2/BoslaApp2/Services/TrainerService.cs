using BoslaApp2.DB;
using BoslaApp2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoslaApp2.Services
{
    public class TrainerService
    {

        public int AddTrainer(Trainer trainer)
        {
            var conn = App.Database.Connection;

            return conn.Insert(trainer);
        }

        public int AddTrainers(List<Trainer> trainers)
        {
            var conn = App.Database.Connection;

            return conn.InsertAll(trainers);
        }


        public List<Trainer> ReadAll()
        {
            var conn = App.Database.Connection;

            return conn.Table<Trainer>().ToList();
        }

        public Trainer ReadById(int id)
        {
            var conn = App.Database.Connection;

            return conn.Get<Trainer>(id);
        }
    }
}
