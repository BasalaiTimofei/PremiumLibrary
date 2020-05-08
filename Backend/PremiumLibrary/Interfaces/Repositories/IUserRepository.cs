using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremiumLibrary.Models.DataBaseModels;

namespace PremiumLibrary.Interfaces.Repositories
{
    public interface IUserRepository : IDisposable
    {
        Task<List<User>> GetAll();
        Task<User> GetById(string id);

        Task<User> Add(User model);
        Task Delete(User user);

        Task Update(User user);
    }
}