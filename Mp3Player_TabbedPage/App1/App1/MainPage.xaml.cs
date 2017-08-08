using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            BarBackgroundColor = Color.FromHex("#3F5973");
            BarTextColor = Color.FromHex("FF8300");
            HeightRequest = 10;     
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            try
            {
                var pageIndex = this.Children.IndexOf(this.CurrentPage);
                Debug.WriteLine("Page Index: " + pageIndex);
            }
            catch 
            {
                App.WriteString("MainPage OnCurrentPageChanged Failed");
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
            //return base.OnBackButtonPressed();
        }
                
        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //Debug.WriteLine("PageName: " + XamarinAppSettings.PageName);
                //Debug.WriteLine("PageName: " + App.CurrentIndex);

                if (App.CurrentIndex > 0)
                {
                    foreach (Page page in this.Children)
                    {
                        int index = this.Children.IndexOf(page);
                        if (index == App.CurrentIndex)
                        {
                            //Debug.WriteLine(this.Children[index]);
                            CurrentPage = page;
                            break;
                        }
                    }
                }
            }
            catch 
            {
                App.WriteString("MainPage OnAppearing Failed");
            }            
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            
        }

    }
}