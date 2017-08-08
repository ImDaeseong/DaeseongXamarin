using System;
using System.Threading;
using ScreenLock.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(CloseApplication))]
namespace ScreenLock.iOS
{
    public class CloseApplication : ICloseApplication
    {
        public void Exit()
        {
            Thread.CurrentThread.Abort();
            throw new Exception();
        }
    }
}