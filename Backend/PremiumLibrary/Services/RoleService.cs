using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PremiumLibrary.Exceptions;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Interfaces.Services;
using PremiumLibrary.Models.ViewModels.Role;

namespace PremiumLibrary.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private bool _disposed;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<List<RoleListingModel>> GetAll()
        {
            var result = await _roleRepository.GetAll();
            if (result == null) throw new ServerException("Сервер вернул null");
            return _mapper.Map<List<RoleListingModel>>(result);
        }

        public async Task<RoleListingModel> GetById(string roleId)
        {
            if (string.IsNullOrWhiteSpace(roleId)) throw new CustomException("ID роли не был задан");
            var result = await _roleRepository.GetById(roleId);
            if (result == null) throw new ServerException("Сервер вернул null");
            return _mapper.Map<RoleListingModel>(result);
        }

        public async Task<string> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new CustomException("Имя не было заданно");
            var roles = await _roleRepository.GetAll();
            if (roles == null) throw new ServerException("Сервер вернул null");
            if (roles.Any(w => string.Equals(w.Name, name))) throw new CustomException("Такая роль уже есть");
            var result = await _roleRepository.Add(name);
            if (result == null) throw new ServerException("Проблемы с БД");
            return result.Id;
        }

        //TODO проверка юзаре выше
        public async Task InviteUser(string userId, string roleId)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(roleId)) 
                throw new CustomException("Некоректные данные");
            var role = await _roleRepository.GetById(roleId);
            if (role == null) throw new CustomException("Роль не найдена");
            if (role.Users.Any(w => string.Equals(w.UserId, userId))) 
                throw new CustomException("Этот пользователь уже имеет эту роль");
            await _roleRepository.AddUserRole(userId, role);
        }

        public async Task LeaveUser(string userId, string roleId)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(roleId))
                throw new CustomException("Некоректные данные");
            var role = await _roleRepository.GetById(roleId);
            if (role == null) throw new CustomException("Роль не найдена");
            var result = role.Users.FirstOrDefault(w => string.Equals(w.UserId, userId));
            if (result == null)
                throw new CustomException("Этот пользователь неимеет эту роль");
            await _roleRepository.DeleteUserRole(result);
        }

        public void Dispose()
        {
            if (_disposed) return;
            _roleRepository?.Dispose();
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        ~RoleService()
        {
            Dispose();
        }
    }
}