using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NetflixAndChill
{
    public class Movie
    {
        public bool Adult { get; set; }
        public string Backdrop_Path { get; set; }
        public long[] Genre_Ids { get; set; }
        public long Id { get; set; }

        public string Overview { get; set; }
        public string Release_Date { get; set; }
        public string Poster_Path { get; set; }
        public float Popularity { get; set; }
        public string Title { get; set; }

        public string BackgroundUrl => MovieDBApi.BackdropBasePath + Backdrop_Path;

        [Obsolete("Please use Title instead")]
        public string Name
        {
            get { return Title; }
            set { Title = value; }
        }
        public float Vote_Average { get; set; }
        public long Vote_Count { get; set; }
    }
}
