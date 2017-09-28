using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Services;
using Newtonsoft.Json;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private INetworkConnection networkInfo;        
        private HtmlRemoval htmlTag;

        string sClipboard;

        bool IsConnected;
        bool IsWifi;
        bool IsMobileCarrier;
        

        public MainPage()
        {
            InitializeComponent();

            addressEntry.Completed += (s, e) => searchButton.Focus();
            searchButton.Clicked += ContinueAsync;
            LoadButton.Clicked += CallPageAsync;

            try
            {
                networkInfo = DependencyService.Get<INetworkConnection>();
                IsConnected = networkInfo.IsConnected;
                IsWifi = networkInfo.IsWifi;
                IsMobileCarrier = networkInfo.IsMobileCarrier;
                                
                htmlTag = new App1.HtmlRemoval();
            }
            catch
            {
                IsConnected = false;
                IsWifi = false;
                IsMobileCarrier = false;
            }            
        }

        private async void CallPageAsync(object sender, EventArgs e)
        {            
            try
            {
                //string sClipboard = App.ClipboardGetText();
                //await DisplayAlert("err", sClipboard, "OK");
                
                await Navigation.PushModalAsync(new AdMobViewPage(sClipboard));
            }
            catch
            {
                await DisplayAlert("err", "load Page", "OK");
            }        
        }

        private async void ContinueAsync(object sender, EventArgs e)
        {
            if (!IsConnected) return;           
            if (!IsWifi) return;
           
            try
            {
                showLoading(true);

                string url = string.Format("{0}", addressEntry.Text);


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                using ( var response = (HttpWebResponse)(await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null)) )
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = new StreamReader(receiveStream);
                    string sHtml = readStream.ReadToEnd();
                    
                    string sPlain = htmlTag.ConvertHtmlToPlainText(sHtml);
                    sClipboard = sPlain;
                    //App.ClipboardSetText(sPlain);
                    
                    showLoading(false);                
                }
            }
            catch
            {
                showLoading(false);
            }
        }

        private void showLoading(bool status)
        {
            loginScreen.IsVisible = !status;
            loadingScreen.IsVisible = status;
        }
               
    }

}