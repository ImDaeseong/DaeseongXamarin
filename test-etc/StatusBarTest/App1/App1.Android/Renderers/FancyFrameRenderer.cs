using Xamarin.Forms;
using App1.Renderers;
using App1.Droid.Renderers;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FancyFrame), typeof(FancyFrameRenderer))]
namespace App1.Droid.Renderers
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