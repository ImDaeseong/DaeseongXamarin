using System;
using System.Threading;
using Java.Lang;
using Xamarin.Forms;

namespace shSpeak.Renderers
{
    public class CustomEditor : Editor
    {
        private controls.KeyBoardSetting keyboard = controls.KeyBoardSetting.getInstance;

        public CustomEditor() : base()
        {
            //this.Focused += CustomEditor_Focused;
        }

        private void CustomEditor_Focused(object sender, FocusEventArgs e)
        {
            keyboard.HideKeyboard();
            (new Thread(bgBackgroundFixer)).Start();
        }

        private void bgBackgroundFixer()
        {
            while (this.IsFocused)
            {
                Device.BeginInvokeOnMainThread(() => keyboard.HideKeyboard());
                Thread.Sleep(20);
            }
        }

    }
}
