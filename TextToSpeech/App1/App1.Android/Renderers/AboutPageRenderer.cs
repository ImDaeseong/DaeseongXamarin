using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using App1.Droid.Renderers;
using App1;

[assembly: ExportRenderer(typeof(AboutPage), typeof(AboutPageRenderer))]
namespace App1.Droid.Renderers
{
    public class AboutPageRenderer : PageRenderer
    {
        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            SetBackgroundResource(Resource.Drawable.gradient);
        }
    }
}