using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace App1
{
    public static class XamarinAppSettings
    {
        private static ISettings AppSettings
        {
            get { return CrossSettings.Current; }
        }

        /*
        private const string MusicTokenKey = "musicname_key";
        private static readonly string MusicTokenDefault = string.Empty;

        public static string MusicToken
        {
            get { return AppSettings.GetValueOrDefault<string>(MusicTokenKey, MusicTokenDefault); }
            set { AppSettings.AddOrUpdateValue<string>(MusicTokenKey, value); }
        }
        */

        private const string MusicTokenKey = "musicname_key";
        private static readonly int MusicTokenDefault = 0;

        public static int MusicToken
        {
            get { return AppSettings.GetValueOrDefault<int>(MusicTokenKey, MusicTokenDefault); }
            set { AppSettings.AddOrUpdateValue<int>(MusicTokenKey, value); }
        }
    }

}
