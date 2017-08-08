using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImgView : ContentView
    {
        private Dictionary<int, string> images = new Dictionary<int, string>()
        {
            {1,"a.jpg"},
            {2,"b.jpg"}
        };
        private int CurrentIndex = 0;

        private bool bRotation = false;


        public ImgView()
        {
            InitializeComponent();

            ChangeImgTimer();
        }

        private void ChangeImgTimer()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Task.Factory.StartNew(async () =>
                {
                    await Task.Run(() => ChangeImageIndex());
                    
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        imgSlide.Source = images[CurrentIndex].ToString();

                        if (bRotation)
                        {
                            Random random = new Random();
                            int nRnd = random.Next(360);
                            imgSlide.RotateTo((CurrentIndex * nRnd), 50000);
                            imgSlide.Rotation = 0;
                        }
                        
                        ChangeImgTimer();
                    });
                });

                return false;
            });
        }

        private void ChangeImageIndex()
        {           
            CurrentIndex++;

            if (CurrentIndex > (images.Count))
                CurrentIndex = 1;
        }

    }
}