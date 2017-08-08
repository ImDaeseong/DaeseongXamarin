using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace RenderTest.ImageButton
{
    public  class ImageButtonModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void Notify(string sParam)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(sParam));
            }
        }


        private string _ImageButtonName;
        public string ImageButtonName
        {
            get
            {
                return _ImageButtonName;
            }
            set
            {
                _ImageButtonName = value; this.Notify("ImageButton");
            }
        }

        private int i = 0;
        private void ImageButtonque(object oParam)
        {
            this.ImageButtonName = string.Format("ImageButton {0}", i++);
        }


        public ICommand ImageButtonCommand
        {
            get;
            set;
        }

        public ImageButtonModel()
        {
            this.ImageButtonCommand = new Command(this.ImageButtonque);
        }

    }
}
