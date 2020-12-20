using movieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace movieShop.Core.RepositoryInterfaces
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetUserByEmail(string email);
    }
}
