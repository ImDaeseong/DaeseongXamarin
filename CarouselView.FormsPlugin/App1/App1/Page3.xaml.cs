using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        private List<IntroItem> IntroItemList;

        public Page3()
        {
            InitializeComponent();

            IntroItemList = null;
            IntroItemList = new List<IntroItem>
            {
                new IntroItem
                {
                    ImageName = "intro1.png",
                    Name = "intro1"
                },
                new IntroItem
                {
                    ImageName = "intro2.png",
                    Name = "intro2"
                },
                new IntroItem
                {
                    ImageName = "intro3.png",
                    Name = "intro3"
                },
                new IntroItem
                {
                    ImageName = "intro4.png",
                    Name = "intro4"
                },
                new IntroItem
                {
                    ImageName = "intro5.png",
                    Name = "intro5"
                },
                new IntroItem
                {
                    ImageName = "intro6.png",
                    Name = "intro6"
                },
                new IntroItem
                {
                    ImageName = "intro7.png",
                    Name = "intro7"
                }
            };
            carView.ItemsSource = IntroItemList;

        }

        private void EnterClose_Click(object sender, EventArgs e)
        {

        }
    }
}