using AVFoundation;
using Xamarin.Forms;
using App1.iOS.Services;
using App1.Services;

[assembly: Dependency(typeof(CTextToSpeech))]
namespace App1.iOS.Services
{
    public class CTextToSpeech : ITextToSpeech
    {
        private readonly AVSpeechSynthesizer speechSynthesizer = new AVSpeechSynthesizer();
        private AVSpeechSynthesisVoice language = AVSpeechSynthesisVoice.FromLanguage("ko-KR");

        public CTextToSpeech()
        {
        }

        public bool IsSpeaking
        {
            get { return this.speechSynthesizer.Speaking; }
        }

        public void Speak(string text, double pitch, double speed)
        {
            var speechUtterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
                Voice = language,//AVSpeechSynthesisVoice.FromLanguage("ko-KR"),
                Volume = 0.5f,
                PitchMultiplier = (float)pitch//1.0f
            };
            speechSynthesizer.SpeakUtterance(speechUtterance);
        }

        public void Stop()
        {
            this.speechSynthesizer.StopSpeaking(AVSpeechBoundary.Immediate);
        }

        public void SetLanguage(string sLanguage)
        {
            switch (sLanguage)
            {
                case "Japanese":
                    this.language = AVSpeechSynthesisVoice.FromLanguage("ja-JP");
                    break;

                case "Korean":
                    this.language = AVSpeechSynthesisVoice.FromLanguage("ko-KR");
                    break;

                default:
                    this.language = AVSpeechSynthesisVoice.FromLanguage("en-US");
                    break;
            }
        }

    }



    /*
    class TextSpeechService : ITextSpeechService
    {
        private AVSpeechSynthesisVoice language = AVSpeechSynthesisVoice.FromLanguage("ko-KR");

        public void Speak(string text)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();

            var speechUtterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
                Voice = language,//AVSpeechSynthesisVoice.FromLanguage("ko-KR"),
                Volume = 0.5f,
                PitchMultiplier = 1.0f
            };

            speechSynthesizer.SpeakUtterance(speechUtterance);
        }

        public void SetLanguage(string language)
        {
            switch (language)
            {
                case "Japanese":
                    this.language = AVSpeechSynthesisVoice.FromLanguage("ja-JP");
                    break;

                case "Korean":
                    this.language = AVSpeechSynthesisVoice.FromLanguage("ko-KR");
                    break;

                default:
                    this.language = AVSpeechSynthesisVoice.FromLanguage("en-US");
                    break;
            }
        }
    }
    */
}