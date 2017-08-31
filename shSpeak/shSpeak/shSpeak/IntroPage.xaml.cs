﻿using shSpeak.controls;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace shSpeak
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IntroPage : CarouselPage
    {
        private SpeakSetting Setting = SpeakSetting.getInstance;

        public IntroPage()
        {
            InitializeComponent();
        }

        private void next1_Clicked(object sender, EventArgs e)
        {
            CurrentPage = page2;
        }

        private async void next2_Clicked(object sender, EventArgs e)
        {
            Setting.IntroPopup = true;

            await Navigation.PopModalAsync();
        }        

    }
}