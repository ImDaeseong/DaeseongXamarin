using Xamarin.Forms;

namespace App1
{
    public class Frame2 : Frame
    {
        public float CornerRadius { get; set; }
        public bool Overflow { get; set; }
        public float ShadowRadius { get; set; }
        public Color ShadowColor { get; set; }
        public float ShadowOpacity { get; set; }
        public Thickness ShadowOffset { get; set; }
        public Color BorderColor { get; set; }
        public float BorderWidth { get; set; }

        public Frame2()
        {
            CornerRadius = 0;
            Overflow = true;
            ShadowRadius = 0;
            ShadowColor = Color.Transparent;
            ShadowOpacity = 0f;
            ShadowOffset = new Size(0, 0);
            BorderColor = Color.Transparent;
            BorderWidth = 0;
            Padding = 0;
        }
    }
   
}
