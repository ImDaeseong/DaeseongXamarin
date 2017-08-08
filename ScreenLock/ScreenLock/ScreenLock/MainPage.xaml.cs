using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScreenLock
{
    public partial class MainPage : ContentPage
    {
        private Dictionary<int, string> images = new Dictionary<int, string>()
        {
            {1,"a.jpg"},
            {2,"b.jpg"}
        };
        private int CurrentIndex = 0;
        

        private double startScale = 0;
        private double currentScale = 0;


        private ITimer timer;
        private void Start()
        {
            timer = DependencyService.Get<ITimer>();
            timer.IntervalTime = TimeSpan.FromSeconds(5);
            timer.AutoReset = true;//계속
            //timer.AutoReset = false;//딱 한번만 
            timer.Elapsed += Timer_Elapsed;
        }
        
        private void Timer_Elapsed(object sender, EventArgs e)
        {
            try
            {
                ChangeImage();
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
            }
        }

        private void ChangeImage()
        {
            CurrentIndex++;

            if (CurrentIndex > (images.Count))
                CurrentIndex = 1;
            
            System.Diagnostics.Debug.WriteLine(images[CurrentIndex].ToString());
            
            //다른 이미지로 변경시 오류 발생, 이유가? 
            //playerImage.Source = images[CurrentIndex].ToString();
            
            Random random = new Random();
            int nRnd = random.Next(360);
            playerImage.RotateTo((CurrentIndex * nRnd), 50000);
            //playerImage.Rotation = 0;
        }

        private void Stop()
        {
            timer?.Stop();
            timer = null;
        }

        private void Reset()
        {
            timer?.Reset();
        }

        public MainPage()
        {
            InitializeComponent();

            BackgroundColor = Color.FromHex("#253648");

            playerImage.Source = ImageSource.FromFile("bg.png");
            playerImage.Aspect = Aspect.AspectFill;
            

            SetLockUnLock(true);

            //ContentPage NavigationPage 에서 titlebar hide
            NavigationPage.SetHasNavigationBar(this, false);

            Start();    
        }

        protected override void OnAppearing()
        {
            Reset();

            base.OnAppearing();
        }

        private void SetLockUnLock(bool bLock)
        {
            if (bLock)
                DependencyService.Get<IScreenLock>().Lock();
            else
                DependencyService.Get<IScreenLock>().Unlock();
        }
                
        private void PinchUpdated_Event(object sender, PinchGestureUpdatedEventArgs e)
        {
            return;
            /*
            Image img = (Image)sender;
            switch (e.Status)
            {
                case GestureStatus.Started:
                    {
                        this.startScale = this.Scale;
                    }
                    break;
                case GestureStatus.Running:
                    this.currentScale += (e.Scale - 1) * this.startScale;
                    this.currentScale = Math.Max(1, this.currentScale);
                    this.Scale = currentScale;
                    break;
                case GestureStatus.Completed:
                    break;
                default:
                    break;
            }
            */
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Stop();

            SetLockUnLock(false);

            DependencyService.Get<ICloseApplication>().Exit();
        }
    }        
}
