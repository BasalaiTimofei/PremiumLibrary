using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremiumLibrary.Models.DataBaseModels;

namespace PremiumLibrary.Interfaces.Repositories
{
    public interface IRoleRepository : IDisposable
    {
        Task<Role> Add(string name);
        Task Delete(string roleId);
        Task Delete(Role role);
        Task AddUserRole(User user, Role role);
        Task DeleteUserRole(UserRole userRole);
        Task<List<Role>> GetAll();
        Task<Role> GetById(string id);
        Task<Role> GetByName(string name);
    }
}
