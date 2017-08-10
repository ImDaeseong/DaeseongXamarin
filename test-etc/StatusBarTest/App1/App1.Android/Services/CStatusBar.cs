using Android.App;
using Android.Views;
using Xamarin.Forms;
using App1.Droid.Services;
using App1.Services;

[assembly: Dependency(typeof(CStatusBar))]
namespace App1.Droid.Services
{
    public class CStatusBar : IStatusBar
    {
        public CStatusBar()
        {
        }
        
        public void HideStatusBar()
        {
            var activity = (Activity)Forms.Context;
            activity.Window.AddFlags(WindowManagerFlags.Fullscreen);
        }

        public void ShowStatusBar()
        {
            var activity = (Activity)Forms.Context;
            activity.Window.ClearFlags(WindowManagerFlags.Fullscreen);
        }        
    }
}