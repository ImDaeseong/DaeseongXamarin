using Android.App;
using Xamarin.Forms;
using App1.Droid;

[assembly: Dependency(typeof(CloseApplication))]
namespace App1.Droid
{
    public class CloseApplication : ICloseApplication
    {
        public void CloseApp()
        {
            //var activity = (Activity)Forms.Context;
            //activity.FinishAffinity();

            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}