using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using System.ComponentModel;
using App1.Renderers;
using App1.Droid.Renderers;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace App1.Droid.Renderers
{
    public class CustomLabelRenderer : LabelRenderer
    {
        public CustomLabelRenderer() : base()
        { }
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var view = Element as CustomLabel;
                if (view != null)
                {
                    if (view.IsUnderlined)
                    {
                        Control.PaintFlags |= PaintFlags.UnderlineText;
                    }
                }
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var view = Element as CustomLabel;
            if (e.PropertyName == CustomLabel.IsUnderlinedProperty.PropertyName)
            {
                Control.PaintFlags = view.IsUnderlined ? Control.PaintFlags | PaintFlags.UnderlineText : Control.PaintFlags & ~PaintFlags.UnderlineText;
            }
        }
    }
}