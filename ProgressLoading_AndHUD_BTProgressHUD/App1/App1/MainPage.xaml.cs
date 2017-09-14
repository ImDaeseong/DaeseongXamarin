using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : BasePage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.Run(async () =>
            {
                Show();
                await Task.Delay(1000);
                Hide();
            });
        }

        private async void ShowButton_Clicked(object sender, System.EventArgs e)
        {
            await Task.Run(async () =>
            {
                Show();
                await Task.Delay(1000);
                Hide();
            });            
        }
        
    }
}
