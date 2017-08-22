using System;

namespace App1.Services
{
    public interface ITextToSpeech
    {
        void Speak(string sText, double pitch, double speed);
        void SetLanguage(string sLanguage);
        bool IsSpeaking { get; }
    }
}
