using movieShop.Core.Entities;
using movieShop.Core.RepositoryInterfaces;
using movieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace movieShop.Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IAsyncRepository<Genre> _repository;
        public GenreService(IAsyncRepository<Genre> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await _repository.ListAllAsync();
        }
    }
}
