using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Newtonsoft.Json;

namespace NetflixAndChill
{
    public class HomeModule : NancyModule
    {
        public static int count = 4;
        public HomeModule()
        {
            
            Get["/"] = x => View["Index"];
            Get["/movies"] = x =>
            {
                return JsonConvert.SerializeObject(Movie.TestMovies.Take(count));
            };

            Get["/unmovies"] = x =>
            {
                count--;
                return new Response().WithStatusCode(HttpStatusCode.OK);
            };
        }
    }
}
