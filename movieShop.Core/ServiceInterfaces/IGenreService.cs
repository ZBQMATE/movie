using movieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace movieShop.Core.ServiceInterfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetAllGenres();
    }
}
