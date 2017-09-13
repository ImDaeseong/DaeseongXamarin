using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App2.ShowPopup;
using App2.Dependencies;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        public IShowOverLay overlay;

        public double HeightX;
        public double WidthX;
        public LoadingOverlay loy;

        public IOverlayDependency overlayDep;

        public MainPage()
        {
            InitializeComponent();

            overlay = DependencyService.Get<IShowOverLay>();

            overlayDep = DependencyService.Get<IOverlayDependency>();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            overlay.ShowLoadingScreen(new XOverLayControl
            {
                Alpha = Device.OnPlatform(0.5f, 150, 1),
                BackgroundColor = Color.Gray
            });
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            try
            {
                overlay.HideAll();
            }catch { }

            try
            {
                overlayDep.HideOverlay();
            }catch { }

            try
            {
                loy.HideOverlay(this);
            } catch { }
        }


        private void OverlayDependency_Clicked(object sender, EventArgs e)
        {
            overlayDep.ShowOverlay("loading");
        }



        private void LoadingOverlay_Clicked(object sender, EventArgs e)
        {
            loy = new LoadingOverlay(MyStack, "Loading...", (int)HeightX, (int)WidthX, this);
            loy.ShowOverlay(this);
            MyStack.HeightRequest = HeightX;
            MyStack.WidthRequest = WidthX;
        }
        
        protected override void OnSizeAllocated(double width, double height)
        {
            HeightX = height;
            WidthX = width;

            base.OnSizeAllocated(width, height);
        }

        protected override void OnDisappearing()
        {
            if (loy != null)
            {
                loy.HideOverlay(this);
            }

            base.OnDisappearing();
        }

    }
}
