
namespace App1.Services
{
    public interface IVoiceRecorder
    {
        bool PrepareRecord();
        bool Record();
        void Play(string path);
        void StopRecord();

        string GetPlayPath();
    }
}
