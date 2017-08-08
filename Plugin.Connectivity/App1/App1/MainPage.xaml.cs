
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (CrossConnectivity.Current == null)
                return;

            System.Diagnostics.Debug.WriteLine(CrossConnectivity.Current.ConnectionTypes.First().ToString());

            if (CrossConnectivity.Current.IsConnected)
            {
                CheckConnectNeworkType();

                lblConnect.Text = "접속";
            }
            else
            {
                lblConnect.Text = "미접속";
            }

            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }
        
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            
            if (CrossConnectivity.Current != null)
                CrossConnectivity.Current.ConnectivityChanged -= Current_ConnectivityChanged;
        }

        private void Current_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (CrossConnectivity.Current == null)
                return;
            
            if (CrossConnectivity.Current.IsConnected)
            {
                CheckConnectNeworkType();

                lblConnect.Text = "접속";
            }
            else
            {
                lblConnect.Text = "미접속";
            }
        }

        private void CheckConnectNeworkType()
        {
            var connections = CrossConnectivity.Current.ConnectionTypes;
            foreach (var connection in connections)
            {
                switch (connection)
                {
                    case ConnectionType.Cellular:
                        {
                            lblNetworkType.Text = "Cellular";
                            System.Diagnostics.Debug.WriteLine("Cellular Connection Available");
                            break;
                        }

                    case ConnectionType.WiFi:
                        {
                            lblNetworkType.Text = "WiFi";
                            System.Diagnostics.Debug.WriteLine("WiFi Connection Available");
                            break;
                        }
                    case ConnectionType.Desktop:
                        {
                            lblNetworkType.Text = "Desktop";
                            System.Diagnostics.Debug.WriteLine("Desktop Connection Available");
                            break;
                        }
                }
            }
        }
    }
}
