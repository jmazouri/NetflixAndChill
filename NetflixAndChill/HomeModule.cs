using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Responses;
using Newtonsoft.Json;

namespace NetflixAndChill
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = x => View["Index"];

            Get["/currentMovie"] = x =>
            {
                if (!MovieDatabase.CachedMovies.Any()) { return null; }
                return GenerateJsonResponse(MovieDatabase.CachedMovies[0]);
            };
            
            Get["/Images/{id}"] = x =>
            {
                if (x.id == null) { return new Response().WithStatusCode(HttpStatusCode.NotFound); }

                Movie foundMovie = MovieDatabase.GetMovieInfo(x.id);
                if (foundMovie == null) { return new Response().WithStatusCode(HttpStatusCode.NotFound); }

                return new GenericFileResponse(foundMovie.BackgroundUrl, "image/jpeg");
            };

            Get["/search/{title}"] = x =>
            {
                if (x.title == null) { return new Response().WithStatusCode(HttpStatusCode.NotFound); }

                List<Movie> foundMovies = MovieDatabase.SearchMovies(x.title);

                return GenerateJsonResponse(foundMovies);
            };

            Get["/movies"] = x => GenerateJsonResponse(new [] 
            {
                MovieDatabase.GetMovieInfo(286217),
                MovieDatabase.GetMovieInfo(76341),
                MovieDatabase.GetMovieInfo(177572),
                MovieDatabase.GetMovieInfo(257344),
                MovieDatabase.GetMovieInfo(158852),
                MovieDatabase.GetMovieInfo(99861),
                MovieDatabase.GetMovieInfo(456, true),
                MovieDatabase.GetMovieInfo(1402, true)
            });

        }

        private static Response GenerateJsonResponse(object model)
        {
            return new TextResponse(JsonConvert.SerializeObject(model), "application/json");
        }
    }
}
