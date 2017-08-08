using Android.App;
using Android.OS;
using System.Threading.Tasks;
using System.Threading;

namespace App1.Droid
{
    [Activity(MainLauncher = true, Icon = "@drawable/icon", NoHistory = true, Theme = "@style/AppTheme5.Splash")]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SplashScreen);

            LoadMainActivity();
        }

        private async void LoadMainActivity()
        {
            await Task.Run(() => {
                Thread.Sleep(100);//Thread.Sleep(3000);
                StartActivity(typeof(MainActivity));
            });
        }
    }
}