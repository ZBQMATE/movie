using Microsoft.EntityFrameworkCore;
using movieShop.Core.Entities;
using movieShop.Core.RepositoryInterfaces;
using movieShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movieShop.Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(movieShopDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Movie>> GetTopRatedMovies()
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Movie>> GetHighestRevenueMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(50).ToListAsync();
            return movies;
        }
        public override async Task<Movie> GetByIdAsync(int id)
        {
            var movie = await _dbContext.Movies
                                        .Include(m => m.MovieCasts).ThenInclude(m => m.Cast).Include(m => m.Genres)
                                        //.ThenInclude(m => m.Genre)
                                        .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null) return null;
            //var movieRating = await _dbContext.Reviews.Where(r => r.MovieId == id).DefaultIfEmpty()
            //                                  .AverageAsync(r => r == null ? 0 : r.Rating);
            //if (movieRating > 0) movie.Rating = movieRating;
            return movie;
        }
    }
}
