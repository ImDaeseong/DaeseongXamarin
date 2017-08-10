using Xamarin.Forms;
using App1.Renderers;
using App1.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ExportRenderer(typeof(ButtonTextAlignment), typeof(ButtonTextAlignmentRenderer))]
namespace App1.iOS.Renderers
{
    public class ButtonTextAlignmentRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
                Control.ContentEdgeInsets = new UIEdgeInsets(0, 10, 0, 10);
                Control.Layer.CornerRadius = 0f;
            }
        }
    }
}