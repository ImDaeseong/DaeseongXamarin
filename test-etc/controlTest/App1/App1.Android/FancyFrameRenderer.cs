using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using App1.Droid;
using App1;

[assembly: ExportRenderer(typeof(FancyFrame), typeof(FancyFrameRenderer))]
namespace App1.Droid
{
    public class FancyFrameRenderer : FrameRenderer
    {
        public override bool OnTouchEvent(Android.Views.MotionEvent e)
        {
            FancyFrame frame = (FancyFrame)this.Element;
            frame.SendSwipe();

            return base.OnTouchEvent(e);
        }
    }
}