using System;
using Android.App;
using ScreenLock.Droid;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(CloseApplication))]
namespace ScreenLock.Droid
{
    public class CloseApplication : ICloseApplication
    {
        public void Exit()
        {
            int pid = Android.OS.Process.MyPid();

            var activity = (Activity)Forms.Context;
            activity.FinishAffinity();
            
            Android.OS.Process.KillProcess(pid);
        }
    }
}