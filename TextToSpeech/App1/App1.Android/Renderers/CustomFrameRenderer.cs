using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using App1.Renderers;
using App1.Droid.Renderers;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace App1.Droid.Renderers
{
    public class CustomFrameRenderer : FrameRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            Background = Resources.GetDrawable(Resource.Drawable.roundedBorder);
        }
    }
}