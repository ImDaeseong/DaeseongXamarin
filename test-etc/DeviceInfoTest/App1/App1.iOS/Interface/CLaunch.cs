using System;
using UIKit;
using Xamarin.Forms;
using App1.iOS.Interface;
using App1.Interface;

[assembly: Dependency(typeof(CLaunch))]
namespace App1.iOS.Interface
{
    public class CLaunch : ILaunch
    {
        public CLaunch()
        {
        }

        public bool IsInstalled(string sPackageName)
        {
            return UIApplication.SharedApplication.CanOpenUrl(new Foundation.NSUrl(sPackageName));
        }

        public void LaunchApp(string sPackageName)
        {
            UIApplication.SharedApplication.OpenUrl(new Foundation.NSUrl(sPackageName));
        }
    }
}