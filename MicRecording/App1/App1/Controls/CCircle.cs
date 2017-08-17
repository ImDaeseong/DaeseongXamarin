using System;
using Xamarin.Forms;

namespace App1.Controls
{
    public class CCircle : ContentView
    {       
        private const int size = 45;
        public CCircle()
        {
            Image image = new Image
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Source = ImageSource.FromFile("downloadbutton.png"),
                HeightRequest = size,
                WidthRequest = size,

            };
            Button button = new Button
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.FromRgb(250, 187, 59),
                HeightRequest = size,
                WidthRequest = size,
                BorderRadius = size / 2 + 1,
                //BorderColor = Color.Red,
                //BorderWidth = 0.7
            };
            button.Clicked += delegate
            {
                button.Opacity = .5;
                button.FadeTo(1);
            };
            AbsoluteLayout.SetLayoutFlags(image, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(image, new Rectangle(0, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(button, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(button, new Rectangle(0, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            Content = new AbsoluteLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HeightRequest = size,
                WidthRequest = size,
                Children = {
                    button,
                    image
                },
            };

            
        }


    }
}
