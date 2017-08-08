using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using System.Collections.ObjectModel;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        private IConvertImage convertImg;
        
        private int CurrentIndex = 0;
        private static readonly int TotalCount = 13;
        private ImageSource[] imgList = new ImageSource[TotalCount];

        public MainPage()
        {
            InitializeComponent();
                                   
            convertImg = DependencyService.Get<IConvertImage>();

            //byte[] bytes = convertImg.ImageToBinary("sprite.png");
            //changeimg.Source = LoadByteImage(bytes);    


            convertImg.LoadImageSource("sprite.png");

            //GetImgList();

            ChangeImgTimer();
        }
            
        private void GetImgList()
        {
            for(int i=0; i < TotalCount; i++)
            {
                imgList[i] = convertImg.CropImage(i);
            }
        }
      
        protected override void OnAppearing()
        {
            base.OnAppearing();                
        }

        private ImageSource LoadByteImage(byte[] buffer)
        {
            ImageSource retSource = null;
            if (buffer != null)
                retSource = ImageSource.FromStream(() => new MemoryStream(buffer));
            return retSource;
        }

        private void ChangeImgTimer()
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(50), () =>
            {
                Task.Factory.StartNew(async () =>
                {
                    await Task.Run(() => ChangeImageIndex());

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        //이미지 쪼개서 하나의 이미지소스에 하면 깜빡임 현상이 생기네
                        changeimg.Source = LoadByteImage(convertImg.Crop(CurrentIndex));

                        /*
                        if (CurrentIndex == TotalCount)
                            CurrentIndex = 0;
                        changeimg.Source = imgList[CurrentIndex];
                        */

                        ChangeImgTimer();
                    });
                });

                return false;
            });
        }

        private void ChangeImageIndex()
        {
            CurrentIndex++;

            if (CurrentIndex > (TotalCount))
                CurrentIndex = 0;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await AnimateHeart();

            await ShowWaitMessage("메시지 테스트");
        }

       
        private async Task ShowWaitMessage(string sMsg)
        {
             await Task.Run(async () =>
             {
                 await Task.Delay(1000);
                 Device.BeginInvokeOnMainThread(() => DisplayAlert(sMsg, "", "OK"));
             });
        }

        private async Task<bool> AnimateHeart()
        {            
            Device.BeginInvokeOnMainThread(
                async () =>
                {
                    await HeartImage.ScaleTo(1.2, 50, Easing.SinInOut);
                    await HeartImage.ScaleTo(1, 50, Easing.SinInOut);
                });           

            /*
            Device.BeginInvokeOnMainThread(
                async () =>
                {
                    await HeartImage.ScaleTo(0.95);
                    await HeartImage.ScaleTo(1);
                });
            */

            /*
            Device.BeginInvokeOnMainThread(() =>
            {
                HeartImage.FadeTo(0);
                HeartImage.TranslateTo(0, 150);
            });
            */
            
            /*
            Device.BeginInvokeOnMainThread(() =>
            {
                HeartImage.FadeTo(1);
                HeartImage.TranslateTo(0, 0);
            });
            */

            return true;
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await AnimateTest();
        }

        private async Task<bool> AnimateTest()
        {
            /*
            Device.BeginInvokeOnMainThread(
               async () =>
               {
                   MainImage.Animate("Jump", Jump(), 16, 1000);
               });
            */

            /*
            Device.BeginInvokeOnMainThread(
               async () =>
               {
                   MainImage.Animate("BounceIn", BounceIn(), 16, 1000);
               });
            */

            /*
            Device.BeginInvokeOnMainThread(
               async () =>
               {
                   MainImage.Animate("BounceOut", BounceOut(), 16, 1000);
               });
            */

            /*
            Device.BeginInvokeOnMainThread(
               async () =>
               {
                   MainImage.Animate("FadeIn", FadeIn(), 16, 1000);
               });
            */

            /*
            Device.BeginInvokeOnMainThread(
              async () =>
              {
                  MainImage.Animate("FadeOut", FadeOut(), 16, 1000);
              });
            */

            /*
            Device.BeginInvokeOnMainThread(
             async () =>
             {
                 MainImage.Animate("Flip", Flip(), 16, 1000);
             });
            */

            /*
            Device.BeginInvokeOnMainThread(
             async () =>
             {
                 MainImage.Animate("Hearth", Hearth(), 16, 1000);
             });
            */

            /*
            Device.BeginInvokeOnMainThread(
             async () =>
             {
                 MainImage.Animate("TurnstileIn", TurnstileIn(), 16, 1000);
             });
             */

            /*
            Device.BeginInvokeOnMainThread(
             async () =>
             {
                 MainImage.Animate("TurnstileOut", TurnstileOut(), 16, 1000);
             });
             */

            Device.BeginInvokeOnMainThread(
             async () =>
             {
                 MainImage.Animate("Shake", Shake(), 16, 1000);
             });

            return true;
        }


        internal Animation Shake()
        {
            const int Movement = 5;

            var animation = new Animation();

            animation.WithConcurrent(
              (f) => MainImage.TranslationX = f,
              MainImage.TranslationX + Movement, MainImage.TranslationX,
              Xamarin.Forms.Easing.Linear, 0, 0.1);

            animation.WithConcurrent(
                (f) => MainImage.TranslationX = f,
                MainImage.TranslationX - Movement, MainImage.TranslationX,
                Xamarin.Forms.Easing.Linear, 0.1, 0.2);

            animation.WithConcurrent(
                (f) => MainImage.TranslationX = f,
                MainImage.TranslationX + Movement, MainImage.TranslationX,
                Xamarin.Forms.Easing.Linear, 0.2, 0.3);

            animation.WithConcurrent(
                (f) => MainImage.TranslationX = f,
                MainImage.TranslationX - Movement, MainImage.TranslationX,
                Xamarin.Forms.Easing.Linear, 0.3, 0.4);

            animation.WithConcurrent(
                 (f) => MainImage.TranslationX = f,
                 MainImage.TranslationX + Movement, MainImage.TranslationX,
                 Xamarin.Forms.Easing.Linear, 0.4, 0.5);

            animation.WithConcurrent(
                (f) => MainImage.TranslationX = f,
                MainImage.TranslationX - Movement, MainImage.TranslationX,
                Xamarin.Forms.Easing.Linear, 0.5, 0.6);

            animation.WithConcurrent(
                 (f) => MainImage.TranslationX = f,
                 MainImage.TranslationX + Movement, MainImage.TranslationX,
                 Xamarin.Forms.Easing.Linear, 0.6, 0.7);

            animation.WithConcurrent(
                (f) => MainImage.TranslationX = f,
                MainImage.TranslationX - Movement, MainImage.TranslationX,
                Xamarin.Forms.Easing.Linear, 0.7, 0.8);

            return animation;
        }

        internal Animation TurnstileIn()
        {
            var animation = new Animation();

            animation.WithConcurrent((f) => MainImage.RotationY = f, 75, 0, Xamarin.Forms.Easing.CubicOut);
            animation.WithConcurrent((f) => MainImage.Opacity = f, 0, 1, null, 0, 0.01);

            return animation;
        }

        internal Animation TurnstileOut()
        {
            var animation = new Animation();

            animation.WithConcurrent((f) => MainImage.RotationY = f, 0, -75, Xamarin.Forms.Easing.CubicOut);
            animation.WithConcurrent((f) => MainImage.Opacity = f, 1, 0, null, 0.9, 1);

            return animation;
        }


        internal Animation Hearth()
        {
            var animation = new Animation();

            animation.WithConcurrent(
               (f) => MainImage.Scale = f,
               MainImage.Scale, MainImage.Scale,
               Xamarin.Forms.Easing.Linear, 0, 0.1);

            animation.WithConcurrent(
               (f) => MainImage.Scale = f,
               MainImage.Scale, MainImage.Scale * 1.1,
               Xamarin.Forms.Easing.Linear, 0.1, 0.4);

            animation.WithConcurrent(
               (f) => MainImage.Scale = f,
               MainImage.Scale * 1.1, MainImage.Scale,
               Xamarin.Forms.Easing.Linear, 0.4, 0.5);

            animation.WithConcurrent(
              (f) => MainImage.Scale = f,
              MainImage.Scale, MainImage.Scale * 1.1,
              Xamarin.Forms.Easing.Linear, 0.5, 0.8);

            animation.WithConcurrent(
               (f) => MainImage.Scale = f,
               MainImage.Scale * 1.1, MainImage.Scale,
               Xamarin.Forms.Easing.Linear, 0.8, 1);

            return animation;
        }



        public enum FlipDirection
        {
            Left,
            Right
        }

        internal Animation Flip()
        {
            FlipDirection Direction = FlipDirection.Left;

            var animation = new Animation();

            animation.WithConcurrent((f) => MainImage.Opacity = f, 0.5, 1);
            animation.WithConcurrent((f) => MainImage.RotationY = f, (Direction == FlipDirection.Left) ? 90 : -90, 0, Xamarin.Forms.Easing.Linear);

            return animation;
        }


        internal Animation Jump()
        {
            const int Movement = -25;

            var animation = new Animation();

            animation.WithConcurrent(
              (f) => MainImage.TranslationY = f,
              MainImage.TranslationY, MainImage.TranslationX,
              Xamarin.Forms.Easing.Linear, 0, 0.2);

            animation.WithConcurrent(
              (f) => MainImage.TranslationY = f,
              MainImage.TranslationY + Movement, MainImage.TranslationX,
              Xamarin.Forms.Easing.Linear, 0.2, 0.4);

            animation.WithConcurrent(
             (f) => MainImage.TranslationY = f,
             MainImage.TranslationY, MainImage.TranslationX,
             Xamarin.Forms.Easing.Linear, 0.5, 1.0);

            return animation;
        }

        internal Animation BounceIn()
        {
            var animation = new Animation();

            animation.WithConcurrent(
                           f => MainImage.Scale = f,
                            0.5, 1,
                           Xamarin.Forms.Easing.Linear, 0, 1);

            animation.WithConcurrent(
                    (f) => MainImage.Opacity = f,
                    0, 1,
                    null,
                    0, 0.25);

            return animation;
        }

        internal Animation BounceOut()
        {
            var animation = new Animation();

            MainImage.Opacity = 1;

            animation.WithConcurrent(
                (f) => MainImage.Opacity = f,
                1, 0,
                null,
                0.5, 1);

            animation.WithConcurrent(
                (f) => MainImage.Scale = f,
                1, 0.3,
                Xamarin.Forms.Easing.Linear, 0, 1);

            return animation;
        }

        enum FadeDirection
        {
            Up,
            Down
        }
        internal Animation FadeIn()
        {
            FadeDirection Direction = FadeDirection.Down;

            var animation = new Animation();

            animation.WithConcurrent((f) => MainImage.Opacity = f, 0, 1, Xamarin.Forms.Easing.CubicOut);

            animation.WithConcurrent(
              (f) => MainImage.TranslationY = f,
              MainImage.TranslationY + ((Direction == FadeDirection.Up) ? 50 : -50), MainImage.TranslationY,
              Xamarin.Forms.Easing.CubicOut, 0, 1);

            return animation;
        }

        internal Animation FadeOut()
        {
            FadeDirection Direction = FadeDirection.Up;

            var animation = new Animation();

            animation.WithConcurrent(
                 (f) => MainImage.Opacity = f,
                 1, 0);

            animation.WithConcurrent(
                  (f) => MainImage.TranslationY = f,
                  MainImage.TranslationY, MainImage.TranslationY + ((Direction == FadeDirection.Up) ? 50 : -50));

            return animation;
        }

    }
}
