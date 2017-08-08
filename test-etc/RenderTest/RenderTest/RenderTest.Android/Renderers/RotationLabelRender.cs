using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using RenderTest.Renderers;
using RenderTest.Droid.Renderers;

[assembly: ExportRenderer(typeof(RotationLabel), typeof(RotationLabelRender))]

namespace RenderTest.Droid.Renderers
{
    public class RotationLabelRender : LabelRenderer
    {
        public RotationLabelRender()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Label> e)
        {
            base.OnElementChanged(e);

            //Native Renderer in Android
            if (Control != null)
            {
                Control.Rotation = 180.0f;
            }
        }
    }
}