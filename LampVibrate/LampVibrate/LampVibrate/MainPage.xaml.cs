using Xamarin.Forms;
using Plugin.Vibrate;
using Lamp.Plugin;
using System.Threading.Tasks;

namespace LampVibrate
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
        }

        private void LampOn_Clicked(object sender, System.EventArgs e)
        {
            Lamp.Plugin.CrossLamp.Current.TurnOn();

            //10000.0, 500.0
            CrossVibrate.Current.Vibration(10000);           
        }

        private void LampOff_Clicked(object sender, System.EventArgs e)
        {
            Lamp.Plugin.CrossLamp.Current.TurnOff();

            //10000.0, 500.0
            CrossVibrate.Current.Vibration(500);
        }


        private async Task TurnOnOff()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0)
                {
                    CrossLamp.Current.TurnOn();
                }
                else
                {
                    CrossLamp.Current.TurnOff();
                }
                await Task.Delay(500);
            }
            CrossLamp.Current.TurnOff();
        }

        private async void LampTest_Clicked(object sender, System.EventArgs e)
        {
            await TurnOnOff();
        }
    }
}
