using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using System.Text;
using System.Linq;

namespace App3
{
    class FileHelper
    {
        IBaseUrl fileHelper = DependencyService.Get<IBaseUrl>();

        public string BaseUrl
        {
            get
            {
                return fileHelper.Get();
            }
        }

        public List<string> MusicFolder
        {
            get
            {
                return fileHelper.GetMusic();
            }
        }
       
    }
}
