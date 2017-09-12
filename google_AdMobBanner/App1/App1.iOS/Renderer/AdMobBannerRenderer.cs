using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using App1.Renderer;
using App1.iOS.Renderer;
using Google.MobileAds;


[assembly: ExportRenderer(typeof(AdMobBannerView), typeof(AdMobBannerRenderer))]
namespace App1.iOS.Renderer
{
    public class AdMobBannerRenderer : ViewRenderer
    {
        BannerView adView;
        bool viewOnScreen = false;
               
        public static void Init()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
                        
            var adMobElement = Element;
                       
            adView = new BannerView(AdSizeCons.Banner)
            {
                AdUnitID = "ca-app-pub-3940256099942544/6300978111",//"광고 ID";,
                RootViewController = UIApplication.SharedApplication.Windows[0].RootViewController
            };

          
            adView.AdReceived += (sender, args) =>
            {
                if (!viewOnScreen)
                {
                    AddSubview(adView);
                }
                viewOnScreen = true;
            };

            adView.LoadRequest(Request.GetDefaultRequest());
            base.SetNativeControl(adView);
        }

    }

}