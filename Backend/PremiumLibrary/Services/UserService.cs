using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PremiumLibrary.Exceptions;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Interfaces.Services;
using PremiumLibrary.Models.DataBaseModels;
using PremiumLibrary.Models.ViewModels.User;

namespace PremiumLibrary.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private bool _disposed;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserListingModel>> GetAll()
        {
            var result = await _userRepository.GetAll();
            if (result == null) throw new ServerException("Сервер вернул null");
            return _mapper.Map<List<UserListingModel>>(result);
        }

        public async Task<List<UserListingModel>> GetByRole(string roleId)
        {
            if (string.IsNullOrWhiteSpace(roleId)) throw new CustomException("Поле roleId = null");
            var users = await _userRepository.GetAll();
            if (users == null) throw new ServerException("Сервер вернул null");
            var result = users.Where(w => w.Roles.Any(e => string.Equals(e.RoleId, roleId)));
            if (!result.Any()) throw new CustomException("Пользователей с такой ролью - нет");
            return _mapper.Map<List<UserListingModel>>(result);
        }

        public async Task<UserListingModel> GetById(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId)) throw new CustomException("Поле userId = null");
            var result = await _userRepository.GetById(userId);
            if (result == null) throw new CustomException("Юзер ненайден");
            return _mapper.Map<UserListingModel>(result);
        }

        public async Task<bool> IsOnDb(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId)) return false;
            var result = await _userRepository.GetById(userId);
            return result != null;
        }

        public async Task<string> Registration(Registration model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.EmailAddress) 
                || string.IsNullOrWhiteSpace(model.Password) 
                || string.IsNullOrWhiteSpace(model.UserName))
                throw new CustomException("Некорректные данные");
            var users = await _userRepository.GetAll();
            if (users == null) throw new ServerException("Сервер вернул null");
            if (users.Any(w => w.UserName == model.UserName) 
                || users.Any(w => w.EmailAddress == model.EmailAddress))
                throw new CustomException("Пользователь с таким Name или Email уже существуют");
            var result = await _userRepository.Add(_mapper.Map<User>(model));
            if (result == null) throw new ServerException("Сервер вернул null");
            return result.Id;
        }

        public async Task<string> Authorization(Authorization model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.UserNameOrEmailAddress) 
                || string.IsNullOrWhiteSpace(model.Password))
                throw new CustomException("Некорректные данные");
            var users = await _userRepository.GetAll();
            if (users == null) throw new ServerException("Сервер вернул null");
            var user = users.FirstOrDefault(w =>
                string.Equals(w.EmailAddress, model.UserNameOrEmailAddress) 
                || string.Equals(w.UserName, model.UserNameOrEmailAddress));
            if (user == null) throw new CustomException("Пользователь ненайден");
            if (!string.Equals(model.Password, user.Password))
                throw new CustomException("Пароль неверный");
            return user.Id;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _userRepository?.Dispose();
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        ~UserService()
        {
            Dispose();
        }
    }
}