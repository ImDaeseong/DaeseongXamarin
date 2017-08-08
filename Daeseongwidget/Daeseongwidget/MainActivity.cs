using Android.App;
using Android.OS;

namespace Daeseongwidget
{
    [Activity(Label = "Daeseongwidget", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
                        
            //Toast.MakeText(this, "AppWidget ready", ToastLength.Short).Show();

            Finish();
        }
    }
}

