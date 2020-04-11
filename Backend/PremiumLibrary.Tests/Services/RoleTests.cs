using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using PremiumLibrary.Exceptions;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Mapping;
using PremiumLibrary.Models.DataBaseModels;
using PremiumLibrary.Models.ViewModels.Role;
using PremiumLibrary.Models.ViewModels.User;
using PremiumLibrary.Services;

namespace PremiumLibrary.Tests.Services
{
    [TestFixture]
    public class RoleTests
    {
        private MapperConfiguration _mapperConfiguration;
        private Mapper _mapper;
        private Mock<IRoleRepository> _mockRoleRepository;
        private Mock<IUserRepository> _mockUserRepository;

        private Role _role;
        private List<Role> _roles;
        private User _user;
        private UserRole _userRole;

        [SetUp]
        public void Init()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
                cfg.AddProfiles(new List<Profile>
                {
                    new UserProfile(),
                    new RoleProfile()
                }));

            _mapper = new Mapper(_mapperConfiguration);

            _mockRoleRepository = new Mock<IRoleRepository>();
            _mockUserRepository = new Mock<IUserRepository>();

            _role = new Role
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User",
                Users = new List<UserRole>()
            };
            _user = new User
            {
                Id = Guid.NewGuid().ToString(),
                EmailAddress = "Some@Email.Address",
                Password = "SomePassword",
                UserName = "SomeUserName",
                Roles = new List<UserRole>()
            };
            _userRole = new UserRole
            {
                Id = Guid.NewGuid().ToString(),
                Role = _role,
                User = _user,
                RoleId = _role.Id,
                UserId = _user.Id
            };
            _roles = new List<Role>
            {
                new Role
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    Users = new List<UserRole>()
                },
                new Role
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    Users = new List<UserRole>()
                },
                new Role
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Moder",
                    Users = new List<UserRole>()
                }
            };
        }

        [Test]
        public void AddRole_GoodArgument_Success()
        {
            _mockRoleRepository.Setup(r => r.GetAll())
                .Returns(Task.FromResult(_roles));
            _mockRoleRepository.Setup(r => r.Add("SomeRoleName"))
                .Returns(Task.FromResult(new Role
            {
                Id = Guid.NewGuid().ToString(),
                Users = new List<UserRole>(),
                Name = "SomeRoleName"
            }));

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                var result = roleService.Create("SomeRoleName").Result;

                Assert.AreEqual(result, "SomeRoleName");
            }
        }

        [Test]
        public void AddRole_BadArgument_Exception()
        {
            _mockRoleRepository.Setup(r => r.GetAll())
                .Returns(Task.FromResult(_roles));

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.Create(_role.Name);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void AddRole_NullArgument_Exception()
        {
            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.Create(null);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void AddRole_GoodArgument_ReturnNull_Exception()
        {
            _mockRoleRepository.Setup(r => r.GetAll())
                .Returns(Task.FromResult(_roles));
            _mockRoleRepository.Setup(r => r.Add(It.IsAny<string>()))
                .Returns(() => null);

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.Create(It.IsAny<string>());
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void InviteUser_GoodArguments_Success()
        {
            _mockRoleRepository.Setup(s => s.GetById(_role.Id))
                .Returns(Task.FromResult(_role));
            _mockUserRepository.Setup(s => s.GetById(_user.Id))
                .Returns(Task.FromResult(_user));
            
            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                roleService.InviteUser(_user.Id, _role.Id);
                _mockRoleRepository.Verify(m => m.AddUserRole(It.IsAny<User>(), It.IsAny<Role>()), Times.Once);
            }
        }

        [Test]
        public void InviteUser_RoleGoodArgument_UserBadArgument_Exception()
        {
            _mockRoleRepository.Setup(s => s.GetById(_role.Id))
                .Returns(Task.FromResult(_role));
            _mockUserRepository.Setup(s => s.GetById(_user.Id))
                .Returns( () => null);

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.InviteUser(_user.Id, _role.Id);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void InviteUser_RoleGoodArgument_UserNullArgument_Exception()
        {
            _mockRoleRepository.Setup(s => s.GetById(_role.Id))
                .Returns(Task.FromResult(_role));
            _mockUserRepository.Setup(s => s.GetById(null))
                .Returns(() => null);

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.InviteUser(null, _role.Id);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void InviteUser_RoleBadArgument_UserGoodArgument_Exception()
        {
            _mockRoleRepository.Setup(s => s.GetById(_role.Id))
                .Returns(() => null);
            _mockUserRepository.Setup(s => s.GetById(_user.Id))
                .Returns(Task.FromResult(_user));

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.InviteUser(_user.Id, _role.Id);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void InviteUser_RoleNullArgument_UserGoodArgument_Exception()
        {
            _mockRoleRepository.Setup(s => s.GetById(null))
                .Returns(() => null);
            _mockUserRepository.Setup(s => s.GetById(_user.Id))
                .Returns(Task.FromResult(_user));

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.InviteUser(_user.Id, null);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void InviteUser_RoleBadArgument_UserBadArgument_Exception()
        {
            _mockRoleRepository.Setup(s => s.GetById(_role.Id))
                .Returns(() => null);
            _mockUserRepository.Setup(s => s.GetById(_user.Id))
                .Returns(() => null);

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.InviteUser(_user.Id, _role.Id);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void InviteUser_RoleNullArgument_UserBadArgument_Exception()
        {
            _mockRoleRepository.Setup(s => s.GetById(null))
                .Returns(() => null);
            _mockUserRepository.Setup(s => s.GetById(_user.Id))
                .Returns(() => null);

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.InviteUser(_user.Id, null);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void InviteUser_RoleBadArgument_UserNullArgument_Exception()
        {
            _mockRoleRepository.Setup(s => s.GetById(_role.Id))
                .Returns(() => null);
            _mockUserRepository.Setup(s => s.GetById(null))
                .Returns(() => null);

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.InviteUser(null, _role.Id);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void InviteUser_RoleNullArgument_UserNullArgument_Exception()
        {
            _mockRoleRepository.Setup(s => s.GetById(null))
                .Returns(() => null);
            _mockUserRepository.Setup(s => s.GetById(null))
                .Returns(() => null);

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.InviteUser(null, null);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void InviteUser_RoleGoodArgument_UserGoodArgument_Exception()
        {
            _user.Roles.Add(_userRole);
            _mockRoleRepository.Setup(s => s.GetById(_role.Id))
                .Returns(Task.FromResult(_role));
            _mockUserRepository.Setup(s => s.GetById(_user.Id))
                .Returns(Task.FromResult(_user));


            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.InviteUser(_user.Id, _role.Id);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void LeaveUser_GoodArguments_Success()
        {
            _user.Roles.Add(_userRole);
            _role.Users.Add(_userRole);
            _mockRoleRepository.Setup(s => s.GetById(_role.Id))
                .Returns(Task.FromResult(_role));
            _mockUserRepository.Setup(s => s.GetById(_user.Id))
                .Returns(Task.FromResult(_user));

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                roleService.LeaveUser(_user.Id, _role.Id);
                _mockRoleRepository.Verify(m => m.DeleteUserRole(_userRole), Times.Once);
            }
        }

        [Test]
        public void LeaveUser_RoleGoodArgument_UserBadArgument_Exception()
        {
            _mockRoleRepository.Setup(s => s.GetById(_role.Id))
                .Returns(Task.FromResult(_role));
            _mockUserRepository.Setup(s => s.GetById(_user.Id))
                .Returns(() => null);

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.LeaveUser(_user.Id, _role.Id);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void LeaveUser_RoleGoodArgument_UserNullArgument_Exception()
        {
            _mockRoleRepository.Setup(s => s.GetById(_role.Id))
                .Returns(Task.FromResult(_role));
            _mockUserRepository.Setup(s => s.GetById(null))
                .Returns(() => null);

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.LeaveUser(null, _role.Id);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void LeaveUser_RoleBadArgument_UserGoodArgument_Exception()
        {
            _mockRoleRepository.Setup(s => s.GetById(_role.Id))
                .Returns(() => null);
            _mockUserRepository.Setup(s => s.GetById(_user.Id))
                .Returns(Task.FromResult(_user));

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.LeaveUser(_user.Id, _role.Id);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void LeaveUser_RoleNullArgument_UserGoodArgument_Exception()
        {
            _mockRoleRepository.Setup(s => s.GetById(null))
                .Returns(() => null);
            _mockUserRepository.Setup(s => s.GetById(_user.Id))
                .Returns(Task.FromResult(_user));

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.LeaveUser(_user.Id, null);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void LeaveUser_RoleBadArgument_UserBadArgument_Exception()
        {
            _mockRoleRepository.Setup(s => s.GetById(_role.Id))
                .Returns(() => null);
            _mockUserRepository.Setup(s => s.GetById(_user.Id))
                .Returns(() => null);

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.LeaveUser(_user.Id, _role.Id);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void LeaveUser_RoleNullArgument_UserBadArgument_Exception()
        {
            _mockRoleRepository.Setup(s => s.GetById(null))
                .Returns(() => null);
            _mockUserRepository.Setup(s => s.GetById(_user.Id))
                .Returns(() => null);

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.LeaveUser(_user.Id, null);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void LeaveUser_RoleBadArgument_UserNullArgument_Exception()
        {
            _mockRoleRepository.Setup(s => s.GetById(_role.Id))
                .Returns(() => null);
            _mockUserRepository.Setup(s => s.GetById(null))
                .Returns(() => null);

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.LeaveUser(null, _role.Id);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void LeaveUser_RoleNullArgument_UserNullArgument_Exception()
        {
            _mockRoleRepository.Setup(s => s.GetById(null))
                .Returns(() => null);
            _mockUserRepository.Setup(s => s.GetById(null))
                .Returns(() => null);

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.LeaveUser(null, null);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void LeaveUser_RoleGoodArgument_UserGoodArgument_Exception()
        {
            _mockRoleRepository.Setup(s => s.GetById(_role.Id))
                .Returns(Task.FromResult(_role));
            _mockUserRepository.Setup(s => s.GetById(_user.Id))
                .Returns(Task.FromResult(_user));

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.LeaveUser(_user.Id, _role.Id);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void GetUsersByRole_GoodArgument_Success()
        {
            _role.Users.Add(_userRole);
            _role.Users.Add(_userRole);

            _mockRoleRepository.Setup(w => w.GetById(_role.Id))
                .Returns(Task.FromResult(_role));

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                var result = roleService.GetUsersByRole(_role.Id).Result;

                Assert.That(result, Is.TypeOf(typeof(List<UserListingModel>)));
            }
        }

        [Test]
        public void GetUsersByRole_GoodArgument_ReturnNull_Exception()
        {
            _mockRoleRepository.Setup(w => w.GetById(_role.Id))
                .Returns(Task.FromResult(_role));

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.GetUsersByRole(_role.Id);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void GetUsersByRole_BadArgument_Exception()
        {
            _mockRoleRepository.Setup(w => w.GetById(_role.Id))
                .Returns(() => null);

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.GetUsersByRole(_role.Id);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void GetUsersByRole_NullArgument_Exception()
        {
            _mockRoleRepository.Setup(w => w.GetById(null))
                .Returns(() => null);

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.GetUsersByRole(null);
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void GetAll_Success()
        {
            _mockRoleRepository.Setup(w => w.GetAll())
                .Returns(Task.FromResult(_roles));

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                var result = roleService.GetAll().Result;
                Assert.That(result, Is.TypeOf(typeof(List<RoleListingModel>)));
            }
        }

        [Test]
        public void GetAll_Exception()
        {
            _mockRoleRepository.Setup(w => w.GetAll())
                .Returns(() => null);

            using (var roleService = new RoleService(_mockRoleRepository.Object, _mapper, _mockUserRepository.Object))
            {
                try
                {
                    roleService.GetAll();
                }
                catch (CustomException)
                {
                    Assert.True(true);
                }
            }
        }

    }
}