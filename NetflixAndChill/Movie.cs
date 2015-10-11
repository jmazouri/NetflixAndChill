using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NetflixAndChill
{
    public enum MediaType
    {
        Movie = 0,
        TvShow = 1
    }

    public class Movie
    {
        public string Show_Title { get; set; }
        public string Summary { get; set; }

        public int Show_Id { get; set; }

        public int Release_Year { get; set; }
        public decimal Rating { get; set; }
        public string Category { get; set; }
        public string Show_Cast { get; set; }
        public string Director { get; set; }

        public MediaType MediaType { get; set; }
        public string Runtime { get; set; }
    }
}
