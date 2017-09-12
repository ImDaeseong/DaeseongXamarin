using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Services;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();

            btnScan.Clicked += BtnScan_Clicked;
        }

        private async void BtnScan_Clicked(object sender, EventArgs e)
        {
            var scanner = DependencyService.Get<IScanner>();
            var result = await scanner.ScanAsync();
            if (result != null)
                barcode.Text = result;
        }

    }
}