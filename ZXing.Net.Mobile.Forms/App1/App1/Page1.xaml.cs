using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        ZXingBarcodeImageView barcode;

        public Page1()
        {
            InitializeComponent();
        }

        //qr 코드 만들기
        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (contentEntry.Text != string.Empty)
                {
                    barcode = new ZXingBarcodeImageView
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        AutomationId = "zxingBarcodeImageView",
                    };
                    barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
                    barcode.BarcodeOptions.Width = 500;
                    barcode.BarcodeOptions.Height = 500;
                    barcode.BarcodeOptions.Margin = 10;
                    barcode.BarcodeValue = contentEntry.Text.Trim();
                    qrResult.Content = barcode;
                }

            } catch{}

        }

    }
}