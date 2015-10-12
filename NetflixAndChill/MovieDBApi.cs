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

namespace NetflixAndChill
{
    public static class MovieDBApi
    {
        public static Movie GetMovie(string title)
        {
            string baseUrl = "http://api.themoviedb.org/3/search/movie?";
            string apikey = ConfigurationManager.AppSettings["moviedbkey"];
            string queryURL = $"{baseUrl}api_key={apikey}&query={HttpUtility.UrlEncode(title)}";

            try
            { 
                string result = new WebClient().DownloadString(queryURL);
                Movie foundMovie = JsonConvert.DeserializeObject<List<Movie>>(JObject.Parse(result)["results"].ToString()).First();
                return foundMovie;
            }
            catch (WebException ex)
            {
                return null;
            }

        }
    }
}
