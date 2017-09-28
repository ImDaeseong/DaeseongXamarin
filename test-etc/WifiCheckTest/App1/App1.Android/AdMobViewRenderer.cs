using Xamarin.Forms;
using App1;
using App1.Droid;
using Xamarin.Forms.Platform.Android;
using Android.Gms.Ads;

[assembly: ExportRenderer(typeof(AdMobBanner), typeof(AdMobViewRenderer))]
namespace App1.Droid
{
    public class AdMobViewRenderer : ViewRenderer<AdMobBanner, AdView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<AdMobBanner> e)
        {
            const string adUnitID = "ca-app-pub-3940256099942544/6300978111";

            base.OnElementChanged(e);

            if (Control == null)
            {
                var adMobBanner = new AdView(Forms.Context);
                adMobBanner.AdSize = AdSize.Banner;
                adMobBanner.AdUnitId = adUnitID;

                var requestbuilder = new AdRequest.Builder();
                adMobBanner.LoadAd(requestbuilder.Build());

                SetNativeControl(adMobBanner);
            }
        }
    }

}