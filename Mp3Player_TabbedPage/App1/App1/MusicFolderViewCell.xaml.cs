using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MusicFolderViewCell : ViewCell
    {
        public MusicFolderViewCell()
        {
            InitializeComponent();
            
            this.View.BackgroundColor = Color.FromHex("#FF4081"); 
        }
    }
}