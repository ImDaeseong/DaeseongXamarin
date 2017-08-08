using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using App1;
using App1.iOS;
using UIKit;

[assembly: ExportRenderer(typeof(MyEditor), typeof(MyEditorRenderer))]
namespace App1.iOS
{    
    public class MyEditorRenderer : EditorRenderer
    {
        private string Placeholder { get; set; }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            var element = this.Element as MyEditor;

            if (Control != null && element != null)
            {
                Placeholder = element.Placeholder;
                Control.TextColor = UIColor.LightGray;
                Control.Text = Placeholder;

                Control.ShouldBeginEditing += (UITextView textView) => {
                    if (textView.Text == Placeholder)
                    {
                        textView.Text = "";
                        textView.TextColor = UIColor.Black; // Text Color
                    }
                    return true;
                };

                Control.ShouldEndEditing += (UITextView textView) => {
                    if (textView.Text == "")
                    {
                        textView.Text = Placeholder;
                        textView.TextColor = UIColor.LightGray; // Placeholder Color
                    }
                    return true;
                };
            }
        }

    }
}