using UIKit;
using CoreGraphics;
using Xamarin.Forms;
using App1;
using App1.iOS;
using Xamarin.Forms.Platform.iOS;
using Google.MobileAds;

[assembly: ExportRenderer(typeof(AdMobBanner), typeof(AdMobBannerRenderer))]
namespace App1.iOS
{
    public class AdMobBannerRenderer : ViewRenderer
    {
        const string adUnitID = "ca-app-pub-3940256099942544/6300978111";

        BannerView adMobBanner;
        bool viewOnScreen;
        UIViewController viewCtrl = null;

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            if (e.OldElement == null)
            {                
                foreach (UIWindow v in UIApplication.SharedApplication.Windows)
                {
                    if (v.RootViewController != null)
                    {
                        viewCtrl = v.RootViewController;
                        break;
                    }
                }
            
                if (viewCtrl == null)
                {
                    viewCtrl = UIApplication.SharedApplication.KeyWindow.RootViewController;
                }

                adMobBanner = new BannerView(AdSizeCons.Banner, new CGPoint(-10, 0))
                {
                    AdUnitID = adUnitID,
                    RootViewController = viewCtrl
                };

                adMobBanner.AdReceived += (sender, args) =>
                {
                    if (!viewOnScreen) AddSubview(adMobBanner);
                    viewOnScreen = true;
                };

                var req = Request.GetDefaultRequest();               
                adMobBanner.LoadRequest(req);
                SetNativeControl(adMobBanner);
            }
        }

    }
}