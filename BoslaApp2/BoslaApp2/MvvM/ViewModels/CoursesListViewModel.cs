using BoslaApp2.Models;
using BoslaApp2.MvvM.Views;
using BoslaApp2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BoslaApp2.MvvM.ViewModels
{
    public class CoursesListViewModel : ViewModelBase
    {
        private List<Course> courses = new List<Course>();

        public List<Course> Courses
        {
            set
            {
                if(courses.Count != value.Count)
                {
                    courses = value;
                    OnPropertyChanged("Courses");
                }
            }
            get
            {
                return courses;
            }
        }

        private Course _selectedItem;
        public Course SelectedItem
        {
            set
            {
                _selectedItem = value;

                if (_selectedItem == null)
                    return;

                NavigateToCourseDetails(_selectedItem);

                _selectedItem = null;
                OnPropertyChanged("SelectedItem");
            }
            get
            {
                return _selectedItem;
            }
        }

        public ICommand AddCourseCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Navigation.PushModalAsync(new NavigationPage(new AddCoursePage()));
                });
            }
        }

        public CoursesListViewModel()
        {
            var courseService = new CourseService();
            Courses = courseService.ReadAllCourses();
        }

        public void NavigateToCourseDetails(Course course)
        {
            App.Navigation.PushModalAsync(new NavigationPage(new CourseDetailsPage(course)));
        }
    }
}
