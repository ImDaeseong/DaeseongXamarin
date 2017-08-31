
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using shSpeak.Interface;

namespace shSpeak.controls
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

        public IEnumerable<string> GetInstalledLanguages
        {
            get
            {
                return TextToSpeech.GetInstalledLanguages();
            }
        } 

    }

}
