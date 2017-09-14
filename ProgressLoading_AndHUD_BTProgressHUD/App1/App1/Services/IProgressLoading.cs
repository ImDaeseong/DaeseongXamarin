
namespace App1.Services
{
    public interface IProgressLoading
    {
        void Show(string title = "Loading");

        void Hide();
    }
}
