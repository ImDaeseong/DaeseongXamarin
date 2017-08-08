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

        private const string BackgroundImageTokenkey = "BackgroundImage_key";
        private static readonly string BackgroundImageDefault = "bg.png";
        public static string BackgroundImage
        {
            get { return AppSettings.GetValueOrDefault<string>(BackgroundImageTokenkey, BackgroundImageDefault); }
            set { AppSettings.AddOrUpdateValue<string>(BackgroundImageTokenkey, value); }
        }


        private const string PageNameTokenkey = "PageName_key";
        private static readonly string PageNameDefault = "AboutPage";
        public static string PageName
        {
            get { return AppSettings.GetValueOrDefault<string>(PageNameTokenkey, PageNameDefault); }
            set { AppSettings.AddOrUpdateValue<string>(PageNameTokenkey, value); }
        }
        

        private const string MusicTokenKey = "musicname_key";
        private static readonly int MusicTokenDefault = 0;

        public static int MusicToken
        {
            get { return AppSettings.GetValueOrDefault<int>(MusicTokenKey, MusicTokenDefault); }
            set { AppSettings.AddOrUpdateValue<int>(MusicTokenKey, value); }
        }
    }

}
