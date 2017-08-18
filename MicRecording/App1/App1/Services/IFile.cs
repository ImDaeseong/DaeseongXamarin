using System;

namespace App1.Services
{
    public interface IFile
    {
        string ApplicationStorage { get; }
        string DataStorage { get; }
        string TempStorage { get; }
        string CacheStorage { get; }
        string ExternalStorage { get; }
        string SyncedStorage { get; }
        bool FileExists(string path);
    }
}
