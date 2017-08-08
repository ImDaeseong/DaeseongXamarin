using Xamarin.Forms;
using RenderTest.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Foundation;

[assembly: ExportRenderer(typeof(RotationLabelRender), typeof(RotationLabelRender))]
namespace RenderTest.iOS.Renderers
{
    public class RotationLabelRender : LabelRenderer
    {
        public RotationLabelRender()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var attributes = new UIStringAttributes
                {
                    StrikethroughStyle = NSUnderlineStyle.Single,
                    StrikethroughColor = UIColor.Red
                };

                Control.AttributedText = new NSAttributedString(Control.Text, attributes);
            }
        }
    }
}