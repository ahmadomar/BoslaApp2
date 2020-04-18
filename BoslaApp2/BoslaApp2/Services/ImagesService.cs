using BoslaApp2.Models;
using System.Collections.Generic;

namespace BoslaApp2.Services
{
    public class ImagesService
    {

        public int CreateImage(CourseImage image)
        {
            var conn = App.Database.Connection;

            return conn.Insert(image);
        }


        public int DeleteImage(CourseImage image)
        {
            var conn = App.Database.Connection;
            
            return conn.Delete<CourseImage>(image.Id);
        }

        public CourseImage Get(int id)
        {
            var conn = App.Database.Connection;

            return conn.Get<CourseImage>(id);
        }

        public List<CourseImage> ReadAllImages()
        {
            var conn = App.Database.Connection;

            return conn.Query<CourseImage>("SELECT * FROM CourseImage");
        }
    }
}
