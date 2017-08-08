using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Appwidget;
using System.Timers;

namespace Daeseongwidget
{
    [Service]
    public  class UpdateService : Service
    {
        private RemoteViews updateViews;

        public override void OnStart(Intent intent, int startId)
        {
            this.updateViews = new RemoteViews(this.PackageName, Resource.Layout.widget);

            BuildUpdate(this);

            ComponentName thisWidget = new ComponentName(this, Java.Lang.Class.FromType(typeof(AppWidget)).Name);
            AppWidgetManager manager = AppWidgetManager.GetInstance(this);

            manager.UpdateAppWidget(thisWidget, updateViews);

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.updateViews = new RemoteViews(this.PackageName, Resource.Layout.widget);

            BuildUpdate(this);

            ComponentName thisWidget = new ComponentName(this, Java.Lang.Class.FromType(typeof(AppWidget)).Name);
            AppWidgetManager manager = AppWidgetManager.GetInstance(this);

            manager.UpdateAppWidget(thisWidget, updateViews);
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public void BuildUpdate(Context context)
        {   
            string sText = string.Format("{0:HH:mm:ss}", DateTime.Now);
            string text = $"{sText}";
            this.updateViews.SetTextViewText(Resource.Id.textView1, text);
        }

    }
}