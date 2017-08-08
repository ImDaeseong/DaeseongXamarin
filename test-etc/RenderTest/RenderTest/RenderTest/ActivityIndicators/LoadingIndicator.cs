using Xamarin.Forms;
namespace RenderTest.ActivityIndicators
{
    public class LoadingIndicator : ActivityIndicator
    {
        public LoadingIndicator()
        {
            HeightRequest = 25;
            WidthRequest = 25;
            IsShowLoading = false;
        }

        public LoadingIndicator(int height, int width)
        {
            HeightRequest = height;
            WidthRequest = width;

            IsShowLoading = false;
        }

        private bool _isShowLoading;

        public bool IsShowLoading
        {
            get
            {
                return _isShowLoading;
            }
            set
            {
                _isShowLoading = value;
                ShowOrHide();
            }
        }

        public void ShowOrHide()
        {
            if (IsShowLoading)
            {
                IsRunning = true;
                IsVisible = true;
            }
            else
            {
                IsRunning = false;
                IsVisible = false;
            }
        }
    }
}
