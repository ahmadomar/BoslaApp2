using BoslaApp2.DB;
using BoslaApp2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoslaApp2.Services
{
    public class CourseService
    {

        public int CreateCourse(Course course)
        {
            var conn = App.Database.Connection;

            return conn.Insert(course);
        }

        public int CreateCourses(List<Course> courses)
        {
            var conn = App.Database.Connection;

            return conn.InsertAll(courses);
        }


        public int UpdateCourse(Course course)
        {
            var conn = App.Database.Connection;

            return conn.Update(course);
        }

        public int UpdateAllCourses(List<Course> courses)
        {
            var conn = App.Database.Connection;

            return conn.UpdateAll(courses);
        }


        public int DeleteCourse(Course course)
        {
            var conn = App.Database.Connection;
            
            //return conn.Delete(course.Id, new SQLite.TableMapping(typeof(Course)));
            return conn.Delete<Course>(course.Id);
        }

        public int DeleteAllCourses()
        {
            var conn = App.Database.Connection;
            return conn.DeleteAll<Course>();
        }


        public Course Get(int id)
        {
            var conn = App.Database.Connection;

            //var result = conn.Get(id, new TableMapping(typeof(Course)));
            //return (Course)result;

            //return conn.Get<Course>(id);

            //return conn.Table<Course>().Where(c => c.Id == id).FirstOrDefault();

            return conn.Query<Course>($"SELECT * FROM Course WHERE id = ?", id)
                .FirstOrDefault();
        }

        public List<Course> ReadAllCourses()
        {
            var conn = App.Database.Connection;

            //return conn.Table<Course>().ToList();

            return conn.Query<Course>("SELECT * FROM Course");
        }

        public List<Course> ReadAllCourses(string queryText)
        {
            var conn = App.Database.Connection;

            //return conn.Table<Course>().Where(c=> c.Description.Contains(queryText)).ToList();

            return conn.Query<Course>($"SELECT * FROM Course WHERE Title LIKE %?%", queryText);
        }
    }
}
