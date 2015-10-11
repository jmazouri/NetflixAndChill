using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Nancy.Helpers;
using Newtonsoft.Json;

namespace NetflixAndChill.Roulette
{
    public static class NetflixRoulette
    {
        public static Movie GetMovie(string title)
        {
            string baseUrl = "http://netflixroulette.net/api/api.php?";
            string queryURL = $"{baseUrl}title={HttpUtility.UrlEncode(title)}";

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
    }
}
