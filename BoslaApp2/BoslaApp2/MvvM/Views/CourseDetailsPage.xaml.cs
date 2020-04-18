using BoslaApp2.Models;
using BoslaApp2.MvvM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoslaApp2.MvvM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseDetailsPage : ContentPage
    {
        public CourseDetailsPage(Course course)
        {
            InitializeComponent();

            BindingContext = new CourseDetailViewModel(course);
        }
    }
}