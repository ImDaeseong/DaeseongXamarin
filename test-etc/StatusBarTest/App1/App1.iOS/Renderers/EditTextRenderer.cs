using Xamarin.Forms;
using App1.Renderers;
using App1.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ExportRenderer(typeof(EditText), typeof(EditTextRenderer))]
namespace App1.iOS.Renderers
{
    public class EditTextRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.RoundedRect;
                Control.Layer.CornerRadius = 2f;
                Control.Layer.BorderColor = UIColor.FromRGBA(44, 62, 80, 255).CGColor;
                Control.Layer.BorderWidth = 2f;
                Control.TextAlignment = UITextAlignment.Center;
            }
        }
    }
}