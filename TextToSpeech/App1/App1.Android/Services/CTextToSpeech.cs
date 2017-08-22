using Android.Speech.Tts;
using Xamarin.Forms;
using Android.OS;
using App1.Droid.Services;
using App1.Services;
using Java.Util;

[assembly: Dependency(typeof(CTextToSpeech))]
namespace App1.Droid.Services
{
    public class CTextToSpeech : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        private TextToSpeech speaker;
        private Locale language = Locale.Korean;

        public bool IsInitialized { get; private set; }
        public bool IsSpeaking { get; private set; }

        public CTextToSpeech()
        {
            speaker = new TextToSpeech(Forms.Context.ApplicationContext, this);
        }


        public void Speak(string sText, double pitch, double speed)
        {
            if (this.IsSpeaking || !this.IsInitialized)
                return;

            this.IsSpeaking = true;
            try
            {
                this.speaker.SetLanguage(language);
                
                this.speaker.SetPitch((float)pitch);
                this.speaker.SetSpeechRate((float)speed);

                this.speaker.Speak(sText, QueueMode.Flush, null, null);
            }
            finally
            {
                this.IsSpeaking = false;
            }
        }

        public void Stop()
        {
            if (!this.IsSpeaking) return;

            try
            {
                this.speaker.Stop();
            }
            finally
            {
                this.IsSpeaking = false;
            }
        }

        public void SetLanguage(string sLanguage)
        {
            switch (sLanguage)
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
            this.IsInitialized = (status == OperationResult.Success);
        }
    }



    /*
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
    */
}