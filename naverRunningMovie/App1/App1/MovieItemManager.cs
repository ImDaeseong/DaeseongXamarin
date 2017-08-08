using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    public class MovieItemManager
    {
        IMovieService movieService;

        public MovieItemManager(IMovieService service)
        {
            movieService = service;
        }

        public Task GetTasksAsync()
        {
            return movieService.RefreshDataAsync();
        }
    }
}
