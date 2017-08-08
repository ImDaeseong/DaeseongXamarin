using UIKit;
using Xamarin.Forms;
using App1.iOS;

[assembly: Dependency(typeof(StatusBarShowHide))]
namespace App1.iOS
{
    public class StatusBarShowHide : IStatusBar
    {
        public void HideStatusBar()
        {
            UIApplication.SharedApplication.StatusBarHidden = true;
        }

        public void ShowStatusBar()
        {
            UIApplication.SharedApplication.StatusBarHidden = false;
        }
    }
}