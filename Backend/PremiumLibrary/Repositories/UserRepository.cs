using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PremiumLibrary.Context;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Models.DataBaseModels;

namespace PremiumLibrary.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _applicationContext;
        private bool _disposed;

        public UserRepository(ApplicationContext applicationContext)
            => _applicationContext = applicationContext;

        public async Task<User> Add(User model)
        {
            model.Roles = new List<UserRole>();
            model.Id = Guid.NewGuid().ToString();
            await _applicationContext.Users.AddAsync(model);
            await _applicationContext.SaveChangesAsync();
            return await _applicationContext.Users.FindAsync(model.Id);
        }

        public async Task Delete(string userId)
        {
            var user = await _applicationContext.Users.FirstOrDefaultAsync(w => string.Equals(w.Id, userId));
            _applicationContext.Users.Remove(user);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            _applicationContext.Users.Remove(user);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            var userDb = await _applicationContext.Users.FirstOrDefaultAsync(w => string.Equals(w.Id, user.Id));
            var entry = _applicationContext.Entry(userDb);
            entry.CurrentValues.SetValues(user);
            entry.Property(w => w.Id).IsModified = false;
            await _applicationContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return await _applicationContext.Users.ToListAsync();
        }

        public async Task<User> GetById(string id)
        {
            return await _applicationContext.Users.FirstOrDefaultAsync(w => string.Equals(w.Id, id));
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _applicationContext.Dispose();
            }

            _disposed = true;
        }
    }
}
