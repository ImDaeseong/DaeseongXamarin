using RenderTest.ContentViews;
using RenderTest.ImageButton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RenderTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();

            //ImageButton
            this.BindingContext = new ImageButtonModel();
            
        }

        void Menu1(object sender, EventArgs e)
        {
            var content = new View1();
            xContextPlaceHolder.Content = content;
        }

        void Menu2(object sender, EventArgs e)
        {
            var content = new View2();
            xContextPlaceHolder.Content = content;
        }

        void Menu3(object sender, EventArgs e)
        {
            var content = new View3();
            xContextPlaceHolder.Content = content;
        }

    }
}