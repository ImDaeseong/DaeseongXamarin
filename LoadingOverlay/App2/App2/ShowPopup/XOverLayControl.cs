using Xamarin.Forms;

namespace App2.ShowPopup
{
    public class XOverLayControl
    {
        public XOverLayControl()
        {
            BackgroundColor = Color.Default;
            HasNavigationBar = true;
            HasTabbedBar = false;
            Alpha = Device.OS == TargetPlatform.Android ? 255 : 1;
            AnimateClosing = false;
        }

        public Color BackgroundColor { get; set; }

        public bool HasTabbedBar { get; set; }

        public bool HasNavigationBar { get; set; }

        public bool AnimateClosing { get; set; }

        /// <summary>
        /// <para>Android: 0 - 255</para>
        /// <para>iOS: 0 - 1</para>
        /// </summary>
        /// <value>The alpha.</value>
        public float Alpha { get; set; }
    }

}
