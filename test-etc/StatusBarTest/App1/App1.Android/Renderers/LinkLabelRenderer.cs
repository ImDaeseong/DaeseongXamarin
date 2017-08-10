using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using App1.Renderers;
using App1.Droid.Renderers;

[assembly: ExportRenderer(typeof(LinkLabel), typeof(LinkLabelRenderer))]
namespace App1.Droid.Renderers
{
    public class LinkLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var element = Element as LinkLabel;
            if (Control != null && element != null)
            {
                Control.Click += element.OnClicked;
            }
        }
    }
}