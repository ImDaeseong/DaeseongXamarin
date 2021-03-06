﻿using System;
using Xamarin.Forms;

namespace App2
{
    public class LoadingOverlay
    {
        private int Height { get; set; }
        private int Width { get; set; }
        private Color BackColor { get; set; }
        private string LoadingString { get; set; }
        private StackLayout TheirStack { get; set; }
        private StackLayout TopStack { get; set; }
        private StackLayout InStack { get; set; }
        public AbsoluteLayout MyAbsolute { get; set; }

        private Label MyOverlayText { get; set; }
        private ActivityIndicator MyActivator { get; set; }


        public LoadingOverlay(StackLayout YourStack, string loadingString, int DeviceHeight, int DeviceWidth, ContentPage YourPage)
        {
            Height = DeviceHeight;
            Width = DeviceWidth;

            this.LoadingString = loadingString;
            TheirStack = new StackLayout();
            TheirStack = YourStack;

            MyAbsolute = new AbsoluteLayout();
            MyAbsolute.Children.Add(YourStack);

            TopStack = new StackLayout();
            TopStack.HeightRequest = DeviceHeight;
            TopStack.WidthRequest = DeviceWidth;

            BackColor = Color.FromRgba(0, 0, 0, 0.7);
            TopStack.BackgroundColor = this.BackColor;

            MyActivator = new ActivityIndicator();
            MyActivator.Color = Color.White;
            MyActivator.IsRunning = true;
            MyActivator.IsVisible = true;
            MyActivator.HorizontalOptions = LayoutOptions.CenterAndExpand;
            MyActivator.VerticalOptions = LayoutOptions.CenterAndExpand;

            MyOverlayText = new Label();
            MyOverlayText.FontSize = 25;
            MyOverlayText.TextColor = Color.White;
            MyOverlayText.Text = loadingString;
            MyOverlayText.HorizontalOptions = LayoutOptions.CenterAndExpand;
            MyOverlayText.VerticalOptions = LayoutOptions.CenterAndExpand;

            InStack = new StackLayout();
            InStack.VerticalOptions = LayoutOptions.CenterAndExpand;
            InStack.HorizontalOptions = LayoutOptions.CenterAndExpand;

            InStack.Children.Add(MyActivator);
            InStack.Children.Add(MyOverlayText);
            TopStack.Children.Add(InStack);
            TopStack.IsVisible = false;

            MyAbsolute.Children.Add(TopStack);
        }

        public void ChangeLoadingString(string NewString)
        {
            this.MyOverlayText.Text = NewString;
        }

        public void HideOverlay(ContentPage YourPage)
        {
            YourPage.Content = this.TheirStack;
        }

        public void ShowOverlay(ContentPage YourPage)
        {
            this.TopStack.IsVisible = true;
            YourPage.Content = MyAbsolute;
        }

    }

}
