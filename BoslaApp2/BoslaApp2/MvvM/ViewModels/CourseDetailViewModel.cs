using BoslaApp2.Models;
using BoslaApp2.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BoslaApp2.MvvM.ViewModels
{
    public class CourseDetailViewModel : ViewModelBase
    {
        private readonly CourseService courseService;

        private readonly Course CurrentCourse;
        public CourseDetailViewModel(Course currentCourse)
        {
            courseService = new CourseService();
            CurrentCourse = currentCourse;

            var trainerService = new TrainerService();
            var courseTrainer = trainerService.ReadById(currentCourse.Trainer_Id);
            trainer = courseTrainer.Name;

            Title = CurrentCourse.Title;
            Description = CurrentCourse.Description;
            Price = CurrentCourse.Price;
        }

        private string trainer;
        public string Trainer
        {
            set
            {
                if (trainer != value)
                {
                    trainer = value;
                    OnPropertyChanged("Trainer");
                }
            }
            get
            {
                return trainer;
            }
        }

        private string title;
        public string Title
        {
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged("Title");
                }
            }
            get
            {
                return title;
            }
        }

        private string description;
        public string Description
        {
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
            get
            {
                return description;
            }
        }

        private decimal price;
        public decimal Price
        {
            set
            {
                if (price != value)
                {
                    price = value;
                    OnPropertyChanged("Price");
                }
            }
            get
            {
                return price;
            }
        }

        private string message;
        public string Message
        {
            set
            {
                if (message != value)
                {
                    message = value;
                    OnPropertyChanged("Message");
                }
            }
            get
            {
                return message;
            }
        }

        public ICommand UpdateCourseCommand
        {
            get
            {
                return new Command(async () =>
                {
                    CurrentCourse.Title = title;
                    CurrentCourse.Description = description;
                    CurrentCourse.Price = price;

                    int result = courseService.UpdateCourse(CurrentCourse);

                    if (result > 0)
                    {
                        Message = "Course updated successfully!";
                        MessagingCenter.Send("CourseDetails", "UpdateListView", "Success");

                        await App.Navigation.PopModalAsync();
                    }
                    else
                    {
                        Message = "Your course not updated!";
                    }
                });
            }
        }

        public ICommand DeleteCourseCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var accepted = await App.ConfirmAlert("Bosla", "Are you sure you want to delete this course?");
                    if (accepted)
                    {
                        int result = courseService.DeleteCourse(CurrentCourse);

                        if (result > 0)
                        {
                            Message = "Course deleted successfully!";
                            MessagingCenter.Send("CourseDetails", "UpdateListView", "Success");

                            await App.Navigation.PopModalAsync();
                        }
                        else
                        {
                            Message = "Your course not deleted!";
                        }
                    }

                });
            }
        }
    }
}
