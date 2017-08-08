using UIKit;
using ScreenLock.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(CScreenLock))]
namespace ScreenLock.iOS
{
    public class CScreenLock : IScreenLock
    {
        public CScreenLock()
        {
        }

        public void Lock()
        {
            UIApplication.SharedApplication.IdleTimerDisabled = true;
        }

        public void Unlock()
        {
            UIApplication.SharedApplication.IdleTimerDisabled = false;
        }
    }
}
