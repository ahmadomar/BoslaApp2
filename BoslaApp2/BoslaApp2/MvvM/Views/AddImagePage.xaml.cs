using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using BoslaApp2.Services;
using BoslaApp2.Models;
using System.IO;

namespace BoslaApp2.MvvM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddImagePage : ContentPage
    {
        public AddImagePage()
        {
            InitializeComponent();

            var imageService = new ImagesService();
            var courseImage = imageService.Get(1);

            image.Source = ImageSource.FromStream(()=>
            {
                return GetStream(courseImage.Image);
            });

        }

        private string CurrentImageBase64 { set; get; }

        private async void BtnTakePhoto_Clicked(object sender, EventArgs e)
        {
            var current = Plugin.Media.CrossMedia.Current;
            if (current.IsCameraAvailable && current.IsTakePhotoSupported)
            {
                var photo = await current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    CompressionQuality = 70
                });

                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = photo.GetStream();
                    CurrentImageBase64 = GetBase64(photo.GetStream());
                    photo.Dispose();
                    return stream;
                });

                BtnSavePhoto.IsVisible = true;
            }
        }



        private async void BtnSavePhoto_Clicked(object sender, EventArgs e)
        {
            
            //Save to DB
            
            var imageService = new ImagesService();
            var imageDB = new CourseImage
            {
                Image = CurrentImageBase64
            };
            int result = imageService.CreateImage(imageDB);

            await DisplayAlert("Course", result.ToString(), "Ok");
        }


        private string GetBase64(Stream stream)
        {
            byte[] array;

            using (MemoryStream memory = new MemoryStream())
            {
                stream.CopyTo(memory);
                array = memory.ToArray();
            }

            return Convert.ToBase64String(array);
        }

        private Stream GetStream(string base64)
        {
            byte[] array = Convert.FromBase64String(base64);

            return new MemoryStream(array);
        }
    }
}