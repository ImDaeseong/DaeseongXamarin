using System;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using App1;
using App1.iOS;

[assembly: ExportRenderer(typeof(LetterSpacingLabel), typeof(LetterSpacingLabelRenderer))]
namespace App1.iOS
{
    public class LetterSpacingLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            var data = Element as LetterSpacingLabel;
            if (data == null || Control == null)
            {
                return;
            }

            var text = Control.Text;
            var attributedString = new NSMutableAttributedString(text);

            var nsKern = new NSString("NSKern");
            var spacing = NSObject.FromObject(data.LetterSpacing * 10);
            var range = new NSRange(0, text.Length);

            attributedString.AddAttribute(nsKern, spacing, range);
            Control.AttributedText = attributedString;
        }
        
    }
}