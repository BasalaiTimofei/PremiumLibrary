using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremiumLibrary.Models.ViewModels.Role;

namespace PremiumLibrary.Interfaces.Services
{
    public interface IRoleService : IDisposable
    {
        Task<List<RoleListingModel>> GetAll();
        Task<RoleListingModel> GetById(string roleId);

        Task<string> Create(string name);
        Task InviteUser(string userId, string roleId);
        Task LeaveUser(string userId, string roleId);
    }
}