using BoslaApp2.DB;
using BoslaApp2.MvvM.Views;
using BoslaApp2.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoslaApp2
{
    public partial class App : Application
    {
        public static INavigation Navigation { get; set; }

        private static CoursesDatabase _database;
        public static CoursesDatabase Database
        {
            get
            {
                if (_database == null)
                    _database = new CoursesDatabase();
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();

            //TrainerService trainerService = new TrainerService();
            //int count = trainerService.AddTrainers(new System.Collections.Generic.List<Models.Trainer>
            //{
            //    new Models.Trainer
            //    {
            //        Name = "Ibrahim", Email = "ibrahim@email.com"
            //    },
            //    new Models.Trainer
            //    {
            //        Name = "Asmaa", Email = "asmaa@email.com"
            //    },
            //    new Models.Trainer
            //    {
            //        Name = "Ahmed", Email = "ahmed@email.com"
            //    },
            //});

            MainPage = new NavigationPage(new MainPage());
        }

        public static async Task<bool> ConfirmAlert(string title, string message)
        {
            return await App.Current.MainPage.DisplayAlert(title, message, "Yes", "No");
        }

        public static async Task DisplayAlert(string title, string message)
        {
            await App.Current.MainPage.DisplayAlert(title, message,"Ok");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
