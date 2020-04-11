using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PremiumLibrary.Exceptions;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Interfaces.Services;
using PremiumLibrary.Models.ViewModels.Role;
using PremiumLibrary.Models.ViewModels.User;

namespace PremiumLibrary.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private bool _disposed;

        public RoleService(IRoleRepository roleRepository, IMapper mapper, IUserRepository userRepository)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<string> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new CustomException("Имя не было заданно");
            
            var roles = await _roleRepository.GetAll();
            
            if (roles.Any(w => string.Equals(w.Name, name))) throw new CustomException("Такая роль уже есть");
            
            var result = await _roleRepository.Add(name);
            
            if (result == null) throw new CustomException("Проблемы с БД");
            
            return result.Name;
        }

        public async Task InviteUser(string userId, string roleId)
        {
            if (string.IsNullOrWhiteSpace(userId)) throw new CustomException("ID пользователя не был задан");
            if (string.IsNullOrWhiteSpace(roleId)) throw new CustomException("ID роли не был задан");
            
            var user = await _userRepository.GetById(userId);
            if (user == null) throw new CustomException("Пользователь не найден");

            var role = await _roleRepository.GetById(roleId);
            if (role == null) throw new CustomException("Роль не найдена");

            if (user.Roles.Any(w => string.Equals(w.RoleId, roleId)))
                throw new CustomException("Этот пользователь уже имеет эту роль");
   
            await _roleRepository.AddUserRole(user, role);
        }

        public async Task LeaveUser(string userId, string roleId)
        {
            if (string.IsNullOrWhiteSpace(userId)) throw new CustomException("ID пользователя не был задан");
            if (string.IsNullOrWhiteSpace(roleId)) throw new CustomException("ID роли не был задан");

            var user = await _userRepository.GetById(userId);
            if (user == null) throw new CustomException("Пользователь не найден");

            var role = await _roleRepository.GetById(roleId);
            if (role == null) throw new CustomException("Роль не найдена");

            if (!user.Roles.Any(w => string.Equals(w.RoleId, roleId)))
                throw new CustomException("Этот пользователь неимеет эту роль");

            await _roleRepository.DeleteUserRole(_userRepository.GetById(userId)
                .Result.Roles.FirstOrDefault(q => string.Equals(q.RoleId, role.Id)));
        }

        public async Task<List<UserListingModel>> GetUsersByRole(string roleId)
        {
            if (string.IsNullOrWhiteSpace(roleId)) throw new CustomException("ID роли не был задан");

            var role = await _roleRepository.GetById(roleId);
            if (role == null) throw new CustomException("Роль не найдена");

            var users = role.Users.Select(w => w.User);
            if (users == null) throw new CustomException("С такой ролью, нет пользователей");

            return _mapper.Map<List<UserListingModel>>(users);
        }

        public async Task<List<RoleListingModel>> GetAll()
        {
            var result = await _roleRepository.GetAll();
            
            if (result == null) throw new CustomException("Роли не найдены");
            
            return _mapper.Map<List<RoleListingModel>>(result);
        }

        public void Dispose()
        {
            if (_disposed) return;
            _roleRepository?.Dispose();
            _userRepository?.Dispose();
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        ~RoleService()
        {
            Dispose();
        }
    }
}