using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
        }
    }

    public class Zoo
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
    }

    public class AnimalsViewModel
    {
        public ObservableCollection<Zoo> Zoos { get; set; }

        public AnimalsViewModel()
        {
            Zoos = new ObservableCollection<Zoo>
            {
                new Zoo
                {
                    ImageUrl = "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/23c1dd13-333a-459e-9e23-c3784e7cb434/2016-06-02_1049.png",
                    Name = "Woodland Park Zoo"
                },
                new Zoo
                {
                    ImageUrl = "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/6b60d27e-c1ec-4fe6-bebe-7386d545bb62/2016-06-02_1051.png",
                    Name = "Cleveland Zoo"
                },
                new Zoo
                {
                    ImageUrl = "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/e8179889-8189-4acb-bac5-812611199a03/2016-06-02_1053.png",
                    Name = "Phoenix Zoo"
                }
            };
        }
    }

}