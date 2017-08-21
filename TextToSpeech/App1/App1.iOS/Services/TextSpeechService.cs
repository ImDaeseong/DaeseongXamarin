using System;
using NUnit.Framework;
using AVFoundation;
using Xamarin.Forms;
using App1.Services;
using App1.iOS.Services;

[assembly: Dependency(typeof(TextSpeechService))]
namespace App1.iOS.Services
{
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
    
}