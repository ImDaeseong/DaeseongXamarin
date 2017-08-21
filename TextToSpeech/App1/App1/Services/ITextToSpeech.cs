using System;

namespace App1.Services
{
    public interface ITextToSpeech
    {
        void Speak(string sText);
        void SetLanguage(string language);
    }
}
