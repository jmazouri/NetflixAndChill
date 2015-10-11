using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixAndChill
{
    public class Movie
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public static List<Movie> TestMovies
        {
            get
            {
                List<Movie> ret = new List<Movie>();

                ret.Add(new Movie { Name = "Descent", Description = "People go into a cave or some shit" });
                ret.Add(new Movie { Name = "Cube", Description = "People go into a cube or some shit" });
                ret.Add(new Movie { Name = "Saw", Description = "People go get cut up or some shit" });
                ret.Add(new Movie { Name = "Unfriended", Description = "People go on Facebook or some shit" });

                return ret;
            }
        }
    }
}
