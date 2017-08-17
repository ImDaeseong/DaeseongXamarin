using System;
using Xamarin.Forms;

namespace App1.Controls
{
    public class HorizontalScroll : ScrollView
    {
        public HorizontalScroll()
        {
            this.BackgroundColor = Color.FromHex("0699E6");
            this.Orientation = ScrollOrientation.Horizontal;
            this.HeightRequest = 50;
            var stack = new StackLayout();
            stack.Orientation = StackOrientation.Horizontal;
            stack.HorizontalOptions = LayoutOptions.StartAndExpand;
            stack.Padding = new Thickness(10, 10, 10, 10);
            stack.Spacing = 10;
            stack.Children.Add(new Button { BackgroundColor = Color.Transparent, FontSize = 12, HorizontalOptions = LayoutOptions.Center, BorderColor = Color.White, BorderWidth = 1.5, Text = "All", TextColor = Color.White, HeightRequest = 27, BorderRadius = (int)(double)(27 / 2), WidthRequest = 80 });
            stack.Children.Add(new Button { BackgroundColor = Color.Transparent, FontSize = 12, HorizontalOptions = LayoutOptions.Center, BorderColor = Color.White, BorderWidth = 1.5, Text = "Beauty", TextColor = Color.White, HeightRequest = 27, BorderRadius = (int)(double)(27 / 2), WidthRequest = 80 });
            stack.Children.Add(new Button { BackgroundColor = Color.Transparent, FontSize = 12, HorizontalOptions = LayoutOptions.Center, BorderColor = Color.White, BorderWidth = 1.5, Text = "Food", TextColor = Color.White, HeightRequest = 27, BorderRadius = (int)(double)(27 / 2), WidthRequest = 80 });
            stack.Children.Add(new Button { BackgroundColor = Color.Transparent, FontSize = 12, HorizontalOptions = LayoutOptions.Center, BorderColor = Color.White, BorderWidth = 1.5, Text = "Gamsd", TextColor = Color.White, HeightRequest = 27, BorderRadius = (int)(double)(27 / 2), WidthRequest = 80 });
            stack.Children.Add(new Button { BackgroundColor = Color.Transparent, FontSize = 12, HorizontalOptions = LayoutOptions.Center, BorderColor = Color.White, BorderWidth = 1.5, Text = "dsad", TextColor = Color.White, HeightRequest = 27, BorderRadius = (int)(double)(27 / 2), WidthRequest = 80 });
            stack.Children.Add(new Button { BackgroundColor = Color.Transparent, FontSize = 12, HorizontalOptions = LayoutOptions.Center, BorderColor = Color.White, BorderWidth = 1.5, Text = "dsad", TextColor = Color.White, HeightRequest = 27, BorderRadius = (int)(double)(27 / 2), WidthRequest = 80 });
            this.Content = stack;
        }
    }

}
