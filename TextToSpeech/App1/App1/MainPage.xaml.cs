using App1.Services;
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

        private void Button1_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<ITextSpeechService>().Speak("안녕하세요");            
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {            
            DependencyService.Get<ITextToSpeech>().Speak("안녕하세요");
        }
    }
}
