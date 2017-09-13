using System;
using UIKit;
using Foundation;
using CoreGraphics;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms.Platform.iOS;
using App2.ShowPopup;

namespace App2.iOS.ShowPopup
{
    public static class ViewExtensions
    {       
        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childrenSelector)
        {
            foreach (var item in source)
            {
                yield return item;
                foreach (var child in childrenSelector(item).Flatten(childrenSelector))
                {
                    yield return child;
                }
            }
        }

        public static T FirstOrDefaultFromMany<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childrenSelector, Predicate<T> condition)
        {
            while (true)
            {
                // return default if no items
                var enumerable = source as T[] ?? source.ToArray();
                if (source == null || !enumerable.Any()) return default(T);

                // return result if found and stop traversing hierarchy
                var attempt = enumerable.FirstOrDefault(t => condition(t));
                if (!Equals(attempt, default(T))) return attempt;

                // recursively call this function on lower levels of the
                // hierarchy until a match is found or the hierarchy is exhausted
                source = enumerable.SelectMany(childrenSelector);
            }
        }
    }


    public abstract class OverlayView : UIView
    {
        protected internal readonly float NavigationBarHeightPortrait = 45;
        protected internal readonly float NavigationBarHeightOther = 33; 
        protected internal readonly float TabBarHeight = 49;
        protected internal readonly float NotPortraitHeightOffset = 10;
        private bool _registeredForObserver;
        private readonly XOverLayControl _viewDetails;

        protected OverlayView(IntPtr h) : base(h)
        {

        }

        protected OverlayView()
        {

        }

        private void RegisterForObserver()
        {
            var notificationCenter = NSNotificationCenter.DefaultCenter;
            notificationCenter.AddObserver(UIApplication.DidChangeStatusBarOrientationNotification, DeviceOrientationDidChange);
            UIDevice.CurrentDevice.BeginGeneratingDeviceOrientationNotifications();
            _registeredForObserver = true;
        }

        protected OverlayView(XOverLayControl details, bool xibView = false)
        {
            // configurable bits
            _viewDetails = details;
            //this.BackgroundColor = UIColor.Black;
            if (_viewDetails.HasNavigationBar == false)
            {
                // check NavigationBar
                _viewDetails.HasNavigationBar =
                    UIApplication.SharedApplication.KeyWindow.Subviews.FirstOrDefaultFromMany(item => item.Subviews,
                        x => x is UINavigationBar) != null;
                NavigationBarHeightOther = 0;
                NavigationBarHeightPortrait = 0;
            }
            if (xibView == false)
            {
                SetViewProperties(this);
            }
            RegisterForObserver();
        }

        protected internal void SetViewProperties(UIView view)
        {
            BackgroundColor = _viewDetails.BackgroundColor != Xamarin.Forms.Color.Default ? _viewDetails.BackgroundColor.ToUIColor() : UIColor.White;
            Alpha = 1; //(nfloat)this.ViewDetails.Alpha;
        }

        private void DeviceOrientationDidChange(NSNotification notification)
        {
            DoLayout();
        }

        internal abstract void DoLayout();


        /// <summary>
        /// Fades out the control and then removes it from the super view
        /// </summary>
        protected internal void Hide()
        {
            if (_viewDetails != null && _viewDetails.AnimateClosing)
            {
                Animate(
                    0.5, // duration
                    () => { Alpha = 0; },
                    RemoveFromSuperview
                    );
            }
            else
            {
                RemoveFromSuperview();
            }

            if (_registeredForObserver)
            {
                var notificationCenter = NSNotificationCenter.DefaultCenter;
                notificationCenter.RemoveObserver(this, UIDevice.OrientationDidChangeNotification, UIApplication.SharedApplication);
                UIDevice.CurrentDevice.EndGeneratingDeviceOrientationNotifications();
                notificationCenter.RemoveObserver(this, UIApplication.DidBecomeActiveNotification, UIApplication.SharedApplication);
            }

            Dispose();
        }

        /// <summary>
        /// Gets the height of the status bar.
        /// </summary>
        /// <value>The height of the status bar.</value>
        protected internal nfloat StatusBarHeight
        {
            get
            {
                var statusHidden = UIApplication.SharedApplication.StatusBarHidden;
                nfloat statusHeight = 0;
                if (statusHidden == false)
                {
                    statusHeight = UIApplication.SharedApplication.StatusBarFrame.Height;
                }
                return statusHeight;
            }
        }

        protected internal void SetFrame()
        {
            Frame = GetFrame();
        }

        protected internal CGRect GetFrame()
        {
            var bounds = UIScreen.MainScreen.ApplicationFrame;

            //Show overlay full Screen
            var frame = new CGRect(0, StatusBarHeight, bounds.Width, bounds.Height);
            return frame;
        }

    }
}