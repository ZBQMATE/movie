using movieShop.Core.Entities;
using movieShop.Core.RepositoryInterfaces;
using movieShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace movieShop.Infrastructure.Repositories
{
    class PurchaseRepository : EfRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(movieShopDbContext dbContext) : base(dbContext)
        {
        }
        public Task<IEnumerable<Purchase>> GetAllPurchases(int pageSize = 30, int pageIndex = 0)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Purchase>> GetAllPurchasesByMovie(int movieId, int pageSize = 30, int pageIndex = 0)
        {
            throw new NotImplementedException();
        }
    }
}
