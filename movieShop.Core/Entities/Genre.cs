using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace movieShop.Core.Entities
{
    [Table("Genre")]
    public class Genre
    {
        public int id { get; set; }
        [MaxLength(24)]
        public String Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
