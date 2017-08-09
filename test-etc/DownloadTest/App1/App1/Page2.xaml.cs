using App1.Services;
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
        public Page2()
        {
            InitializeComponent();

            DependencyService.Get<IDownload>().DownloadFile();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            App.Self.PropertyChanged += (s, e) => PropertyChange(s, e);
        }

        private void PropertyChange(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "DownloadProgress")
            {
                var downloaded = (double)App.Self.DownloadProgress / (double)App.Self.DownloadTotal;
                progress.Progress = downloaded;
                if (!App.Self.DownloadCompleted)
                    Device.BeginInvokeOnMainThread(() => lblProg.Text = string.Format("Downloading {0}%", (int)(downloaded * 100)));
                if (App.Self.DownloadTotal == App.Self.DownloadProgress)
                    App.Self.DownloadCompleted = true;
            }
            if (e.PropertyName == "DownloadCompleted")
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    lblProg.Text = "Download completed";
                    var image = new Image
                    {
                        WidthRequest = 200,
                        HeightRequest = 250,
                        Source = DependencyService.Get<IDownload>().GetFilename()
                    };
                    progressStack.Children.Add(image);
                });
            }
        }
    }
}