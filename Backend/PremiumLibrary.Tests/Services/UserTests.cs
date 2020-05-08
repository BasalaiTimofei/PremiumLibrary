using System;
using System.Collections.Generic;
using AutoMapper;
using Moq;
using NUnit.Framework;
using PremiumLibrary.Exceptions;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Mapping;
using PremiumLibrary.Models.DataBaseModels;
using PremiumLibrary.Models.DataBaseModels.AuthorFolder;
using PremiumLibrary.Models.DataBaseModels.BookFolder;
using PremiumLibrary.Models.DataBaseModels.GenreFolder;
using PremiumLibrary.Models.ViewModels.User;
using PremiumLibrary.Services;

namespace PremiumLibrary.Tests.Services
{
    [TestFixture]
    class UserTests
    {
        private MapperConfiguration _mapperConfiguration;
        private Mapper _mapper;
        private Mock<IUserRepository> _mockUserRepository;

        private User _user;
        private List<User> _users;

        [SetUp]
        public void Init()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
                cfg.AddProfiles(new List<Profile>
                {
                    new UserProfile()
                }));
            _mapper = new Mapper(_mapperConfiguration);
            _mockUserRepository = new Mock<IUserRepository>();
            _user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Roles = new List<UserRole>(),
                ImageUrl = "SomeImageUrl",
                UserName = "SomeUserName",
                AuthorLikes = new List<AuthorLike>(),
                AuthorComments = new List<AuthorComment>(),
                BookComments = new List<BookComment>(),
                BookCommentLikes = new List<BookCommentLike>(),
                EmailAddress = "SomeEmailAddress",
                AuthorCommentLikes = new List<AuthorCommentLike>(),
                GenreLikes = new List<GenreLike>(),
                BookLikes = new List<BookLike>(),
                BookProcesses = new List<BookProcess>(),
                Password = "SomePassword",
                BookAssessments = new List<BookAssessment>()
            };
            _users = new List<User>
            {
                _user, _user, _user
            };
        }

        [Test]
        public void GetAll_Success()
        {
            _mockUserRepository.Setup(w => w.GetAll()).ReturnsAsync(_users);
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.That(userService.GetAll().Result, Is.TypeOf(typeof(List<UserListingModel>)));
        }

        [Test]
        public void GetAll_ReturnThreeObjects_Success()
        {
            _mockUserRepository.Setup(w => w.GetAll()).ReturnsAsync(_users);
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.AreEqual(userService.GetAll().Result.Count, 3);
        }

        [Test]
        public void GetAll_ReturnNull_Exception()
        {
            _mockUserRepository.Setup(w => w.GetAll()).ReturnsAsync(() => null);
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => userService.GetAll());
        }

        [Test]
        public void GetByRole_GoodArgument_Success()
        {
            _users.Add(new User
            {
                Id = Guid.NewGuid().ToString(),
                Roles = new List<UserRole>
                {
                    new UserRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        User = new User(),
                        Role = new Role(),
                        UserId = Guid.NewGuid().ToString(),
                        RoleId = "123"
                    }
                },
                ImageUrl = "SomeImageUrl",
                UserName = "SomeUserName",
                AuthorLikes = new List<AuthorLike>(),
                AuthorComments = new List<AuthorComment>(),
                BookComments = new List<BookComment>(),
                BookCommentLikes = new List<BookCommentLike>(),
                EmailAddress = "SomeEmailAddress",
                AuthorCommentLikes = new List<AuthorCommentLike>(),
                GenreLikes = new List<GenreLike>(),
                BookLikes = new List<BookLike>(),
                BookProcesses = new List<BookProcess>(),
                Password = "SomePassword",
                BookAssessments = new List<BookAssessment>()
            });
            _mockUserRepository.Setup(w => w.GetAll()).ReturnsAsync(_users);
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.That(userService.GetByRole("123").Result, Is.TypeOf(typeof(List<UserListingModel>)));
        }

        [Test]
        public void GetByRole_GoodArgument_ReturnTwoObject_Success()
        {
            _users.Add(new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Roles = new List<UserRole>
                    {
                        new UserRole
                        {
                            Id = Guid.NewGuid().ToString(),
                            User = new User(),
                            Role = new Role(),
                            UserId = Guid.NewGuid().ToString(),
                            RoleId = "123"
                        }
                    },
                    ImageUrl = "SomeImageUrl",
                    UserName = "SomeUserName",
                    AuthorLikes = new List<AuthorLike>(),
                    AuthorComments = new List<AuthorComment>(),
                    BookComments = new List<BookComment>(),
                    BookCommentLikes = new List<BookCommentLike>(),
                    EmailAddress = "SomeEmailAddress",
                    AuthorCommentLikes = new List<AuthorCommentLike>(),
                    GenreLikes = new List<GenreLike>(),
                    BookLikes = new List<BookLike>(),
                    BookProcesses = new List<BookProcess>(),
                    Password = "SomePassword",
                    BookAssessments = new List<BookAssessment>()
                });
            _users.Add(new User
            {
                Id = Guid.NewGuid().ToString(),
                Roles = new List<UserRole>
                {
                    new UserRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        User = new User(),
                        Role = new Role(),
                        UserId = Guid.NewGuid().ToString(),
                        RoleId = "123"
                    }
                },
                ImageUrl = "SomeImageUrl",
                UserName = "SomeUserName",
                AuthorLikes = new List<AuthorLike>(),
                AuthorComments = new List<AuthorComment>(),
                BookComments = new List<BookComment>(),
                BookCommentLikes = new List<BookCommentLike>(),
                EmailAddress = "SomeEmailAddress",
                AuthorCommentLikes = new List<AuthorCommentLike>(),
                GenreLikes = new List<GenreLike>(),
                BookLikes = new List<BookLike>(),
                BookProcesses = new List<BookProcess>(),
                Password = "SomePassword",
                BookAssessments = new List<BookAssessment>()
            });
            _mockUserRepository.Setup(w => w.GetAll()).ReturnsAsync(_users);
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.That(userService.GetByRole("123").Result, Is.TypeOf(typeof(List<UserListingModel>)));

        }

        [Test]
        public void GetByRole_GoodArgument_ReturnNull_Exception()
        {
            _mockUserRepository.Setup(w => w.GetAll()).ReturnsAsync(() => null);
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => userService.GetByRole("123"));
        }

        [Test]
        public void GetByRole_BadArgument_Exception()
        {
            _mockUserRepository.Setup(w => w.GetAll()).ReturnsAsync(_users);
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => userService.GetByRole("123"));
        }

        [Test]
        public void GetByRole_NullArgument_Exception()
        {
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => userService.GetByRole(null));
        }

        [Test]
        public void GetById_GoodArgument_Success()
        {
            _mockUserRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_user);
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.That(userService.GetById("123").Result, Is.TypeOf(typeof(UserListingModel)));
        }

        [Test]
        public void GetById_BadArgument_ReturnNull_Exception()
        {
            _mockUserRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(() => null);
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => userService.GetById("123"));
        }

        [Test]
        public void GetById_NullArgument_Exception()
        {
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => userService.GetById(null));
        }

        [Test]
        public void IsOnDb_GoodArgument_ReturnTrue_Success()
        {
            _mockUserRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_user);
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.IsTrue(userService.IsOnDb("123").Result);
        }

        [Test]
        public void IsOnDb_GoodArgument_ReturnFalse_Success()
        {
            _mockUserRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(() => null);
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.IsTrue(!userService.IsOnDb("123").Result);

        }

        [Test]
        public void IsOnDb_BadArgument_ReturnFalse()
        {
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.IsTrue(!userService.IsOnDb(null).Result);
        }

        [Test]
        public void Registration_GoodArgument_Success()
        {
            var userRegistrationModel = new Registration
            {
                ImageUrl = "SomeImageUrl",
                UserName = "123",
                Password = "123",
                EmailAddress = "123"
            };
            _mockUserRepository.Setup(w => w.GetAll()).ReturnsAsync(_users);
            _mockUserRepository.Setup(w => w.Add(It.IsAny<User>())).ReturnsAsync(_user);
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            var registration = userService.Registration(userRegistrationModel);
            _mockUserRepository.Verify(w => w.Add(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public void Registration_GoodArgument_ReturnNull1_Exception()
        {
            var userRegistrationModel = new Registration
            {
                ImageUrl = "SomeImageUrl",
                UserName = "123",
                Password = "123",
                EmailAddress = "123"
            };
            _mockUserRepository.Setup(w => w.GetAll()).ReturnsAsync(() => null);
            _mockUserRepository.Setup(w => w.Add(It.IsAny<User>())).ReturnsAsync(_user);
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => userService.Registration(userRegistrationModel));
        }

        [Test]
        public void Registration_GoodArgument_ReturnNull2_Exception()
        {
            var userRegistrationModel = new Registration
            {
                ImageUrl = "SomeImageUrl",
                UserName = "123",
                Password = "123",
                EmailAddress = "123"
            };
            _mockUserRepository.Setup(w => w.GetAll()).ReturnsAsync(_users);
            _mockUserRepository.Setup(w => w.Add(It.IsAny<User>())).ReturnsAsync(() => null);
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => userService.Registration(userRegistrationModel));
        }

        [Test]
        public void Registration_BadArgument_Exception()
        {
            var userRegistrationModel = new Registration
            {
                ImageUrl = "SomeImageUrl",
                UserName = "123",
                Password = "123",
                EmailAddress = "SomeEmailAddress"
            };
            _mockUserRepository.Setup(w => w.GetAll()).ReturnsAsync(_users);
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => userService.Registration(userRegistrationModel));
        }

        [Test]
        public void Registration_NullArgument_Exception()
        {
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => userService.Registration(null));
        }

        [Test]
        public void Authorization_GoodArgument_Success()
        {
            _users.Add(new User
            {
                Id = "123",
                Roles = new List<UserRole>(),
                ImageUrl = "SomeImageUrl",
                UserName = "123",
                AuthorLikes = new List<AuthorLike>(),
                AuthorComments = new List<AuthorComment>(),
                BookComments = new List<BookComment>(),
                BookCommentLikes = new List<BookCommentLike>(),
                EmailAddress = "123",
                AuthorCommentLikes = new List<AuthorCommentLike>(),
                GenreLikes = new List<GenreLike>(),
                BookLikes = new List<BookLike>(),
                BookProcesses = new List<BookProcess>(),
                Password = "123",
                BookAssessments = new List<BookAssessment>()
            });
            var userAuthorizationModel = new Authorization
            {
                Password = "123",
                UserNameOrEmailAddress = "123"
            };
            _mockUserRepository.Setup(w => w.GetAll()).ReturnsAsync(_users);
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.AreEqual(userService.Authorization(userAuthorizationModel).Result, "123");
        }

        [Test]
        public void Authorization_GoodArgument_ReturnNull_Exception()
        {
            var userAuthorizationModel = new Authorization
            {
                Password = "123",
                UserNameOrEmailAddress = "123"
            };
            _mockUserRepository.Setup(w => w.GetAll()).ReturnsAsync(() => null);
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => userService.Authorization(userAuthorizationModel));
        }

        [Test]
        public void Authorization_BadArgument_NameEmail_Exception()
        {
            _users.Add(new User
            {
                Id = "123",
                Roles = new List<UserRole>(),
                ImageUrl = "SomeImageUrl",
                UserName = "13",
                AuthorLikes = new List<AuthorLike>(),
                AuthorComments = new List<AuthorComment>(),
                BookComments = new List<BookComment>(),
                BookCommentLikes = new List<BookCommentLike>(),
                EmailAddress = "SomeEmailAddress",
                AuthorCommentLikes = new List<AuthorCommentLike>(),
                GenreLikes = new List<GenreLike>(),
                BookLikes = new List<BookLike>(),
                BookProcesses = new List<BookProcess>(),
                Password = "123",
                BookAssessments = new List<BookAssessment>()
            });
            var userAuthorizationModel = new Authorization
            {
                Password = "123",
                UserNameOrEmailAddress = "123"
            };
            _mockUserRepository.Setup(w => w.GetAll()).ReturnsAsync(_users);
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => userService.Authorization(userAuthorizationModel));
        }

        [Test]
        public void Authorization_BadArgument_Password_Exception()
        {
            _users.Add(new User
            {
                Id = "123",
                Roles = new List<UserRole>(),
                ImageUrl = "SomeImageUrl",
                UserName = "123",
                AuthorLikes = new List<AuthorLike>(),
                AuthorComments = new List<AuthorComment>(),
                BookComments = new List<BookComment>(),
                BookCommentLikes = new List<BookCommentLike>(),
                EmailAddress = "SomeEmailAddress",
                AuthorCommentLikes = new List<AuthorCommentLike>(),
                GenreLikes = new List<GenreLike>(),
                BookLikes = new List<BookLike>(),
                BookProcesses = new List<BookProcess>(),
                Password = "12",
                BookAssessments = new List<BookAssessment>()
            });
            var userAuthorizationModel = new Authorization
            {
                Password = "123",
                UserNameOrEmailAddress = "123"
            };
            _mockUserRepository.Setup(w => w.GetAll()).ReturnsAsync(_users);
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => userService.Authorization(userAuthorizationModel));
        }

        [Test]
        public void Authorization_NullArgument_Exception()
        {
            using var userService = new UserService(_mockUserRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => userService.Authorization(null));
        }
    }
}