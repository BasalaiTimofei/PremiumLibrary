using System;
using System.Collections.Generic;
using AutoMapper;
using Moq;
using NUnit.Framework;
using PremiumLibrary.Exceptions;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Mapping;
using PremiumLibrary.Models.DataBaseModels;
using PremiumLibrary.Models.ViewModels.Role;
using PremiumLibrary.Services;

namespace PremiumLibrary.Tests.Services
{
    [TestFixture]
    public class RoleTests
    {
        private MapperConfiguration _mapperConfiguration;
        private Mapper _mapper;
        private Mock<IRoleRepository> _mockRoleRepository;

        private Role _role;
        private List<Role> _roles;

        [SetUp]
        public void Init()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
                cfg.AddProfiles(new List<Profile>
                {
                    new RoleProfile()
                }));
            _mapper = new Mapper(_mapperConfiguration);
            _mockRoleRepository = new Mock<IRoleRepository>();
            _role = new Role
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User",
                Users = new List<UserRole>()
            };
            _roles = new List<Role>
            {
                _role, _role, _role
            };
        }

        [Test]
        public void Create_GoodArgument_Success()
        {
            _mockRoleRepository.Setup(r => r.GetAll()).ReturnsAsync(_roles);
            _mockRoleRepository.Setup(r => r.Add(It.IsAny<string>())).ReturnsAsync(_role);
            using var roleService = new RoleService(_mockRoleRepository.Object, _mapper);
            var create = roleService.Create("123");
            _mockRoleRepository.Verify(w => w.Add(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Create_GoodArgument_ReturnNull1_Exception()
        {
            _mockRoleRepository.Setup(r => r.GetAll()).ReturnsAsync(() => null);
            _mockRoleRepository.Setup(r => r.Add(It.IsAny<string>())).ReturnsAsync(_role);
            using var roleService = new RoleService(_mockRoleRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => roleService.Create("123"));
        }

        [Test]
        public void Create_GoodArgument_ReturnNull2_Exception()
        {
            _mockRoleRepository.Setup(r => r.GetAll()).ReturnsAsync(_roles);
            _mockRoleRepository.Setup(r => r.Add(It.IsAny<string>())).ReturnsAsync(() => null);
            using var roleService = new RoleService(_mockRoleRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => roleService.Create("123"));
        }


        [Test]
        public void Create_BadArgument_Exception()
        {
            _roles.Add(new Role
            {
                Id = Guid.NewGuid().ToString(),
                Users = new List<UserRole>(),
                Name = "123"
            });
            _mockRoleRepository.Setup(r => r.GetAll()).ReturnsAsync(_roles);
            using var roleService = new RoleService(_mockRoleRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => roleService.Create("123"));
        }

        [Test]
        public void Create_NullArgument_Exception()
        {
            using var roleService = new RoleService(_mockRoleRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => roleService.Create(null));
        }

        [Test]
        public void InviteUser_GoodArguments_Success()
        {
            _mockRoleRepository.Setup(r => r.GetById(It.IsAny<string>())).ReturnsAsync(_role);
            using var roleService = new RoleService(_mockRoleRepository.Object, _mapper);
            var inviteUser = roleService.InviteUser("123", "123");
            _mockRoleRepository.Verify(w => w.AddUserRole(It.IsAny<string>(), It.IsAny<Role>()), Times.Once);
        }

        [Test]
        public void InviteUser_GoodArguments_ReturnNull_Exception()
        {
            _mockRoleRepository.Setup(r => r.GetById(It.IsAny<string>())).ReturnsAsync(() => null);
            using var roleService = new RoleService(_mockRoleRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => roleService.InviteUser("123", "123"));
        }

        [Test]
        public void InviteUser_BadArgument_Exception()
        {
            var role = new Role
            {
                Id = Guid.NewGuid().ToString(),
                Name = "1332",
                Users = new List<UserRole>
                {
                    new UserRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        User = new User(),
                        Role = new Role(),
                        UserId = "123",
                        RoleId = Guid.NewGuid().ToString()
                    }
                }
            };
            _mockRoleRepository.Setup(r => r.GetById(It.IsAny<string>())).ReturnsAsync(role);
            using var roleService = new RoleService(_mockRoleRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => roleService.InviteUser("123", "123"));
        }

        [Test]
        public void InviteUser_NullArgument_Exception()
        {
            using var roleService = new RoleService(_mockRoleRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => roleService.InviteUser("123", null));
        }

        [Test]
        public void LeaveUser_GoodArguments_Success()
        {
            var role = new Role
            {
                Id = Guid.NewGuid().ToString(),
                Name = "1332",
                Users = new List<UserRole>
                {
                    new UserRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        User = new User(),
                        Role = new Role(),
                        UserId = "123",
                        RoleId = Guid.NewGuid().ToString()
                    }
                }
            };
            _mockRoleRepository.Setup(r => r.GetById(It.IsAny<string>())).ReturnsAsync(role);
            using var roleService = new RoleService(_mockRoleRepository.Object, _mapper);
            var leaveUser = roleService.LeaveUser("123", "123");
            _mockRoleRepository.Verify(w => w.DeleteUserRole(It.IsAny<UserRole>()), Times.Once);
        }

        [Test]
        public void LeaveUser_GoodArguments_ReturnNull_Exception()
        {
            _mockRoleRepository.Setup(r => r.GetById(It.IsAny<string>())).ReturnsAsync(() => null);
            using var roleService = new RoleService(_mockRoleRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => roleService.LeaveUser("123", "123"));
        }

        [Test]
        public void LeaveUser_BadArgument_Exception()
        {
            _mockRoleRepository.Setup(r => r.GetById(It.IsAny<string>())).ReturnsAsync(_role);
            using var roleService = new RoleService(_mockRoleRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => roleService.LeaveUser("123", "123"));
        }

        [Test]
        public void LeaveUser_NullArgument_Exception()
        {
            using var roleService = new RoleService(_mockRoleRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => roleService.LeaveUser("123", null));
        }

        [Test]
        public void GetAll_Success()
        {
            _mockRoleRepository.Setup(r => r.GetAll()).ReturnsAsync(_roles);
            using var roleService = new RoleService(_mockRoleRepository.Object, _mapper);
            Assert.That(roleService.GetAll().Result, Is.TypeOf(typeof(List<RoleListingModel>)));
        }

        [Test]
        public void GetAll_ReturnThreeObjects_Success()
        {
            _mockRoleRepository.Setup(r => r.GetAll()).ReturnsAsync(_roles);
            using var roleService = new RoleService(_mockRoleRepository.Object, _mapper);
            Assert.AreEqual(roleService.GetAll().Result.Count, 3);
        }

        [Test]
        public void GetAll_ReturnNull_Exception()
        {
            _mockRoleRepository.Setup(r => r.GetAll()).ReturnsAsync(() => null);
            using var roleService = new RoleService(_mockRoleRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => roleService.GetAll());
        }

        [Test]
        public void GetById_Success()
        {
            _mockRoleRepository.Setup(r => r.GetById(It.IsAny<string>())).ReturnsAsync(_role);
            using var roleService = new RoleService(_mockRoleRepository.Object, _mapper);
            Assert.That(roleService.GetById("12").Result, Is.TypeOf(typeof(RoleListingModel)));
        }

        [Test]
        public void GetById_GoodArgument_Exception()
        {
            _mockRoleRepository.Setup(r => r.GetById(It.IsAny<string>())).ReturnsAsync(() => null);
            using var roleService = new RoleService(_mockRoleRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => roleService.GetById("123"));
        }

        [Test]
        public void GetById_NullArgument_Exception()
        {
            using var roleService = new RoleService(_mockRoleRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => roleService.GetById(null));
        }
    }
}