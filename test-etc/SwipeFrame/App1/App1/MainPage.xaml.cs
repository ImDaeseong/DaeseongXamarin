using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            GestureFrame gi = new GestureFrame
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("bf3122"),
            };

            gi.SwipeDown += (s, e) =>
            {
                DisplayAlert("Gesture Info", "Swipe Down Detected", "OK");
            };

            gi.SwipeTop += (s, e) =>
            {
                DisplayAlert("Gesture Info", "Swipe Top Detected", "OK");
            };

            gi.SwipeLeft += (s, e) =>
            {
                DisplayAlert("Gesture Info", "Swipe Left Detected", "OK");
            };

            gi.SwipeRight += (s, e) =>
            {
                DisplayAlert("Gesture Info", "Swipe Right Detected", "OK");
            };
            this.Content = gi;

        }
    }
}
