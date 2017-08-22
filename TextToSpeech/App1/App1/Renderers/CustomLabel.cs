using System;
using Xamarin.Forms;

namespace App1.Renderers
{
    public class CustomLabel : Label
    {
        public static readonly BindableProperty IsUnderlinedProperty = BindableProperty.Create<CustomLabel, bool>(p => p.IsUnderlined, false);
        public CustomLabel() : base()
        { }
        public bool IsUnderlined
        {
            get
            {
                return (bool)GetValue(IsUnderlinedProperty);
            }
            set
            {
                SetValue(IsUnderlinedProperty, value);
            }
        }
    }
}
