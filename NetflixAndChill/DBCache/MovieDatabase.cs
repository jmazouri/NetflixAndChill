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

        private static LiteCollection<Movie> MovieCollection => _db.GetCollection<Movie>("movies");

        public static List<Movie> CachedMovies => MovieCollection.FindAll().ToList();

        public static Movie GetMovieInfo(int id, bool tvShow = false)
        {
            Movie found = MovieCollection.FindById(id);

            if (found != null) return found;
            
            Movie rouletteMovie = tvShow ? MovieDBApi.GetTVShow(id) : MovieDBApi.GetMovie(id);

            if (rouletteMovie == null) return null;

            MovieCollection.Insert(rouletteMovie);
            MovieDBApi.DownloadBackdrop(rouletteMovie);

            return rouletteMovie;
        }
    }
}
