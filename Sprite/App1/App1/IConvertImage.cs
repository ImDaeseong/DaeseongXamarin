using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public interface IConvertImage
    {
        byte[] ImageToBinary(string sImg);

        void LoadImageSource(string sImg);

        byte[] Crop(int index);

        ImageSource CropImage(int index);
    }
}
