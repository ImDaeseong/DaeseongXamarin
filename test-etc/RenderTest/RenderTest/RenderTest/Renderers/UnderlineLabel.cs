using Xamarin.Forms;

namespace RenderTest.Renderers
{
    public class UnderlineLabel : Label
    {
        public UnderlineLabel()
        {
        }

        public static readonly BindableProperty IsUnderlineProperty =  BindableProperty.Create(nameof(IsUnderline), typeof(bool), typeof(UnderlineLabel), true);

        public bool IsUnderline
        {
            get
            {
                return (bool)GetValue(IsUnderlineProperty);
            }
            set
            {
                SetValue(IsUnderlineProperty, value);
            }
        }
    }
}
