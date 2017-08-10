using UIKit;
using Xamarin.Forms;
using App1.iOS.Services;
using App1.Services;

[assembly: Dependency(typeof(CStatusBar))]
namespace App1.iOS.Services
{
    public class CStatusBar : IStatusBar
    {
        public CStatusBar()
        {
        }
        
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