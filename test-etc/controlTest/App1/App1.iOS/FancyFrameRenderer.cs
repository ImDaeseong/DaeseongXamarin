using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using App1.iOS;
using App1;

[assembly: ExportRenderer(typeof(FancyFrame), typeof(FancyFrameRenderer))]
namespace App1.iOS
{
    public class FancyFrameRenderer : FrameRenderer
    {
        public override void TouchesBegan(Foundation.NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);

            // Any kind of touch should roll the die, so whenever a gesture ends -
            // no matter which one - we simulate a swipe.
            FancyFrame frame = (FancyFrame)this.Element;
            frame.SendSwipe();
        }
    }
}