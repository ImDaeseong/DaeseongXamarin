using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Services;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        private ToSpeak TextToSpeech = ToSpeak.getInstance;

        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (Input.Text == "") return;

            TextToSpeech.Speak(Input.Text, 1.0f, 1.0f);
        }
    }
}