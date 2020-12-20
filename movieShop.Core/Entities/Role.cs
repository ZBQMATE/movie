using System;
using System.Collections.Generic;
using System.Text;

namespace movieShop.Core.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
