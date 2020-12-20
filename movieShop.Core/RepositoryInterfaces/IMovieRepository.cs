using movieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace movieShop.Core.RepositoryInterfaces
{
    public interface IMovieRepository : IAsyncRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetTopRatedMovies();
        Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId);
        Task<IEnumerable<Movie>> GetHighestRevenueMovies();
        //Task<Movie> GetByIdAsync(int id);
    }
}
