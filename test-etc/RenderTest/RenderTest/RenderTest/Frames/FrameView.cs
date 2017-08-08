using Xamarin.Forms;

namespace RenderTest.Frames
{
    public class FrameView : Frame
    {
        public FrameView()
        {
            HasShadow = true;
            OutlineColor = Color.Transparent;
            BackgroundColor = Color.Transparent;
            CornerRadius = 5;
        }
    }
   
}
