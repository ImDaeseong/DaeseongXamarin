using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace App1
{    
    public interface IMp3Player : IDisposable
    {
        event EventHandler PlayMp3Completed;

        string MP3Value { get; set; }

        void Play();

        void Pause();

        void Stop();

        void Seek(double position);
        
        double Duration { get; }

        double CurrentPosition { get; }

        bool IsPlaying { get; }
                      
        bool CanSeek { get; }

        double Volume { get; set; }

        double Balance { get; set; }

        List<string> GetMusic();

        ObservableCollection<string> GetDirectorys();

        ObservableCollection<string> GetMp3List(string sDirectory);        
    }
    
}
