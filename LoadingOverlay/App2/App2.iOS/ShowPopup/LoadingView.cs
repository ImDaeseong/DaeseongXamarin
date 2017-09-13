using UIKit;
using CoreGraphics;
using App2.ShowPopup;

namespace App2.iOS.ShowPopup
{
    public sealed class LoadingView : OverlayView
    {
        // control declarations
        private readonly UIActivityIndicatorView _activitySpinner;

        public LoadingView(XOverLayControl details) : base(details)
        {
            DoLayout();

            // derive the center x and y
            var centerX = Frame.Width / 2;
            var centerY = Frame.Height / 2;

            // create the activity spinner, center it horizontall and put it 5 points above center x
            var transform = CoreGraphics.CGAffineTransform.MakeScale(1.5f, 1.5f);
            _activitySpinner = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.Gray) { Transform = transform };
           
            _activitySpinner.Frame = new CGRect(
                centerX - (_activitySpinner.Frame.Width / 2),
                centerY - (_activitySpinner.Frame.Height / 2),
                _activitySpinner.Frame.Width,
                _activitySpinner.Frame.Height);
            _activitySpinner.AutoresizingMask = UIViewAutoresizing.FlexibleMargins;
            AddSubview(_activitySpinner);
            _activitySpinner.StartAnimating();
        }

        internal override void DoLayout()
        {
            base.SetFrame();

            if (_activitySpinner != null)
            {
                var centerX = Frame.Width / 2;
                var centerY = Frame.Height / 2;

                _activitySpinner.Frame = new CGRect(
                    centerX - (_activitySpinner.Frame.Width / 2), 
                    centerY - (_activitySpinner.Frame.Height / 2),
                    _activitySpinner.Frame.Width,
                    _activitySpinner.Frame.Height);
            }
        }
    }

}