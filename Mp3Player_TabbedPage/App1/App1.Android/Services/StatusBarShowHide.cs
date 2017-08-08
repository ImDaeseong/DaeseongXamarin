using Android.App;
using Android.Views;
using Xamarin.Forms;
using App1.Droid;

[assembly: Dependency(typeof(StatusBarShowHide))]
namespace App1.Droid
{
    public class StatusBarShowHide : IStatusBar
    {
        private WindowManagerFlags flags;

        public void HideStatusBar()
        {
            var activity = (Activity)Forms.Context;
            var attrs = activity.Window.Attributes;
            flags = attrs.Flags;
            attrs.Flags |= Android.Views.WindowManagerFlags.Fullscreen;
            activity.Window.Attributes = attrs;
        }

        public void ShowStatusBar()
        {
            var activity = (Activity)Forms.Context;
            var attrs = activity.Window.Attributes;
            attrs.Flags = flags;
            activity.Window.Attributes = attrs;
        }
    }
}