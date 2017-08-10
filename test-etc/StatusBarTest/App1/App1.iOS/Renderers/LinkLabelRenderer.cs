using Xamarin.Forms;
using App1.Renderers;
using App1.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;
using Foundation;
using UIKit;
using System;

[assembly: ExportRenderer(typeof(LinkLabel), typeof(LinkLabelRenderer))]
namespace App1.iOS.Renderers
{
    class LinkLabelRenderer : LabelRenderer
    {
        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);

            var element = Element as LinkLabel;
            if (Control != null && element != null)
            {
                element.OnClicked(Control, EventArgs.Empty);
            }
        }
    }

}