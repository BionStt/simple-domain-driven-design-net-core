using Microsoft.EntityFrameworkCore;
using MinimalDDD.Domain.Aggregations.Users;
using MinimalDDD.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinimalDDD.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DBOContext _dboContext;

        public UserRepository(DBOContext dboContext)
        {
            _dboContext = dboContext;
        }

        public Task<bool> Auth(User user)
        {
           return _dboContext.User.AnyAsync(user => user.Email.Equals(user.Email) && user.Password.Equals(user.Password));
        }

        public Task<int> Change(User user)
        {
            var userInDataBase = GetUser(user.Id).Result;
            userInDataBase.Id = user.Id;
            userInDataBase.Name = user.Name;
            userInDataBase.Password = user.Password;
            _dboContext.Entry(user).State = EntityState.Modified;
            return _dboContext.SaveChangesAsync();
        }

        public Task<List<User>> GetAll()
        {
            return _dboContext.User.ToListAsync();
        }

        public Task<User> GetUser(int userId)
        {
            return _dboContext.User.FirstOrDefaultAsync(e => e.Id.Equals(userId));
        }

        public Task<int> Register(User user)
        {
            _dboContext.User.AddAsync(user);
            return _dboContext.SaveChangesAsync();
        }
    }
}
