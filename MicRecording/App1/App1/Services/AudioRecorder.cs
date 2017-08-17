using System;

namespace App1.Services
{
    public interface AudioRecorder
    {
        void StartRecord();
        void StopRecord();
        string AudioFileName { get; set; }
        string AudioFilePath { get; set; }
    }

}
