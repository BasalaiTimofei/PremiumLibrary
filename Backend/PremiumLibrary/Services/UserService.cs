using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        public async Task<string> Registration(Registration model)
        {
            var users = await _userRepository.GetAll();
            if (users.Any(w => w.UserName == model.UserName) 
                || users.Any(w => w.EmailAddress == model.EmailAddress))
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
            await _userRepository.Add(user);
            return user.Id;
        }

        public async Task<string> Authorization(Authorization model)
        {
            var users = await _userRepository.GetAll();
            var user = users.FirstOrDefault(w =>
                string.Equals(w.EmailAddress, model.UserNameOrEmailAddress) || string.Equals(w.UserName, model.UserNameOrEmailAddress));

            if (user == null) throw new Exception(); //TODO Пользователь ненайден

            if (!string.Equals(model.Password, user.Password))
            {
                throw new Exception();
            }

            return user.Id;
        }

        public Task<List<UserListingModel>> GetAll()
        {
            return _userRepository.GetAll()
                .ContinueWith(w => _mapper.Map<List<UserListingModel>>(w.Result));
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