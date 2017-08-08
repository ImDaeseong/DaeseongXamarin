using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using RenderTest.Renderers;
using RenderTest.iOS.Renderers;

[assembly: ExportRenderer(typeof(BlueEntry), typeof(BlueEntryRender))]
namespace RenderTest.iOS.Renderers
{
    public class BlueEntryRender : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                //Xamarin Form Entry
            }

            if (e.NewElement != null)
            {
                //iOS Native Entry
            }

            if (Control != null)
            {
                Control.BackgroundColor = UIKit.UIColor.Purple;
            }
        }
    }
}