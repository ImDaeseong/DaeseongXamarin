using App1.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        private Dictionary<int, string> images = new Dictionary<int, string>()
        {
            {1,"a.jpg"},
            {2,"b.jpg"}
        };
        private int CurrentIndex = 0;

        public MainPage()
        {
            InitializeComponent();

            CurrentIndex++;

            if (CurrentIndex > (images.Count))
                CurrentIndex = 1;

            cardimage.Source = images[CurrentIndex].ToString();
        }

        private void FancyFrame_OnSwipe(object sender, EventArgs e)
        {
            FadeToTest();
        }

        private async void FadeToTest()
        {
            await cardimage.FadeTo(0, 500);
            cardimage.Source = images[2].ToString();
            await cardimage.FadeTo(1, 500);
        }

        private void LinkLabel_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IStatusBar>().HideStatusBar();
            //DependencyService.Get<IStatusBar>().ShowStatusBar();
        }
    }
}
