using System;
using Xamarin.Forms;
using App2.iOS.Services;
using App2.Services;

[assembly: Dependency(typeof(CWallPaper))]
namespace App2.iOS.Services
{
    public class CWallPaper : IWallPaper
    {
        //private readonly WallpaperManager wallImg = WallpaperManager.GetInstance(Android.App.Application.Context);

        public CWallPaper()
        {
        }

        public void SetChangeWallPaperImage()
        {
            Random random = new Random();
            int nRandomNumber = random.Next(3);
            if (nRandomNumber == 0)
            {
                //wallImg.SetResource(Resource.Drawable.a);
            }
            else if (nRandomNumber == 1)
            {
                //wallImg.SetResource(Resource.Drawable.b);
            }
            else if (nRandomNumber == 2)
            {
                //wallImg.SetResource(Resource.Drawable.bg);
            }
        }

    }
}