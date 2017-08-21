using System;

namespace App1.Services
{
    public interface ITextSpeechService
    {        
        void Speak(string text);
        void SetLanguage(string language);
    }
}
