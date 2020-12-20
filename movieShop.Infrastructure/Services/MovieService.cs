using movieShop.Core.Entities;
using movieShop.Core.Models.Response;
using movieShop.Core.RepositoryInterfaces;
using movieShop.Core.ServiceInterfaces;
using movieShop.Infrastructure.Data;
using movieShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace movieShop.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        private Movie movie;

        public MovieService(IMovieRepository repository)
        {
            // create MovieRepo instance in every method in my service class
            // newing up is very convineint but we need to avoid it as much as we can
            // make sure you dont break any existing code....
            // always go back do the regression testing...
            //  _repository = new MovieRepository(new MovieShopDbContext(null));
            _repository = repository;
        }

        //public Task<MovieDetailsResponseModel> CreateMovie(MovieCreateRequest movieCreateRequest)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<PagedResultSet<>> GetAllMoviePurchasesByPagination(int pageSize = 20, int page = 0)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<PaginatedList<>> GetAllPurchasesByMovieId(int movieId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<MovieResponseModel>> GetHighestGrossingMovies()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<MovieDetailsResponseModel> GetMovieAsync(int id)
        {
            movie = await _repository.GetByIdAsync(id);

            var response = new MovieDetailsResponseModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                PosterUrl = movie.PosterUrl,
                BackdropUrl = movie.BackdropUrl,
                Budget = movie.Budget,
                ImdbUrl = movie.ImdbUrl,
                Overview = movie.Overview,
                TmdbUrl = movie.TmdbUrl,
                ReleaseDate = movie.ReleaseDate,
                RunTime = movie.RunTime,
                Price = movie.Price,
                Revenue = movie.Revenue,
                Tagline = movie.Tagline
            };
            return response;
            
        }

        //public Task<IEnumerable<MovieResponseModel>> GetMoviesByGenre(int genreId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<PagedResultSet<>> GetMoviesByPagination(int pageSize = 20, int page = 0, string title = "")
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<int> GetMoviesCount(string title = "")
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<ReviewMovieResponseModel>> GetReviewsForMovie(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<MovieResponseModel>> GetTopRatedMovies()
        //{
        //    throw new NotImplementedException();
        //}

        //Task<IEnumerable<MovieResponseModel>> GetTopRevenueMovies();
        public async Task<IEnumerable<MovieResponseModel>> GetTopRevenueMovies()
        {
            // Repository ?
            // MovieRepository class            
            //var repository = new MovieRepository(new movieShopDbContext(null));            
            var movies = await _repository.GetHighestRevenueMovies();
            // Map our Movie Entity to MovieResponseModel
            var movieResponseModel = new List<MovieResponseModel>();
            foreach (var movie in movies)
            {
                movieResponseModel.Add(new MovieResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    ReleaseDate = movie.ReleaseDate.Value,
                    Title = movie.Title
                });
            }
            return movieResponseModel;
        }

        //public Task<MovieDetailsResponseModel> UpdateMovie(MovieCreateRequest movieCreateRequest)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
