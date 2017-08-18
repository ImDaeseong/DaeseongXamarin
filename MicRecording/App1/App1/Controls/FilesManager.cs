using Xamarin.Forms;
using App1.Services;

namespace App1.Controls
{
    public static class FilesManager
    {
        private static readonly IFile FileDependency = DependencyService.Get<IFile>();

        public static string ApplicationStorage => FileDependency.ApplicationStorage;
        public static string DataStorage => FileDependency.DataStorage;
        public static string TempStorage => FileDependency.TempStorage;
        public static string CacheStorage => FileDependency.CacheStorage;
        public static string ExternalStorage => FileDependency.ExternalStorage;
        public static string SyncedStorage => FileDependency.SyncedStorage;

        public static bool FileExists(string path)
        {
            return FileDependency.FileExists(path);
        }
    }
}
