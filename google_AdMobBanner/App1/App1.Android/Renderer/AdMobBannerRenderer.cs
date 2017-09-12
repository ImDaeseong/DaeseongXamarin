using System;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using App1.Renderer;
using App1.Droid.Renderer;
using Android.Gms.Ads;

[assembly: ExportRenderer(typeof(AdMobBannerView), typeof(AdMobBannerRenderer))]
namespace App1.Droid.Renderer
{
    public class AdMobBannerRenderer : ViewRenderer<AdMobBannerView, AdView>
    {
        public static void Init()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<AdMobBannerView> e)
        {
            base.OnElementChanged(e);

            try
            {
                var adMobElement = Element;
                if ((adMobElement != null) && (e.OldElement == null))
                {
                    var ad = new Android.Gms.Ads.AdView(this.Context)
                    {
                        AdSize = Android.Gms.Ads.AdSize.Banner,
                        AdUnitId = "ca-app-pub-3940256099942544/6300978111"//"광고 ID";
                    };

                    var requestbuilder = new Android.Gms.Ads.AdRequest.Builder();
                    ad.LoadAd(requestbuilder.Build());

                    this.SetNativeControl(ad);
                }
            }
            catch (Exception ex)
            {
                Toast toast = Toast.MakeText(this.Context, ex.Message, ToastLength.Long);
            }
        }

        protected override AdView CreateNativeControl()
        {
            return Control;
        }

    }

}