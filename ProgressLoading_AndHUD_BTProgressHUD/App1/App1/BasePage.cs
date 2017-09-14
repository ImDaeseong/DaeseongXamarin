using Xamarin.Forms;
using App1.Services;

namespace App1
{
    public class BasePage : ContentPage
    {
        public BasePage()
        {
        }

        public void Show()
        {
            DependencyService.Get<IProgressLoading>().Show();
        }

        public void Hide()
        {
            DependencyService.Get<IProgressLoading>().Hide();
        }        
    }
}
