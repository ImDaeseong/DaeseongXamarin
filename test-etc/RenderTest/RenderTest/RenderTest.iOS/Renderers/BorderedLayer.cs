using CoreAnimation;
using CoreGraphics;

namespace RenderTest.iOS.Renderers
{
    public sealed class BorderedLayer : CALayer
    {
        public BorderedLayer(CGColor borderBolor, double borderHeight, double height, double width)
        {
            BackgroundColor = borderBolor;

            Frame = new CGRect(0, height, width, borderHeight);
        }
    }
}