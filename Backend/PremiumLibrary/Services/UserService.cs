using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PremiumLibrary.Context;
using PremiumLibrary.Models.DataBaseModels;
using PremiumLibrary.Models.ViewModels;

namespace PremiumLibrary.Services
{
    public class UserService
    {
        private readonly ApplicationContext _applicationContext;

        public UserService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<string> Registration(RegistrationUser model)
        {
            if (_applicationContext.Users.Any(w => w.UserName == model.UserName) 
                || _applicationContext.Users.Any(w => w.EmailAddress == model.EmailAddress))
            {
                throw new Exception();
            }

            if (model.Password != model.ConfirmPassword)
            {
                throw new Exception();
            }

            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                EmailAddress = model.EmailAddress,
                UserName = model.UserName,
                Password = model.Password
            };
            await _applicationContext.Users.AddAsync(user);
            await _applicationContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task<string> Authorization(AuthorizationUser model)
        {
            var user = await _applicationContext.Users.FirstOrDefaultAsync(w =>
                string.Equals(w.EmailAddress, model.UserNameOrEmailAddress) || string.Equals(w.UserName, model.UserNameOrEmailAddress));

            if (!string.Equals(model.Password, user.Password))
            {
                throw new Exception();
            }

            return user.Id;
        }

        public async Task<List<string>> GetAll()
        {
            var result = await _applicationContext.Users.Select(w => w.Id).ToListAsync();

            return result;
        }
    }
}