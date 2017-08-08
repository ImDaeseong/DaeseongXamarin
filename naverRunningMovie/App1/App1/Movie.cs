using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    public class Movie
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }

        public static IList<Movie> All { get; set; }

        static Movie()
        {
            All = new ObservableCollection<Movie>();
        }
    }
}
