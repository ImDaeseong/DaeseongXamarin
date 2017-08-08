using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page9 : ContentPage
    {
        public Page9()
        {
            InitializeComponent();
        }

        bool bShow = false;
        private async void Button_Clicked(object sender, EventArgs e)
        {
            AnimateText(lblani, "change text");
            return;

            if (bShow)
            {
                bShow = false;
                ShowNoResults(bShow);
            }
            else
            {
                bShow = true;
                ShowNoResults(bShow);
            }
        }

        private async void ShowNoResults(bool v)
        {            
            if (v)
            {
                await lblani.FadeTo(1, 250, Easing.SinIn);

            }
            else
            {
                await lblani.FadeTo(0, 200, Easing.SpringOut);
            }
        }

        private async void AnimateText(Label label, string newText)
        {
            var color = label.TextColor;
            await Task.WhenAll(
                label.ColorTo(Color.Gray, Color.Black, c => label.TextColor = c, 200),

                label.ColorTo(Color.Black, Color.Gray, c => label.TextColor = c, 200));

            label.Text = newText;
        }
    }

    public static class ViewExtensions
    {
        public static Task<bool> ColorTo(this VisualElement self, Color fromColor, Color toColor, Action<Color> callback, uint length = 250, Easing easing = null)
        {
            Func<double, Color> transform = (t) =>
                Color.FromRgba(fromColor.R + t * (toColor.R - fromColor.R),
                               fromColor.G + t * (toColor.G - fromColor.G),
                               fromColor.B + t * (toColor.B - fromColor.B),
                               fromColor.A + t * (toColor.A - fromColor.A));
            return ColorAnimation(self, "ColorTo", transform, callback, length, easing);
        }

        public static void CancelAnimation(this VisualElement self)
        {
            self.AbortAnimation("ColorTo");
        }

        static Task<bool> ColorAnimation(VisualElement element, string name, Func<double, Color> transform, Action<Color> callback, uint length, Easing easing)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            element.Animate<Color>(name, transform, callback, 16, length, easing, (v, c) => taskCompletionSource.SetResult(c));
            return taskCompletionSource.Task;
        }
    }
}