using System;
using Android.Speech.Tts;
using Java.Util;
using Xamarin.Forms;
using App1.Services;
using App1.Droid.Services;

[assembly: Dependency(typeof(TextSpeechService))]
namespace App1.Droid.Services
{
    class TextSpeechService : Java.Lang.Object, ITextSpeechService, TextToSpeech.IOnInitListener
    {
        protected static System.Random rnd = new System.Random(Guid.NewGuid().GetHashCode());
        TextToSpeech speaker;
        private Locale language = Locale.Korean;
        
        public void Speak(string text)
        {
            var ctx = Forms.Context;

            if (speaker == null)
            {
                speaker = new TextToSpeech(ctx, this);
                speaker.SetLanguage(language);
            }
            else
            {
                speaker.SetLanguage(language);
                speaker.Speak(text, QueueMode.Flush, null, rnd.Next().ToString());
            }
        }

        public void SetLanguage(string language)
        {
            switch (language)
            {
                case "Japanese":
                    this.language = Locale.Japanese;
                    break;

                case "Korean":
                    this.language = Locale.Korean;
                    break;

                default:
                    this.language = Locale.Us;
                    break;
            }
        }

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                speaker.Speak("", QueueMode.Flush, null, rnd.Next().ToString());
            }
        }
    }

    
}