using System;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using RenderTest.Renderers;
using RenderTest.iOS.Renderers;

[assembly: ExportRenderer(typeof(UnderlineLabel), typeof(UnderlineLabelRender))]
namespace RenderTest.iOS.Renderers
{
    public class UnderlineLabelRender : LabelRenderer
    {
        public UnderlineLabelRender()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control == null) return;

            try
            {
                var label = (UILabel)Control;
                var text = (NSMutableAttributedString)label.AttributedText;
                var range = new NSRange(0, text.Length);
                text.AddAttribute(UIStringAttributeKey.UnderlineStyle, NSNumber.FromInt32((int)NSUnderlineStyle.Single), range);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}