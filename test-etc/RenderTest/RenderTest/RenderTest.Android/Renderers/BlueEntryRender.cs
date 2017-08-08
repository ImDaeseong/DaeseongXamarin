using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using RenderTest.Renderers;
using RenderTest.Droid.Renderers;

[assembly: ExportRenderer(typeof(BlueEntry), typeof(BlueEntryRender))]
namespace RenderTest.Droid.Renderers
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
                //Android Native Entry
            }

            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.Purple);
            }
        }
    }
}