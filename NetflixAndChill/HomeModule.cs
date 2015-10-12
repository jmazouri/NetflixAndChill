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
        public HomeModule()
        {
            Get["/"] = x => View["Index"];

            Get["/movies"] = x =>
            {
                return JsonConvert.SerializeObject(new [] 
                {
                    MovieDatabase.GetMovieInfo("Attack on Titan"),
                    MovieDatabase.GetMovieInfo("The Office")
                });
            };
        }
    }
}
