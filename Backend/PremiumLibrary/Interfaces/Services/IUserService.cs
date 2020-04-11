using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremiumLibrary.Models.ViewModels.User;

namespace PremiumLibrary.Interfaces.Services
{
    public interface IUserService : IDisposable
    {
        Task<string> Registration(Registration model);
        Task<string> Authorization(Authorization model);
        Task<List<UserListingModel>> GetAll();
    }
}
