using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Nancy.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.IO;

namespace NetflixAndChill
{
    public static class MovieDBApi
    {
        public static string ApiKey = ConfigurationManager.AppSettings["moviedbkey"];
        public static string BackdropBasePath = "Images/Backdrops";

        public static void DownloadBackdrop(Movie movie)
        {
            string baseurl = "http://image.tmdb.org/t/p/w500";
            Directory.CreateDirectory(BackdropBasePath);
            
            new WebClient().DownloadFile($"{baseurl}{movie.Backdrop_Path}?api_key={ApiKey}", Path.Combine(BackdropBasePath, movie.Backdrop_Path.Substring(1)));
        }

        public static Movie GetMovie(int id)
        {
            string baseUrl = "http://api.themoviedb.org/3/movie";
            string queryURL = $"{baseUrl}/{id}?api_key={ApiKey}";

            try
            {
                string result = new WebClient().DownloadString(queryURL);
                Movie foundMovie = JsonConvert.DeserializeObject<Movie>(result);
                return foundMovie;
            }
            catch (WebException ex)
            {
                return null;
            }
        }

        public static Movie GetTVShow(int id)
        {
            string baseUrl = "http://api.themoviedb.org/3/tv";
            string queryURL = $"{baseUrl}/{id}?api_key={ApiKey}";

            try
            {
                string result = new WebClient().DownloadString(queryURL);
                Movie foundMovie = JsonConvert.DeserializeObject<Movie>(result);
                return foundMovie;
            }
            catch (WebException ex)
            {
                return null;
            }
        }

        public static List<Movie> SearchMovie(string title)
        {
            string baseUrl = "http://api.themoviedb.org/3/search/movie?";
            string queryURL = $"{baseUrl}api_key={ApiKey}&query={HttpUtility.UrlEncode(title)}";

            try
            { 
                string result = new WebClient().DownloadString(queryURL);
                var foundMovies = JsonConvert.DeserializeObject<List<Movie>>(JObject.Parse(result)["results"].ToString());
                return foundMovies;
            }
            catch (WebException ex)
            {
                return null;
            }

        }
    }
}
