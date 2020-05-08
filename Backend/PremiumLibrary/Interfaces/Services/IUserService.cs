using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremiumLibrary.Models.ViewModels.User;

namespace PremiumLibrary.Interfaces.Services
{
    public interface IUserService : IDisposable
    {
        Task<List<UserListingModel>> GetAll();
        Task<List<UserListingModel>> GetByRole(string roleId);
        Task<UserListingModel> GetById(string userId);

        Task<bool> IsOnDb(string userId);

        Task<string> Registration(Registration model);
        Task<string> Authorization(Authorization model);
    }
}