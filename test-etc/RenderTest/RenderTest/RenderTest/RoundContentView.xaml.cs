using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace RenderTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoundContentView : ContentView
    {
        public RoundContentView()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = sender as Label;
                if (selectedItem == null) return;
                Debug.WriteLine(selectedItem.Text);
            }
            catch
            {
                Debug.WriteLine("TapGestureRecognizer_Tapped Error");
            }
        }
    }
}