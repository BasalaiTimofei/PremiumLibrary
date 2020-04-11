using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremiumLibrary.Models.DataBaseModels;

namespace PremiumLibrary.Interfaces.Repositories
{
    public interface IUserRepository : IDisposable
    {
        Task<User> Add(User model);
        Task Delete(string userId);
        Task Delete(User user);
        Task Update(User user);
        Task<List<User>> GetAll();
        Task<User> GetById(string id);
    }
}
