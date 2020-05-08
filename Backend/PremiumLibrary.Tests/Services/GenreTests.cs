using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Moq;
using NUnit.Framework;
using PremiumLibrary.Exceptions;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Mapping;
using PremiumLibrary.Models.DataBaseModels;
using PremiumLibrary.Models.DataBaseModels.BookFolder;
using PremiumLibrary.Models.DataBaseModels.GenreFolder;
using PremiumLibrary.Models.ViewModels.Genre;
using PremiumLibrary.Services;

namespace PremiumLibrary.Tests.Services
{
    [TestFixture]
    class GenreTests
    {
        private MapperConfiguration _mapperConfiguration;
        private Mapper _mapper;
        private Mock<IGenreRepository> _mockGenreRepository;

        private Genre _genre;
        private List<Genre> _genres;

        [SetUp]
        public void Init()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
                cfg.AddProfiles(new List<Profile>
                {
                    new GenreProfile()
                }));
            _mapper = new Mapper(_mapperConfiguration);
            _mockGenreRepository = new Mock<IGenreRepository>();
            _genre = new Genre
            {
                Id = Guid.NewGuid().ToString(),
                ImageUrl = "SomeImageUrl",
                Name = "SomeGenreName",
                Books = new List<GenreBook>(),
                Likes = new List<GenreLike>()
            };
            _genres = new List<Genre>
            {
                _genre, _genre, _genre
            };
        }

        [Test]
        public void GetAll_Success()
        {
            _mockGenreRepository.Setup(w => w.GetAll()).ReturnsAsync(_genres);
            _mockGenreRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_genre);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.That(genreService.GetAll(It.IsAny<string>()).Result, Is.TypeOf(typeof(List<GenreListingModel>)));
        }

        [Test]
        public void GetAll_ReturnThreeObjects_Success()
        {
            _mockGenreRepository.Setup(w => w.GetAll()).ReturnsAsync(_genres);
            _mockGenreRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_genre);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.AreEqual(genreService.GetAll(It.IsAny<string>()).Result.Count, 3);
        }

        [Test]
        public void GetAll_ReturnNull_Exception()
        {
            _mockGenreRepository.Setup(w => w.GetAll()).ReturnsAsync(() => null);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => genreService.GetAll(It.IsAny<string>()));
        }

        [Test]
        public void GetByBook_GoodArgument_Success()
        {
            _genres.Add(new Genre
            {
                Id = Guid.NewGuid().ToString(),
                Name = "SomeGenreName",
                ImageUrl = "SomeImageUrl",
                Books = new List<GenreBook>
                {
                    new GenreBook
                    {
                        Book = new Book(),
                        Id = Guid.NewGuid().ToString(),
                        Genre = new Genre(),
                        BookId = "123",
                        GenreId = Guid.NewGuid().ToString()
                    }
                },
                Likes = new List<GenreLike>()
            });
            _mockGenreRepository.Setup(w => w.GetAll()).ReturnsAsync(_genres);
            _mockGenreRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_genre);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.That(genreService.GetByBook("123", It.IsAny<string>()).Result, Is.TypeOf(typeof(List<GenreListingModel>)));
        }

        [Test]
        public void GetByBook_GoodArgument_ReturnTwoObject_Success()
        {
            _genres.Add(new Genre
            {
                Id = Guid.NewGuid().ToString(),
                Name = "SomeGenreName",
                ImageUrl = "SomeImageUrl",
                Books = new List<GenreBook>
                {
                    new GenreBook
                    {
                        Book = new Book(),
                        Id = Guid.NewGuid().ToString(),
                        Genre = new Genre(),
                        BookId = "123",
                        GenreId = Guid.NewGuid().ToString()
                    }
                },
                Likes = new List<GenreLike>()
            });
            _genres.Add(new Genre
            {
                Id = Guid.NewGuid().ToString(),
                Name = "SomeGenreName",
                ImageUrl = "SomeImageUrl",
                Books = new List<GenreBook>
                {
                    new GenreBook
                    {
                        Book = new Book(),
                        Id = Guid.NewGuid().ToString(),
                        Genre = new Genre(),
                        BookId = "123",
                        GenreId = Guid.NewGuid().ToString()
                    }
                },
                Likes = new List<GenreLike>()
            });
            _mockGenreRepository.Setup(w => w.GetAll()).ReturnsAsync(_genres);
            _mockGenreRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_genre);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.AreEqual(genreService.GetByBook("123", It.IsAny<string>()).Result.Count, 2);
        }

        [Test]
        public void GetByBook_GoodArgument_ReturnNull_Exception()
        {
            _mockGenreRepository.Setup(w => w.GetAll()).ReturnsAsync(() => null);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => genreService.GetByBook("123", It.IsAny<string>()));
        }

        [Test]
        public void GetByBook_BadArgument_ReturnNull_Exception()
        {
            _mockGenreRepository.Setup(w => w.GetAll()).ReturnsAsync(_genres);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => genreService.GetByBook("123", It.IsAny<string>()));
        }

        [Test]
        public void GetByBook_NullArgument_Exception()
        {
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => genreService.GetByBook(null, It.IsAny<string>()));
        }

        [Test]
        public void GetByLike_GoodArgument_Success()
        {
            _genres.Add(new Genre
            {
                Id = Guid.NewGuid().ToString(),
                Name = "SomeGenreName",
                Books = new List<GenreBook>(),
                Likes = new List<GenreLike>
                {
                    new GenreLike
                    {
                        User = new User(),
                        Id = Guid.NewGuid().ToString(),
                        Genre = new Genre(),
                        UserId = "123",
                        GenreId = Guid.NewGuid().ToString()
                    }
                },
                ImageUrl = "SomeImageUrl"
            });
            _mockGenreRepository.Setup(w => w.GetAll()).ReturnsAsync(_genres);
            _mockGenreRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_genre);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.That(genreService.GetByLike("123").Result, Is.TypeOf(typeof(List<GenreListingModel>)));
        }

        [Test]
        public void GetByLike_GoodArgument_ReturnTwoObject_Success()
        {
            _genres.Add(new Genre
            {
                Id = Guid.NewGuid().ToString(),
                Name = "SomeGenreName",
                Books = new List<GenreBook>(),
                Likes = new List<GenreLike>
                {
                    new GenreLike
                    {
                        User = new User(),
                        Id = Guid.NewGuid().ToString(),
                        Genre = new Genre(),
                        UserId = "123",
                        GenreId = Guid.NewGuid().ToString()
                    }
                },
                ImageUrl = "SomeImageUrl"
            });
            _genres.Add(new Genre
            {
                Id = Guid.NewGuid().ToString(),
                Name = "SomeGenreName",
                Books = new List<GenreBook>(),
                Likes = new List<GenreLike>
                {
                    new GenreLike
                    {
                        User = new User(),
                        Id = Guid.NewGuid().ToString(),
                        Genre = new Genre(),
                        UserId = "123",
                        GenreId = Guid.NewGuid().ToString()
                    }
                },
                ImageUrl = "SomeImageUrl"
            });
            _mockGenreRepository.Setup(w => w.GetAll()).ReturnsAsync(_genres);
            _mockGenreRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_genre);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.AreEqual(genreService.GetByLike("123").Result.Count, 2);
        }

        [Test]
        public void GetByLike_GoodArgument_ReturnNull_Exception()
        {
            _mockGenreRepository.Setup(w => w.GetAll()).ReturnsAsync(() => null);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => genreService.GetByLike("123"));
        }

        [Test]
        public void GetByLike_BadArgument_ReturnNull_Exception()
        {
            _mockGenreRepository.Setup(w => w.GetAll()).ReturnsAsync(_genres);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => genreService.GetByLike("123"));
        }

        [Test]
        public void GetByLike_NullArgument_Exception()
        {
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => genreService.GetByLike(null));
        }

        [Test]
        public void GetById_GoodArgument_Success()
        {
            _mockGenreRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_genre);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.That(genreService.GetById("123", It.IsAny<string>()).Result, Is.TypeOf(typeof(GenreListingModel)));
        }

        [Test]
        public void GetById_BadArgument_ReturnNull_Exception()
        {
            _mockGenreRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(() => null);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => genreService.GetById("123", It.IsAny<string>()));
        }

        [Test]
        public void GetById_NullArgument_Exception()
        {
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => genreService.GetById(null, It.IsAny<string>()));
        }

        [Test]
        public void GetByName_GoodArgument_Success()
        {
            _genres.Add(new Genre
            {
                Id = Guid.NewGuid().ToString(),
                Books = new List<GenreBook>(),
                ImageUrl = "SomeImageUrl",
                Likes = new List<GenreLike>(),
                Name = "SomeGenreName1"
            });
            _mockGenreRepository.Setup(w => w.GetAll()).ReturnsAsync(_genres);
            _mockGenreRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_genre);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.That(genreService.GetByName("SomeGenreName1", It.IsAny<string>()).Result, Is.TypeOf(typeof(GenreListingModel)));
        }

        [Test]
        public void GetByName_GoodArgument_ReturnNull_Exception()
        {
            _mockGenreRepository.Setup(w => w.GetAll()).ReturnsAsync(() => null);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => genreService.GetByName("123", It.IsAny<string>()));
        }

        [Test]
        public void GetByName_BadArgument_Exception()
        {
            _mockGenreRepository.Setup(w => w.GetAll()).ReturnsAsync(() => null);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => genreService.GetByName("123", It.IsAny<string>()));
        }

        [Test]
        public void GetByName_NullArgument_Exception()
        {
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => genreService.GetByName(null, It.IsAny<string>()));
        }

        [Test]
        public void Create_GoodArgument_Success()
        {
            var genreCreateModel = new GenreCreateModel
            {
                Name = "Genre",
                Books = new List<string>(),
                ImageUrl = "SomeImageUrl"
            };
            _mockGenreRepository.Setup(w => w.GetAll()).ReturnsAsync(_genres);
            _mockGenreRepository.Setup(w => w.Add(It.IsAny<Genre>())).ReturnsAsync(_genre);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            var create = genreService.Create(genreCreateModel);
            _mockGenreRepository.Verify(w => w.Add(It.IsAny<Genre>()), Times.Once);
        }

        [Test]
        public void Create_GoodArgument_ReturnNull1_Exception()
        {
            var genreCreateModel = new GenreCreateModel
            {
                Name = "Genre",
                Books = new List<string>(),
                ImageUrl = "SomeImageUrl"
            };
            _mockGenreRepository.Setup(w => w.GetAll()).ReturnsAsync(() => null);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => genreService.Create(genreCreateModel));
        }

        [Test]
        public void Create_GoodArgument_ReturnNull2_Exception()
        {
            var genreCreateModel = new GenreCreateModel
            {
                Name = "Genre",
                Books = new List<string>(),
                ImageUrl = "SomeImageUrl"
            };
            _mockGenreRepository.Setup(w => w.GetAll()).ReturnsAsync(_genres);
            _mockGenreRepository.Setup(w => w.Add(It.IsAny<Genre>())).ReturnsAsync(() => null);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => genreService.Create(genreCreateModel));
        }

        [Test]
        public void Create_BadArgument_Exception()
        {
            var genreCreateModel = new GenreCreateModel
            {
                Name = "SomeGenreName",
                Books = new List<string>(),
                ImageUrl = "SomeImageUrl"
            };
            _mockGenreRepository.Setup(w => w.GetAll()).ReturnsAsync(_genres);
            _mockGenreRepository.Setup(w => w.Add(It.IsAny<Genre>())).ReturnsAsync(() => null);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => genreService.Create(genreCreateModel));
        }

        [Test]
        public void Create_NullArgument_Exception()
        {
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => genreService.Create(null));
        }

        [Test]
        public void Delete_GoodArgument_Success()
        {
            _mockGenreRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_genre);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            var delete = genreService.Delete("123");
            _mockGenreRepository.Verify(w => w.Delete(It.IsAny<Genre>()), Times.Once);
        }

        [Test]
        public void Delete_BadArgument_ReturnNull_Exception()
        {
            _mockGenreRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(() => null);
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => genreService.Delete("132"));
        }

        [Test]
        public void Delete_NullArgument_Exception()
        {
            using var genreService = new GenreService(_mockGenreRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => genreService.Delete(null));
        }
    }
}