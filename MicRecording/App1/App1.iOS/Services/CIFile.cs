using System;
using System.IO;
using Foundation;
using Xamarin.Forms;
using App1.iOS.Services;
using App1.Services;

[assembly: Dependency(typeof(CIFile))]
namespace App1.iOS.Services
{
    public class CIFile : IFile
    {
        public string DataStorage => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public string ApplicationStorage => Path.Combine(DataStorage, "..");
        public string TempStorage => Path.Combine(DataStorage, "..", "tmp");
        public string CacheStorage => Path.Combine(DataStorage, "..", "Library", "Caches");
        public string ExternalStorage => "";
        public string SyncedStorage => DataStorage;

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

    }
}