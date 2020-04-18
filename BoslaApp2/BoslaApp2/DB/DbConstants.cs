using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BoslaApp2.DB
{
    public class DbConstants
    {
        private static string DBFileName = "Courses.db3";
        public static string DatabasePath
        {
            get
            {
                string baseFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(baseFolder, DBFileName);

            }
        }
    }
}
