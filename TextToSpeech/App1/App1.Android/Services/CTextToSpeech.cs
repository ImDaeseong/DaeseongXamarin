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
        private string sToSpeak;

        public CTextToSpeech() { }

        public void Speak(string sText)
        {
            var ctx = Forms.Context; // useful for many Android SDK features
            sToSpeak = sText;
            if (speaker == null)
            {
                speaker = new TextToSpeech(ctx, this);
                //speaker.SetLanguage(language);
            }
            else
            {
                speaker.SetLanguage(language);

                if (Build.VERSION.Release.StartsWith("4"))
                {
                    speaker.Speak(sToSpeak, QueueMode.Flush, null);
                }
                else
                {
                    speaker.Speak(sToSpeak, QueueMode.Flush, null, null);
                }

                /*
                var p = new Dictionary<string, string>();
                speaker.SetLanguage(language);
                speaker.Speak(sToSpeak, QueueMode.Flush, p);
                */
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
                if (Build.VERSION.Release.StartsWith("4"))
                {
                    speaker.Speak(sToSpeak, QueueMode.Flush, null);
                }
                else
                {
                    speaker.Speak(sToSpeak, QueueMode.Flush, null, null);
                }

                /*
                var p = new Dictionary<string, string>();
                speaker.Speak(sToSpeak, QueueMode.Flush, p);
                */
            }
        }

    }
}