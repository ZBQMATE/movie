using System;
using System.Collections.Generic;
using System.Text;

namespace movieShop.Core.Entities
{
    public class Cast
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Gender { get; set; }
        public String TmdbUrl { get; set; }
        public String ProfilePath { get; set; }
        public ICollection<MovieCast> MovieCasts { get; set; }

    }
}
