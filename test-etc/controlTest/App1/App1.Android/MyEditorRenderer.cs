using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using App1;
using App1.Droid;
using Android.Graphics.Drawables.Shapes;
using Android.Graphics.Drawables;
using Android.Graphics;

[assembly: ExportRenderer(typeof(MyEditor), typeof(MyEditorRenderer))]
namespace App1.Droid
{
    public class MyEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                MyEditor entity = e.NewElement as MyEditor;
                this.Control.Hint = entity.Placeholder;
                this.Control.SetHintTextColor(entity.PlaceholderColor.ToAndroid());

                ShapeDrawable shape = new ShapeDrawable(new RectShape());
                shape.Paint.Color = Xamarin.Forms.Color.Transparent.ToAndroid();
                shape.Paint.StrokeWidth = 5;
                shape.Paint.SetStyle(Paint.Style.Stroke);
                this.Control.SetBackground(shape);
            }
        }
    }
}