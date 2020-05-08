using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremiumLibrary.Models.DataBaseModels;

namespace PremiumLibrary.Interfaces.Repositories
{
    public interface IRoleRepository : IDisposable
    {
        Task<List<Role>> GetAll();
        Task<Role> GetById(string id);

        Task<Role> Add(string name);
        Task Delete(Role role);

        Task AddUserRole(string userId, Role role);
        Task DeleteUserRole(UserRole userRole);
    }
}