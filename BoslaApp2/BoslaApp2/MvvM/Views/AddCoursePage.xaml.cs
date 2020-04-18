using BoslaApp2.MvvM.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoslaApp2.MvvM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCoursePage : ContentPage
    {
        public AddCoursePage()
        {
            InitializeComponent();

            BindingContext = new AddCourseViewModel();
        }
    }
}