using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PremiumLibrary.Context;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Models.DataBaseModels;

namespace PremiumLibrary.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationContext _applicationContext;
        private bool _disposed;

        public RoleRepository(ApplicationContext applicationContext) 
            => _applicationContext = applicationContext;

        public async Task<Role> Add(string name)
        {
            var role = new Role
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Users = new List<UserRole>()
            };

            await _applicationContext.Roles.AddAsync(role);
            await _applicationContext.SaveChangesAsync();

            return await _applicationContext.Roles.FirstOrDefaultAsync(w => string .Equals(w.Id, role.Id));
        }

        public async Task Delete(string roleId)
        {
            var role = await _applicationContext.Roles.FirstOrDefaultAsync(w => string.Equals(w.Id, roleId));
            if (role == null) return;
            _applicationContext.Roles.Remove(role);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task Delete(Role role)
        {
            if (role == null) return;
            _applicationContext.Roles.Remove(role);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task AddUserRole(User user, Role role)
        {
            await _applicationContext.UserRoles.AddAsync(new UserRole
            {
                Id = Guid.NewGuid().ToString(),
                RoleId = role.Id,
                UserId = user.Id,
                Role = role,
                User = user
            });
            await _applicationContext.SaveChangesAsync();
        }

        public async Task DeleteUserRole(UserRole userRole)
        {
            _applicationContext.UserRoles.Remove(userRole);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task<List<Role>> GetAll()
        {
            var result = await _applicationContext.Roles.ToListAsync();
            return result;
        }

        public async Task<Role> GetById(string id)
        {
            var result = await _applicationContext.Roles.FindAsync(id);
            return result;
        }

        public async Task<Role> GetByName(string name)
        {
            var role = await _applicationContext.Roles.FirstOrDefaultAsync(w => string.Equals(w.Name, name));
            return role;
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