using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using movieShop.Core.Entities;
using movieShop.Core.RepositoryInterfaces;
using movieShop.Infrastructure.Data;

namespace movieShop.Infrastructure.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(movieShopDbContext dbContext) : base(dbContext)
        { }
        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
