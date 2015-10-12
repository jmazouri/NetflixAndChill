using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace NetflixAndChill
{
    public static class MovieDatabase
    {
        static LiteDatabase _db = new LiteDatabase("movies.db");

        private static LiteCollection<Movie> MovieCollection
        {
            get
            {
                return _db.GetCollection<Movie>("movies");
            }
        }

        public static List<Movie> CachedMovies
        {
            get
            {
                return MovieCollection.FindAll().ToList();
            }
        }

        public static Movie GetMovieInfo(string title)
        { 
            Movie found = MovieCollection.Find(x => x.Title == title).FirstOrDefault();

            if (found == null)
            {
                var rouletteMovie = MovieDBApi.GetMovie(title);

                if (rouletteMovie != null)
                {
                    MovieCollection.Insert(rouletteMovie);
                }

                return rouletteMovie;
            }

            return found;
        }
    }
}
