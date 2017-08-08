using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageButtonView : ContentView
    {
        public event EventHandler Click;

        public ImageButtonView()
        {
            InitializeComponent();

            var columnDefinitions = grdView.ColumnDefinitions;
            columnDefinitions[1].Width = 0;// 100;

            this.WidthRequest = 240;            
            this.imgImage.Source = "book.png";//ImageSource.FromFile("book.png");
            this.lblText.Text = "ImageButtonView";

            this.AddTouchHandler(this, this.OnClick);
        }
        
        private void OnClick()
        {
            Click?.Invoke(this, EventArgs.Empty);
        }

        protected void AddTouchHandler(View view, Action action)
        {
            view.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    view.Opacity = 0.6;
                    view.FadeTo(1);
                    action();
                })
            });
        }

    }
}