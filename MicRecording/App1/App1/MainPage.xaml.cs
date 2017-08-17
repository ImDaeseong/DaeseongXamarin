using App1.Controls;
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
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.Animate("SlideInLeft", (s) => Layout(new Rectangle(-1 * ((1 - s) * Width), Y, Width, Height)), 0, 600, Easing.SpringIn, null, null);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await InitAnimation();

        }
        

        async Task InitAnimation()
        {
            frame1.IsVisible = false;
            frame2.IsVisible = false;
            await animates(frame1);
            await Task.Delay(500);
            await animates(frame2);
        }

        async Task animates(View view)
        {
            view.IsVisible = true;
            var animate = new Animation();
            var slidein = new Animation(callback: ax => view.TranslationY = ax,
                            start: -Math.Abs(view.Height),
                             end: 0,
                            easing: Easing.SinOut);
            animate.Add(0, 1, slidein);
            animate.Commit(view, "SlideIn", length: 750);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.WaitAny(SlideInLeft(slidesl));            
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.WaitAny(SlideInRight(slidesl));

            //SlideIn();

            //SlideOut();

            //RotateExpand();

            //RotateCollapse();

            //Pulse(lblText);
        }

        async Task Pulse(Label voteLabel)
        {
            await voteLabel.ScaleTo(1.25, 50);
            await voteLabel.ScaleTo(1, 75);
        }


        async Task SlideInLeft(View view)
        {
            view.FadeTo(0);
            view.IsVisible = true;
            var animate = new Animation();
            var registerin = new Animation(callback: ax => view.TranslationX = ax,
                    start: Width,
                    end: 0,
                    easing: Easing.SpringOut);
            animate.Add(0, 1, registerin);
            animate.Commit(view, "RegisterIn", length: 1000);
            view.FadeTo(1);
        }

        async Task SlideInRight(View view)
        {
            view.FadeTo(0);
            view.IsVisible = true;
            var animate = new Animation();
            var registerin = new Animation(callback: ax => view.TranslationX = ax,
                    start: -Width,
                    end: 0,
                    easing: Easing.SpringOut);
            animate.Add(0, 1, registerin);
            animate.Commit(view, "RegisterIn", length: 1000);
            view.FadeTo(1);
        }


        async Task SlideIn()
        {
            this.FadeTo(0);
            var animate = new Animation();
            var slidein = new Animation(callback: ax => this.TranslationY = ax,
                    start: Height,
                    end: 0,
                    easing: Easing.SpringOut);
            animate.Add(0, 1, slidein);
            animate.Commit(this, "SlideIn", length: 1000);
            this.FadeTo(1);
        }

        async Task SlideOut()
        {
            this.FadeTo(1);
            var animate = new Animation();
            var slideout = new Animation(callback: ax => this.TranslationY = ax,
                   start: 0,
                   end: -Height,
                   easing: Easing.SpringIn);
            animate.Add(0, 1, slideout);
            animate.Commit(this, "SlideOut", length: 1000);
            this.FadeTo(0);
        }

        async Task RotateExpand()
        {
            var animate = new Animation();
            var rotation = new Animation(callback: d => icon.Rotation = d,
                    start: icon.Rotation,
                    end: icon.Rotation + 45,
                    easing: Easing.SpringOut);
            animate.Add(0, 1, rotation);
            animate.Commit(this, "Rotation", length: 250);
        }

        async Task RotateCollapse()
        {
            var animate = new Animation();
            var rotation = new Animation(callback: d => icon.Rotation = d,
                    start: icon.Rotation,
                    end: icon.Rotation - 45,
                    easing: Easing.SpringOut);
            animate.Add(0, 1, rotation);
            animate.Commit(this, "Rotation", length: 250);
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            var animation = new Animation(callback: d => a1.Rotation = d,
                                  start: a1.Rotation,
                                  end: a1.Rotation + 360,
                                  easing: Easing.SpringOut);
            animation.Commit(a1, "Loop", length: 800);
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            var width = Application.Current.MainPage.Width;

            var storyboard = new Animation();
            var rotation = new Animation(callback: d => a2.Rotation = d,
                                          start: a2.Rotation,
                                          end: a2.Rotation + 360,
                                          easing: Easing.SpringOut);


            var exitRight = new Animation(callback: d => a2.TranslationX = d,
                                           start: 0,
                                           end: width,
                                           easing: Easing.SpringIn);

            var enterLeft = new Animation(callback: d => a2.TranslationX = d,
                                           start: -width,
                                           end: 0,
                                           easing: Easing.BounceOut);

            storyboard.Add(0, 1, rotation);
            storyboard.Add(0, 0.5, exitRight);
            storyboard.Add(0.5, 1, enterLeft);

            storyboard.Commit(a2, "Loop", length: 1400);
        }

        private async void a3_Clicked(object sender, EventArgs e)
        {
            Rectangle rRect = new Rectangle(tsl.Bounds.X, tsl.Bounds.Y, tsl.Bounds.Width, tsl.Bounds.Height);
            rRect.Left -= Width;

            await tsl.LayoutTo(rRect, 300, Easing.Linear);

            rRect.Left += Width;
            await tsl.LayoutTo(rRect, 300, Easing.Linear);
            
        }

        private async void a4_Clicked(object sender, EventArgs e)
        {
            Rectangle rRect = new Rectangle(tsl.Bounds.X, tsl.Bounds.Y, tsl.Bounds.Width, tsl.Bounds.Height);
            rRect.Left += Width;

            await tsl.LayoutTo(rRect, 300, Easing.Linear);

            rRect.Left -= Width;
            await tsl.LayoutTo(rRect, 300, Easing.Linear);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("controls:CCircle", "click controls:CCircle", "OK");
        }
        
    }
    

}
