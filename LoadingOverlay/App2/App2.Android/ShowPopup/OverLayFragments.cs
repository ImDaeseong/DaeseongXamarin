using System;
using Android.App;
using Android.Views;
using Android.Views.Animations;
using Xamarin.Forms.Platform.Android;
using App2.ShowPopup;

namespace App2.Droid.ShowPopup
{
    internal class OverLayFragments : Fragment
    {
        protected internal readonly float NavigationBarHeightPortrait = 44;
        protected internal readonly float NavigationBarHeightOther = 32;
        protected internal readonly float TabBarHeight = 49;
        protected internal readonly float NotPortraitHeightOffset = 10;
        protected internal XOverLayControl ViewDetails;

        public OverLayFragments()
        {

        }

        public OverLayFragments(XOverLayControl details)
        {
            ViewDetails = details;
        }

        protected internal void SetView(View view, Activity activity)
        {
            if (ViewDetails != null)
            {
                if (ViewDetails.BackgroundColor == Xamarin.Forms.Color.Default)
                {
                    var r = activity.Window.DecorView.RootView;
                    view.Background = r.Background;
                }
                else
                {
                    view.SetBackgroundColor(ViewDetails.BackgroundColor.ToAndroid());
                }

                // 1 to 255 for Android
                // 0 (fully transparent) to 255 (completely opaque)
                if (Math.Abs(ViewDetails.Alpha - 1) > double.Epsilon)
                {
                    view.Background.Alpha = (int)ViewDetails.Alpha;
                }
            }
        }

        internal void Hide()
        {
            if (ViewDetails != null && ViewDetails.AnimateClosing && View != null)
            {
                var animation1 = new AlphaAnimation(View.Alpha, 0)
                {
                    Duration = 500,
                    StartOffset = 100
                };
                View.StartAnimation(animation1);
            }
        }

    }

}