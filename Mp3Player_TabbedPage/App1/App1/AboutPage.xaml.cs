using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

            BackgroundColor = Color.FromHex("#253648");
            
        }
        
        protected override bool OnBackButtonPressed()
        {            
            return base.OnBackButtonPressed();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                if (XamarinAppSettings.PageName != "AboutPage")
                    XamarinAppSettings.PageName = "AboutPage";
            }
            catch 
            {
                App.WriteString("AboutPage OnAppearing Failed");
            }            
        }
        
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            App.CurrentIndex = 2;
            XamarinAppSettings.PageName = "AboutPage";
        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            this.labelLoading.IsVisible = false;
        }

        private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            this.labelLoading.IsVisible = true;
        }
    }
}