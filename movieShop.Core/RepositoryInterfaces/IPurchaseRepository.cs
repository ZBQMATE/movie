using movieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace movieShop.Core.RepositoryInterfaces
{
    public interface IPurchaseRepository : IAsyncRepository<Purchase>
    {
        Task<IEnumerable<Purchase>> GetAllPurchases(int pageSize = 30, int pageIndex = 0);
        Task<IEnumerable<Purchase>> GetAllPurchasesByMovie(int movieId, int pageSize = 30, int pageIndex = 0);
    }
}
