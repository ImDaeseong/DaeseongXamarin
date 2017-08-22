using System;
using Xamarin.Forms;

namespace App1.Services
{
    public class ToSpeak
    {
        private static ToSpeak selfInstance = null;
        public static ToSpeak getInstance
        {
            get
            {
                if (selfInstance == null) selfInstance = new ToSpeak();
                return selfInstance;
            }
        }

        static ITextToSpeech TextToSpeech
        {
            get
            {
                return DependencyService.Get<ITextToSpeech>();
            }
        }

        public void InitSpeak()
        {
            TextToSpeech.Speak("", 0f, 0f);
        }


        public void Speak(string sText, double pitch, double speed)
        {
            TextToSpeech.Speak(sText, pitch, speed);
        }

        public void SetLanguage(string sLanguage)
        {
            TextToSpeech.SetLanguage(sLanguage);
        }

        public bool IsSpeaking
        {
            get
            {
                return TextToSpeech.IsSpeaking;
            }
        }


    }
}
