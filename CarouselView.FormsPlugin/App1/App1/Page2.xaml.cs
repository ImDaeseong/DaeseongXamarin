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
    public partial class Page2 : ContentPage
    {
        private List<IntroItem> IntroItemList;

        public Page2()
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
    }

    public class IntroItem
    {
        public string ImageName { get; set; }
        public string Name { get; set; }
    }

}