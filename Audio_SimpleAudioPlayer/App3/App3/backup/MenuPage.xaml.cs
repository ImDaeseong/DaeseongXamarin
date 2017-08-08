using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();

            btnPCL.Clicked += (s, e) => Navigation.PushAsync(new PCLAudioPage());
            btnLocal.Clicked += (s, e) => Navigation.PushAsync(new HeadProjectAudioPage());
        }
    }
}
