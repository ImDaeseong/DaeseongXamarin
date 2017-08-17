using System;

namespace App1.Services
{
    public interface AudioPlayer
    {
        void PlayAudio();
        void StopAudio();
        void PauseAudio();
        string AudioFileName { get; set; }
        string AudioFilePath { get; set; }
    }
}
