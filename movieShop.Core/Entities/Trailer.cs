using System;
using System.Collections.Generic;
using System.Text;

namespace movieShop.Core.Entities
{
    public class Trailer
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public String TrailerUrl { get; set; }
        public String Name { get; set; }
        //navigatuion proporty
        public Movie Movie { get; set; }

    }
}
