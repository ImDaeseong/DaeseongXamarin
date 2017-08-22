using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CoreAnimation;
using CoreGraphics;
using App1;
using App1.iOS.Renderers;

[assembly: ExportRenderer(typeof(AboutPage), typeof(AboutPageRenderer))]
namespace App1.iOS.Renderers
{
    public class AboutPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null) // perform initial setup
            {
                var gradientLayer = new CAGradientLayer();
                gradientLayer.Frame = View.Bounds;
                gradientLayer.Colors = new CGColor[] { Color.FromHex("#a8d7ec").ToCGColor(), Color.FromHex("#3da0c7").ToCGColor() };
                View.Layer.InsertSublayer(gradientLayer, 0);
            }
        }
    }
}