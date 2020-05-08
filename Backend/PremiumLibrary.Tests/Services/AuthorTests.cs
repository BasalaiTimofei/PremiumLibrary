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
using PremiumLibrary.Models.ViewModels.Author;
using PremiumLibrary.Services;

namespace PremiumLibrary.Tests.Services
{
    [TestFixture]
    class AuthorTests
    {
        private MapperConfiguration _mapperConfiguration;
        private Mapper _mapper;
        private Mock<IAuthorRepository> _mockAuthorRepository;

        private Author _author;
        private List<Author> _authors;

        [SetUp]
        public void Init()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
                cfg.AddProfiles(new List<Profile>
                {
                    new AuthorProfile()
                }));
            _mapper = new Mapper(_mapperConfiguration);
            _mockAuthorRepository = new Mock<IAuthorRepository>();
            _author = new Author
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "SomeAuthorFirstName",
                SecondName = "SomeAuthorSecondName",
                ImageUrl = "SomeImageUrl",
                AuthorBooks = new List<AuthorBook>(),
                AuthorLikes = new List<AuthorLike>(),
                AuthorComments = new List<AuthorComment>()
            };
            _authors = new List<Author>
            {
                _author, _author, _author
            };
        }

        [Test]
        public void GetAll_Success()
        {
            _mockAuthorRepository.Setup(w => w.GetAll()).ReturnsAsync(_authors);
            _mockAuthorRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_author);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.That(authorService.GetAll(It.IsAny<string>()).Result, Is.TypeOf(typeof(List<AuthorListingModel>)));
        }

        [Test]
        public void GetAll_ReturnThreeObjects_Success()
        {
            _mockAuthorRepository.Setup(w => w.GetAll()).ReturnsAsync(_authors);
            _mockAuthorRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_author);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.AreEqual(authorService.GetAll(It.IsAny<string>()).Result.Count, 3);
        }

        [Test]
        public void GetAll_ReturnNull_Exception()
        {
            _mockAuthorRepository.Setup(w => w.GetAll()).ReturnsAsync(() => null);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => authorService.GetAll(It.IsAny<string>()));
        }

        [Test]
        public void GetByBook_GoodArgument_Success()
        {
            _authors.Add(new Author
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "SomeAuthorFirstName",
                SecondName = "SomeAuthorSecondName",
                ImageUrl = "SomeImageUrl",
                AuthorBooks = new List<AuthorBook>
                {
                    new AuthorBook
                    {
                        Id = Guid.NewGuid().ToString(),
                        AuthorId = Guid.NewGuid().ToString(),
                        BookId = "123",
                        Book = new Book(),
                        Author = new Author()
                    }
                },
                AuthorLikes = new List<AuthorLike>(),
                AuthorComments = new List<AuthorComment>()

            });
            _mockAuthorRepository.Setup(w => w.GetAll()).ReturnsAsync(_authors);
            _mockAuthorRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_author);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.That(authorService.GetByBook("123", It.IsAny<string>()).Result, Is.TypeOf(typeof(List<AuthorListingModel>)));
        }

        [Test]
        public void GetByBook_GoodArgument_ReturnTwoObject_Success()
        {
            _authors.Add(new Author
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "SomeAuthorFirstName",
                SecondName = "SomeAuthorSecondName",
                ImageUrl = "SomeImageUrl",
                AuthorBooks = new List<AuthorBook>
                {
                    new AuthorBook
                    {
                        Id = Guid.NewGuid().ToString(),
                        AuthorId = Guid.NewGuid().ToString(),
                        BookId = "123",
                        Book = new Book(),
                        Author = new Author()
                    }
                },
                AuthorLikes = new List<AuthorLike>(),
                AuthorComments = new List<AuthorComment>()

            });
            _authors.Add(new Author
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "SomeAuthorFirstName",
                SecondName = "SomeAuthorSecondName",
                ImageUrl = "SomeImageUrl",
                AuthorBooks = new List<AuthorBook>
                {
                    new AuthorBook
                    {
                        Id = Guid.NewGuid().ToString(),
                        AuthorId = Guid.NewGuid().ToString(),
                        BookId = "123",
                        Book = new Book(),
                        Author = new Author()
                    }
                },
                AuthorLikes = new List<AuthorLike>(),
                AuthorComments = new List<AuthorComment>()

            });
            _mockAuthorRepository.Setup(w => w.GetAll()).ReturnsAsync(_authors);
            _mockAuthorRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_author);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.AreEqual(authorService.GetByBook("123", It.IsAny<string>()).Result.Count, 2);
        }

        [Test]
        public void GetByBook_GoodArgument_ReturnNull_Exception()
        {
            _mockAuthorRepository.Setup(w => w.GetAll()).ReturnsAsync(() => null);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => authorService.GetByBook("123", It.IsAny<string>()));
        }

        [Test]
        public void GetByBook_BadArgument_ReturnNull_Exception()
        {
            _mockAuthorRepository.Setup(w => w.GetAll()).ReturnsAsync(_authors);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => authorService.GetByBook("123", It.IsAny<string>()));
        }

        [Test]
        public void GetByBook_NullArgument_Exception()
        {
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => authorService.GetByBook(null, It.IsAny<string>()));
        }

        [Test]
        public void GetByLike_GoodArgument_Success()
        {
            _authors.Add(new Author
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "SomeAuthorFirstName",
                SecondName = "SomeAuthorSecondName",
                ImageUrl = "SomeImageUrl",
                AuthorBooks = new List<AuthorBook>
                {
                    new AuthorBook
                    {
                        Id = Guid.NewGuid().ToString(),
                        AuthorId = Guid.NewGuid().ToString(),
                        BookId = "123",
                        Book = new Book(),
                        Author = new Author()
                    }
                },
                AuthorLikes = new List<AuthorLike>
                {
                    new AuthorLike
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserId = "123",
                        User = new User(),
                        Author = new Author(),
                        AuthorId = Guid.NewGuid().ToString()
                    }
                },
                AuthorComments = new List<AuthorComment>()
            });
            _mockAuthorRepository.Setup(w => w.GetAll()).ReturnsAsync(_authors);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.That(authorService.GetByLike("123").Result, Is.TypeOf(typeof(List<AuthorListingModel>)));
        }

        [Test]
        public void GetByLike_GoodArgument_ReturnTwoObject_Success()
        {
            _authors.Add(new Author
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "SomeAuthorFirstName",
                SecondName = "SomeAuthorSecondName",
                ImageUrl = "SomeImageUrl",
                AuthorBooks = new List<AuthorBook>
                {
                    new AuthorBook
                    {
                        Id = Guid.NewGuid().ToString(),
                        AuthorId = Guid.NewGuid().ToString(),
                        BookId = "123",
                        Book = new Book(),
                        Author = new Author()
                    }
                },
                AuthorLikes = new List<AuthorLike>
                {
                    new AuthorLike
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserId = "123",
                        User = new User(),
                        Author = new Author(),
                        AuthorId = Guid.NewGuid().ToString()
                    }
                },
                AuthorComments = new List<AuthorComment>()
            });
            _authors.Add(new Author
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "SomeAuthorFirstName",
                SecondName = "SomeAuthorSecondName",
                ImageUrl = "SomeImageUrl",
                AuthorBooks = new List<AuthorBook>
                {
                    new AuthorBook
                    {
                        Id = Guid.NewGuid().ToString(),
                        AuthorId = Guid.NewGuid().ToString(),
                        BookId = "123",
                        Book = new Book(),
                        Author = new Author()
                    }
                },
                AuthorLikes = new List<AuthorLike>
                {
                    new AuthorLike
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserId = "123",
                        User = new User(),
                        Author = new Author(),
                        AuthorId = Guid.NewGuid().ToString()
                    }
                },
                AuthorComments = new List<AuthorComment>()
            });
            _mockAuthorRepository.Setup(w => w.GetAll()).ReturnsAsync(_authors);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.AreEqual(authorService.GetByLike("123").Result.Count, 2);
        }

        [Test]
        public void GetByLike_GoodArgument_ReturnNull_Exception()
        {
            _mockAuthorRepository.Setup(w => w.GetAll()).ReturnsAsync(() => null);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => authorService.GetByLike("123"));
        }

        [Test]
        public void GetByLike_BadArgument_ReturnNull_Exception()
        {
            _mockAuthorRepository.Setup(w => w.GetAll()).ReturnsAsync(_authors);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => authorService.GetByLike("123"));
        }

        [Test]
        public void GetByLike_NullArgument_Exception()
        {
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => authorService.GetByLike(null));
        }

        [Test]
        public void GetById_GoodArgument_Success()
        {
            _mockAuthorRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_author);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.That(authorService.GetById("123", It.IsAny<string>()).Result, Is.TypeOf(typeof(AuthorListingModel)));
        }

        [Test]
        public void GetById_BadArgument_ReturnNull_Exception()
        {
            _mockAuthorRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(() => null);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => authorService.GetById("123", It.IsAny<string>()));
        }

        [Test]
        public void GetById_NullArgument_Exception()
        {
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => authorService.GetById(null, It.IsAny<string>()));
        }

        [Test]
        public void GetByName_GoodArgument_Success()
        {
            _authors.Add(new Author
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "FirstName",
                SecondName = "SecondName",
                ImageUrl = "SomeImageUrl",
                AuthorBooks = new List<AuthorBook>(),
                AuthorLikes = new List<AuthorLike>(),
                AuthorComments = new List<AuthorComment>()
            });
            _mockAuthorRepository.Setup(w => w.GetAll()).ReturnsAsync(_authors);
            _mockAuthorRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_author);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.That(authorService.GetByName("FirstName SecondName", It.IsAny<string>()).Result, Is.TypeOf(typeof(AuthorListingModel)));
        }

        [Test]
        public void GetByName_GoodArgument_ReturnNull_Exception()
        {
            _mockAuthorRepository.Setup(w => w.GetAll()).ReturnsAsync(() => null);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => authorService.GetByName("123", It.IsAny<string>()));
        }

        [Test]
        public void GetByName_BadArgument_Exception()
        {
            _mockAuthorRepository.Setup(w => w.GetAll()).ReturnsAsync(_authors);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => authorService.GetByName("123", It.IsAny<string>()));
        }

        [Test]
        public void GetByName_NullArgument_Exception()
        {
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => authorService.GetByName(null, It.IsAny<string>()));
        }

        [Test]
        public void Create_GoodArgument_Success()
        {
            var authorCreateModel = new AuthorCreateModel
            {
                FirstName = "FirstName",
                SecondName = "SecondName",
                ImageUrl = "ImageUrl",
                BooksId = new List<string>()
            };
            _mockAuthorRepository.Setup(w => w.GetAll()).ReturnsAsync(_authors);
            _mockAuthorRepository.Setup(w => w.Add(It.IsAny<Author>())).ReturnsAsync(_author);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            var create = authorService.Create(authorCreateModel);
            _mockAuthorRepository.Verify(w => w.Add(It.IsAny<Author>()), Times.Once);
        }

        [Test]
        public void Create_GoodArgument_ReturnNull1_Exception()
        {
            var authorCreateModel = new AuthorCreateModel
            {
                FirstName = "FirstName",
                SecondName = "SecondName",
                ImageUrl = "ImageUrl",
                BooksId = new List<string>()
            };
            _mockAuthorRepository.Setup(w => w.GetAll()).ReturnsAsync(() => null);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => authorService.Create(authorCreateModel));
        }

        [Test]
        public void Create_GoodArgument_ReturnNull2_Exception()
        {
            var authorCreateModel = new AuthorCreateModel
            {
                FirstName = "FirstName",
                SecondName = "SecondName",
                ImageUrl = "ImageUrl",
                BooksId = new List<string>()
            };
            _mockAuthorRepository.Setup(w => w.GetAll()).ReturnsAsync(_authors);
            _mockAuthorRepository.Setup(w => w.Add(It.IsAny<Author>())).ReturnsAsync(() => null);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => authorService.Create(authorCreateModel));
        }

        [Test]
        public void Create_BadArgument_Exception()
        {
            var authorCreateModel = new AuthorCreateModel
            {
                FirstName = "SomeAuthorFirstName",
                SecondName = "SomeAuthorSecondName",
                ImageUrl = "ImageUrl",
                BooksId = new List<string>()
            };
            _mockAuthorRepository.Setup(w => w.GetAll()).ReturnsAsync(_authors);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => authorService.Create(authorCreateModel));
        }

        [Test]
        public void Create_NullArgument_Exception()
        {
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => authorService.Create(null));
        }

        [Test]
        public void Delete_GoodArgument_Success()
        {
            _mockAuthorRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_author);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            var delete = authorService.Delete("123");   
            _mockAuthorRepository.Verify(w => w.Delete(It.IsAny<Author>()), Times.Once);
        }

        [Test]
        public void Delete_BadArgument_ReturnNull_Exception()
        {
            _mockAuthorRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(() => null);
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => authorService.Delete("123"));
        }

        [Test]
        public void Delete_NullArgument_Exception()
        {
            using var authorService = new AuthorService(_mockAuthorRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => authorService.Delete(null));
        }
    }
}