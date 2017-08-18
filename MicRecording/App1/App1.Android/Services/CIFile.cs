using System.IO;
using Android.OS;
using Xamarin.Forms;
using App1.Droid.Services;
using App1.Services;

[assembly: Dependency(typeof(CIFile))]
namespace App1.Droid.Services
{
    public class CIFile : IFile
    {
        public string DataStorage => global::Android.App.Application.Context.FilesDir.AbsolutePath;
        public string ApplicationStorage => global::Android.App.Application.Context.DataDir.AbsolutePath;
        public string TempStorage => global::Android.App.Application.Context.CacheDir.AbsolutePath;
        public string CacheStorage => global::Android.App.Application.Context.CacheDir.AbsolutePath;
        public string ExternalStorage => Environment.ExternalStorageDirectory.AbsolutePath;
        public string SyncedStorage => "";

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

    }
}