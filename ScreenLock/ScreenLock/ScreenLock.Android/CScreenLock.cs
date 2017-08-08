using System;
using Android.Views;
using ScreenLock.Droid;
using Xamarin.Forms;
using Plugin.CurrentActivity;

[assembly: Xamarin.Forms.Dependency(typeof(CScreenLock))]
namespace ScreenLock.Droid
{
    public class CScreenLock : IScreenLock
    {
        public CScreenLock()
        {
        }

        public void Lock()
        {
            MainActivity main = ((MainActivity)CrossCurrentActivity.Current.Activity);
            main.Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);
        }

        public void Unlock()
        {
            MainActivity main = ((MainActivity)CrossCurrentActivity.Current.Activity);
            main.Window.ClearFlags(WindowManagerFlags.KeepScreenOn);
        }
    }
}