using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinimalDDD.Domain.Aggregations.Users
{
    public interface IUserRepository
    {
        Task<int> Register(User user);
        Task<bool> Auth(User user);
        Task<int> Change(User user);
        Task<User> GetUser(int userId);
        Task<List<User>> GetAll();
    }
}
