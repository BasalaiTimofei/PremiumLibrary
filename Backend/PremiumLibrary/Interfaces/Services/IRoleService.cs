using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremiumLibrary.Models.ViewModels.Role;
using PremiumLibrary.Models.ViewModels.User;

namespace PremiumLibrary.Interfaces.Services
{
    public interface IRoleService : IDisposable
    {
        Task<string> Create(string name);
        Task InviteUser(string userId, string roleId);
        Task LeaveUser(string userId, string roleId);
        Task<List<UserListingModel>> GetUsersByRole(string roleId);
        Task<List<RoleListingModel>> GetAll();
    }
}