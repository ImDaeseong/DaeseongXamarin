using System;
using System.ComponentModel;
using System.Linq;
using System.IO;
using System.Net;
using System.Threading;
using Xamarin.Forms;
using App1.Droid.Services;
using App1.Services;

[assembly: Dependency(typeof(DownloadProgress))]
namespace App1.Droid.Services
{
    public class DownloadProgress : IDownload
    {
        public string ContentPath
        {
            get
            {
                return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            }
        }

        public void DownloadFile()
        {
            ThreadPool.QueueUserWorkItem((object state) =>
            {
                var fullFilename = Path.Combine(ContentPath, App.Self.Url.Split('/').Last());

                if (File.Exists(fullFilename))
                    File.Delete(fullFilename);

                if (!File.Exists(fullFilename))
                {
                    var wc = new WebClient();
                    wc.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    wc.DownloadFileAsync(new Uri(App.Self.Url), fullFilename);
                }
                else
                {
                    MainActivity.Active.RunOnUiThread(() => App.Self.DownloadProgress++);
                }
            });
        }

        void Completed(object sender, AsyncCompletedEventArgs e)
        {
            MainActivity.Active.RunOnUiThread(() => App.Self.DownloadProgress++);
        }

        public long GetDownloadSize()
        {
            var client = new WebClient();
            client.OpenRead(App.Self.Url);
            return Convert.ToInt64(client.ResponseHeaders["Content-Length"]);
        }

        public string GetFilename()
        {
            return Path.Combine(ContentPath, App.Self.Url.Split('/').Last());
        }
    }
}