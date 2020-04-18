using BoslaApp2.Models;
using BoslaApp2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BoslaApp2.MvvM.ViewModels
{
    public class AddCourseViewModel : ViewModelBase
    {

        private readonly CourseService courseService;
        public AddCourseViewModel()
        {
            courseService = new CourseService();

            TrainerService trainerService = new TrainerService();
            Trainers = trainerService.ReadAll();
        }

        private Trainer _selectedTrainer;
        public Trainer SelectedTrainer
        {
            set
            {
                _selectedTrainer = value;
                OnPropertyChanged("SelectedTrainer");
            }
            get
            {
                return _selectedTrainer;
            }
        }
        public List<Trainer> Trainers
        {
            set;get;
        }

        private string title;
        public string Title
        {
            set
            {
                if(title != value)
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
                if(description != value)
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
                if(message != value)
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

        public ICommand AddCourseCommand
        {
            get
            {
                return new Command(() =>
                {
                    int result = courseService.CreateCourse(new Models.Course
                    {
                        Title = title,
                        Description = description,
                        Price = price,
                        Trainer_Id = SelectedTrainer.Id
                    });

                    if (result > 0)
                    {
                        Message = "Course added successfully!";
                        MessagingCenter.Send("AddCourse", "UpdateListView", "Success");
                    }
                    else
                    {
                        Message = "Your course not added!";
                    }

                });
            }
        }

    }
}
