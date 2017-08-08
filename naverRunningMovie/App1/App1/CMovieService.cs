using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;

namespace App1
{
    public class CMovieService : IMovieService
    {
        HttpClient client;

        public CMovieService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 4096000;
        }

        public async Task RefreshDataAsync()
        {
            var uri = new Uri(string.Format("http://movie.naver.com/movie/running/current.nhn#", string.Empty));

            try
            {                
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                                                            
                    int nIndex = 0;
                    int lastIndex = 0;

                    int nTotalIndex = content.Length;
                    while (nTotalIndex >= nIndex)
                    {
                        nIndex = content.IndexOf("<div class=\"thumb\">", lastIndex);
                        lastIndex = content.IndexOf("</div>", nIndex);

                        string sData = content.Substring(nIndex, (lastIndex - nIndex));
                        if (sData == "") continue;
                        //Debug.WriteLine(sData);

                        
                        //title
                        int nTitletKey = sData.IndexOf("alt=") + 4;
                        if (nTitletKey == -1) continue;

                        int nTitlefirst = sData.IndexOf("\"", nTitletKey) + 1;
                        int nTitleSecond = sData.IndexOf("\"", nTitlefirst);

                        string sTitle = sData.Substring(nTitlefirst, (nTitleSecond - nTitlefirst));
                        Debug.WriteLine(sTitle);


                        //image
                        int nImageKey = sData.IndexOf("<img src=") + 9;
                        if (nImageKey == -1) continue;

                        int nImagefirst = sData.IndexOf("\"", nImageKey) + 1;
                        int nImageSecond = sData.IndexOf("\"", nImagefirst);

                        string sImage = sData.Substring(nImagefirst, nImageSecond - nImagefirst);
                        Debug.WriteLine(sImage);

                        Movie lstMovie = new Movie();
                        lstMovie.Title = sTitle;
                        lstMovie.ImageUrl = sImage;
                        Movie.All.Add(lstMovie);
                    }                    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Exception {0}", ex.Message);
            }
        }

    }
}
