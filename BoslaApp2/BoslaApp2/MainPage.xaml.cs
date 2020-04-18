using BoslaApp2.MvvM.ViewModels;
using BoslaApp2.MvvM.Views;
using BoslaApp2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BoslaApp2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new CoursesListViewModel();
            App.Navigation = Navigation;
        }

        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<string, string>("MainPage", "UpdateListView", (sender, result) =>
            {
                BindingContext = new CoursesListViewModel();
            });
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<string>("MainPage", "UpdateListView");
        }
    }
}
