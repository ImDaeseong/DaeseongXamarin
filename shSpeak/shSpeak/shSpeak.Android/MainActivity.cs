using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Android.Content;
using Xamarin.Forms;
using Android.Provider;
using Android.Database;
using Java.Util.Regex;


namespace shSpeak.Droid
{
    [Activity(Label = "shSpeak", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            //AddShortcut();
        }

        private void AddShortcut()
        {
            var shortcutIntent = new Intent(this, typeof(MainActivity));
            shortcutIntent.SetAction(Intent.ActionMain);

            var iconResource = Intent.ShortcutIconResource.FromContext(
                this, Resource.Drawable.icon);

            var intent = new Intent();
            intent.PutExtra(Intent.ExtraShortcutIntent, shortcutIntent);
            intent.PutExtra(Intent.ExtraShortcutName, "혼자 말하기");
            intent.PutExtra(Intent.ExtraShortcutIconResource, iconResource);
            intent.SetAction("com.android.launcher.action.INSTALL_SHORTCUT");
            intent.PutExtra("duplicate", false);
            SendBroadcast(intent);                        
        }

        private void RemoveShortcut()
        {
            var shortcutIntent = new Intent(this, typeof(MainActivity));
            shortcutIntent.SetAction(Intent.ActionMain);

            var intent = new Intent();
            intent.PutExtra(Intent.ExtraShortcutIntent, shortcutIntent);
            intent.PutExtra(Intent.ExtraShortcutName, "혼자 말하기");
            intent.SetAction("com.android.launcher.action.UNINSTALL_SHORTCUT");
            SendBroadcast(intent);
        }

    }
}

