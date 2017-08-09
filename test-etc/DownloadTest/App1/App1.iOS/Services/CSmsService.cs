using MessageUI;
using UIKit;
using Xamarin.Forms;
using App1.Services;
using App1.iOS.Services;

[assembly: Dependency(typeof(CSmsService))]
namespace App1.iOS.Services
{
    public class CSmsService : ISmsService
    {
        public void SendSMS(string sPhoneNumber, string sSms)
        {
            var composerViewController = new MFMessageComposeViewController()
            {
                Recipients = new[] { sPhoneNumber },
                Body = sSms,
            };

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(composerViewController, true, null);
        }
    }    
}