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
using PremiumLibrary.Models.ViewModels.Book;
using PremiumLibrary.Services;

namespace PremiumLibrary.Tests.Services
{
    [TestFixture]
    class BookTests
    {
        private MapperConfiguration _mapperConfiguration;
        private Mapper _mapper;
        private Mock<IBookRepository> _mockBookRepository;

        private Book _book;
        private List<Book> _books;
        private Author _author;

        [SetUp]
        public void Init()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
                cfg.AddProfiles(new List<Profile>
                {
                    new BookProfile()
                }));
            _mapper = new Mapper(_mapperConfiguration);
            _mockBookRepository = new Mock<IBookRepository>();
            _book = new Book
            {
                Id = Guid.NewGuid().ToString(),
                Name = "SomeBookName",
                Year = 2020,
                BookUrl = "SomeBookUrl",
                ImageIrl = "SomeBookImageUrl",
                Description = "SomeBookDescription",
                Authors = new List<AuthorBook>(),
                Genres = new List<GenreBook>(),
                Likes = new List<BookLike>(),
                Assessments = new List<BookAssessment>(),
                Comments = new List<BookComment>(),
                Processes = new List<BookProcess>()
            };
            _books = new List<Book>
            {
                _book, _book, _book
            };
            _author = new Author
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "SomeFirstName",
                SecondName = "SomeSecondName",
                ImageUrl = "SomeImageUrl",
                AuthorBooks = new List<AuthorBook>(),
                AuthorComments = new List<AuthorComment>(),
                AuthorLikes = new List<AuthorLike>()
            };
        }

        [Test]
        public void GetAll_Success()
        {
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(_books);
            _mockBookRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_book);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.That(bookService.GetAll(It.IsAny<string>()).Result, Is.TypeOf(typeof(List<BookListingModel>)));
        }

        [Test]
        public void GetAll_ReturnThreeObjects_Success()
        {
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(_books);
            _mockBookRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_book);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.AreEqual(bookService.GetAll(It.IsAny<string>()).Result.Count, 3);
        }

        [Test]
        public void GetAll_ReturnNull_Exception()
        {
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(() => null);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => bookService.GetAll(It.IsAny<string>()));
        }

        [Test]
        public void GetByAuthor_GoodArgument_Success()
        {
            _books.Add(new Book
            {
                Id = Guid.NewGuid().ToString(),
                Name = "SomeBookName",
                Year = 2020,
                BookUrl = "SomeBookUrl",
                ImageIrl = "SomeBookImageUrl",
                Description = "SomeBookDescription",
                Authors = new List<AuthorBook>
                {
                    new AuthorBook
                    {
                        Id = "123",
                        Book = _book,
                        Author = _author,
                        BookId = _book.Id,
                        AuthorId = "321"
                    }
                },
                Genres = new List<GenreBook>(),
                Likes = new List<BookLike>(),
                Assessments = new List<BookAssessment>(),
                Comments = new List<BookComment>(),
                Processes = new List<BookProcess>()
            });
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(_books);
            _mockBookRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_book);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.That(bookService.GetByAuthor("321", It.IsAny<string>()).Result, Is.TypeOf(typeof(List<BookListingModel>)));
        }
        
        [Test]
        public void GetByAuthor_GoodArgument_ReturnTwoObject_Success()
        {
            _books.Add(new Book
            {
                Id = Guid.NewGuid().ToString(),
                Name = "SomeBookName",
                Year = 2020,
                BookUrl = "SomeBookUrl",
                ImageIrl = "SomeBookImageUrl",
                Description = "SomeBookDescription",
                Authors = new List<AuthorBook>
                {
                    new AuthorBook
                    {
                        Id = "123",
                        Book = _book,
                        Author = _author,
                        BookId = _book.Id,
                        AuthorId = "321"
                    }
                },
                Genres = new List<GenreBook>(),
                Likes = new List<BookLike>(),
                Assessments = new List<BookAssessment>(),
                Comments = new List<BookComment>(),
                Processes = new List<BookProcess>()
            });
            _books.Add(new Book
            {
                Id = Guid.NewGuid().ToString(),
                Name = "SomeBookName",
                Year = 2020,
                BookUrl = "SomeBookUrl",
                ImageIrl = "SomeBookImageUrl",
                Description = "SomeBookDescription",
                Authors = new List<AuthorBook>
                {
                    new AuthorBook
                    {
                        Id = "123",
                        Book = _book,
                        Author = _author,
                        BookId = _book.Id,
                        AuthorId = "321"
                    }
                },
                Genres = new List<GenreBook>(),
                Likes = new List<BookLike>(),
                Assessments = new List<BookAssessment>(),
                Comments = new List<BookComment>(),
                Processes = new List<BookProcess>()
            });
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(_books);
            _mockBookRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_book);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.AreEqual(bookService.GetByAuthor("321", It.IsAny<string>()).Result.Count, 2);
        }

        [Test]
        public void GetByAuthor_GoodArgument_ReturnNull_Exception()
        {
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(() => null);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => bookService.GetByAuthor("123", It.IsAny<string>()));
        }

        [Test]
        public void GetByAuthor_BadArgument_ReturnNull_Exception()
        {
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(_books);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => bookService.GetByAuthor("7", It.IsAny<string>()));
        }

        [Test]
        public void GetByAuthor_NullArgument_Exception()
        {
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(_books);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => bookService.GetByAuthor(null, It.IsAny<string>()));
        }

        [Test]
        public void GetByGenre_GoodArgument_Success()
        {
            _books.Add(new Book
            {
                Id = Guid.NewGuid().ToString(),
                Name = "SomeBookName",
                Year = 2020,
                BookUrl = "SomeBookUrl",
                ImageIrl = "SomeBookImageUrl",
                Description = "SomeBookDescription",
                Authors = new List<AuthorBook>
                {
                    new AuthorBook
                    {
                        Id = "123",
                        Book = _book,
                        Author = _author,
                        BookId = _book.Id,
                        AuthorId = "321"
                    }
                },
                Genres = new List<GenreBook>
                {
                    new GenreBook
                    {
                        Book = _book,
                        Id = "123",
                        BookId = _book.Id,
                        GenreId = "321",
                        Genre = new Genre()
                    }
                },
                Likes = new List<BookLike>(),
                Assessments = new List<BookAssessment>(),
                Comments = new List<BookComment>(),
                Processes = new List<BookProcess>()
            });
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(_books);
            _mockBookRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_book);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.That(bookService.GetByGenre("321", It.IsAny<string>()).Result, Is.TypeOf(typeof(List<BookListingModel>)));
        }

        [Test]
        public void GetByGenre_GoodArgument_ReturnTwoObject_Success()
        {
            _books.Add(new Book
            {
                Id = Guid.NewGuid().ToString(),
                Name = "SomeBookName",
                Year = 2020,
                BookUrl = "SomeBookUrl",
                ImageIrl = "SomeBookImageUrl",
                Description = "SomeBookDescription",
                Authors = new List<AuthorBook>
                {
                    new AuthorBook
                    {
                        Id = "123",
                        Book = _book,
                        Author = _author,
                        BookId = _book.Id,
                        AuthorId = "321"
                    }
                },
                Genres = new List<GenreBook>
                {
                    new GenreBook
                    {
                        Book = _book,
                        Id = "123",
                        BookId = _book.Id,
                        GenreId = "321",
                        Genre = new Genre()
                    }
                },
                Likes = new List<BookLike>(),
                Assessments = new List<BookAssessment>(),
                Comments = new List<BookComment>(),
                Processes = new List<BookProcess>()
            });
            _books.Add(new Book
            {
                Id = Guid.NewGuid().ToString(),
                Name = "SomeBookName",
                Year = 2020,
                BookUrl = "SomeBookUrl",
                ImageIrl = "SomeBookImageUrl",
                Description = "SomeBookDescription",
                Authors = new List<AuthorBook>
                {
                    new AuthorBook
                    {
                        Id = "123",
                        Book = _book,
                        Author = _author,
                        BookId = _book.Id,
                        AuthorId = "321"
                    }
                },
                Genres = new List<GenreBook>
                {
                    new GenreBook
                    {
                        Book = _book,
                        Id = "123",
                        BookId = _book.Id,
                        GenreId = "321",
                        Genre = new Genre()
                    }
                },
                Likes = new List<BookLike>(),
                Assessments = new List<BookAssessment>(),
                Comments = new List<BookComment>(),
                Processes = new List<BookProcess>()
            });
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(_books);
            _mockBookRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_book);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.AreEqual(bookService.GetByGenre("321", It.IsAny<string>()).Result.Count, 2);
        }

        [Test]
        public void GetByGenre_GoodArgument_ReturnNull_Exception()
        {
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(() => null);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => bookService.GetByGenre("321", It.IsAny<string>()));
        }

        [Test]
        public void GetByGenre_BadArgument_Exception()
        {
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(_books);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => bookService.GetByGenre("321", It.IsAny<string>()));
        }

        [Test]
        public void GetByGenre_NullArgument_Exception()
        {
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(_books);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => bookService.GetByGenre(null, It.IsAny<string>()));
        }

        [Test]
        public void GetById_GoodArgument_Success()
        {
            _mockBookRepository.Setup(w => w.GetById(_book.Id)).ReturnsAsync(_book);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.That(bookService.GetById(_book.Id, It.IsAny<string>()).Result, Is.TypeOf(typeof(BookListingModel)));
        }

        [Test]
        public void GetById_BadArgument_ReturnNull_Exception()
        {
            _mockBookRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(() => null);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => bookService.GetById("123", It.IsAny<string>()));
        }

        [Test]
        public void GetById_NullArgument_Exception()
        {
            _mockBookRepository.Setup(w => w.GetById(null)).Returns(() => null);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => bookService.GetById(null, It.IsAny<string>()));
        }

        [Test]
        public void GetByName_GoodArgument_Success()
        {
            _books.Add(new Book
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "SomeBookName1",
                    Year = 2020,
                    BookUrl = "SomeBookUrl",
                    ImageIrl = "SomeBookImageUrl",
                    Description = "SomeBookDescription",
                    Authors = new List<AuthorBook>(),
                    Genres = new List<GenreBook>(),
                    Likes = new List<BookLike>(),
                    Assessments = new List<BookAssessment>(),
                    Comments = new List<BookComment>(),
                    Processes = new List<BookProcess>()
                });
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(_books);
            _mockBookRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_book);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.That(bookService.GetByName("SomeBookName1", It.IsAny<string>()).Result, Is.TypeOf<BookListingModel>());
        }

        [Test]
        public void GetByName_GoodArgument_ReturnNull_Exception()
        {
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(() => null);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => bookService.GetByName("SomeBookName", It.IsAny<string>()));
        }

        [Test]
        public void GetByName_BadArgument_Exception()
        {
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(_books);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => bookService.GetByName("123", It.IsAny<string>()));
        }

        [Test]
        public void GetByName_NullArgument_Exception()
        {
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(_books);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => bookService.GetByName(null, It.IsAny<string>()));
        }

        [Test]
        public void AddBook_GoodArgument_Success()
        {
            var bookCreateModel = new BookCreateModel
            {
                Name = "SomeBookName1",
                BookUrl = "SomeBookUrl",
                ImageUrl = "SomeImageUrl",
                Description = "SomeBookDescription",
                Year = 2020,
                Authors = new List<string>(),
                Genres = new List<string>()
            };
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(_books);
            _mockBookRepository.Setup(w => w.Add(It.IsAny<Book>())).ReturnsAsync(_book);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.That(bookService.AddBook(bookCreateModel).Result, Is.TypeOf<string>());
        }

        [Test]
        public void AddBook_GoodArgument_ReturnNull1_Exception()
        {
            var bookCreateModel = new BookCreateModel
            {
                Name = "SomeBookName1",
                BookUrl = "SomeBookUrl",
                ImageUrl = "SomeImageUrl",
                Description = "SomeBookDescription",
                Year = 2020,
                Authors = new List<string>(),
                Genres = new List<string>()
            };
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(_books);
            _mockBookRepository.Setup(w => w.Add(It.IsAny<Book>())).ReturnsAsync(() => null);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => bookService.AddBook(bookCreateModel));
        }

        [Test]
        public void AddBook_GoodArgument_ReturnNull2_Exception()
        {
            var bookCreateModel = new BookCreateModel
            {
                Name = "SomeBookName1",
                BookUrl = "SomeBookUrl",
                ImageUrl = "SomeImageUrl",
                Description = "SomeBookDescription",
                Year = 2020,
                Authors = new List<string>(),
                Genres = new List<string>()
            };
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(() => null);
            _mockBookRepository.Setup(w => w.Add(It.IsAny<Book>())).ReturnsAsync(_book);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<ServerException>(() => bookService.AddBook(bookCreateModel));
        }

        [Test]
        public void AddBook_BadArgument_Exception()
        {
            var bookCreateModel = new BookCreateModel
            {
                Name = "SomeBookName",
                BookUrl = "SomeBookUrl",
                ImageUrl = "SomeImageUrl",
                Description = "SomeBookDescription",
                Year = 2020,
                Authors = new List<string>(),
                Genres = new List<string>()
            };
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(_books);
            _mockBookRepository.Setup(w => w.Add(It.IsAny<Book>())).ReturnsAsync(_book);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => bookService.AddBook(bookCreateModel));
        }

        [Test]
        public void AddBook_NullArgument_Exception()
        {
            _mockBookRepository.Setup(w => w.GetAll()).ReturnsAsync(_books);
            _mockBookRepository.Setup(w => w.Add(It.IsAny<Book>())).ReturnsAsync(_book);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => bookService.AddBook(null));
        }

        [Test]
        public void Delete_GoodArgument_Success()
        {
            _mockBookRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_book);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            var delete = bookService.Delete("123");
            _mockBookRepository.Verify(w => w.Delete(_book), Times.Once);
        }

        [Test]
        public void Delete_BadArgument_ReturnNull_Exception()
        {
            _mockBookRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(() => null);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => bookService.Delete("123"));
        }

        [Test]
        public void Delete_NullArgument_Exception()
        {
            _mockBookRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(() => null);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => bookService.Delete(null));
        }

        [Test]
        public void AddAssessment_GoodArgument_Success()
        {
            _mockBookRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_book);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            var addAssessment = bookService.AddAssessment(_book.Id, "123", 7);
            _mockBookRepository.Verify(w => w.AddAssessment(It.IsAny<Book>(), It.IsAny<string>(), 7), Times.Once);
        }

        [Test]
        public void AddAssessment_GoodArgument_InOnDb_Exception()
        {
            var book = new Book
            {
                Id = Guid.NewGuid().ToString(),
                Name = "SomeBookName",
                Year = 2020,
                BookUrl = "SomeBookUrl",
                ImageIrl = "SomeBookImageUrl",
                Description = "SomeBookDescription",
                Authors = new List<AuthorBook>(),
                Genres = new List<GenreBook>(),
                Likes = new List<BookLike>(),
                Assessments = new List<BookAssessment>
                {
                    new BookAssessment
                    {
                        Id = Guid.NewGuid().ToString(),
                        Book = It.IsAny<Book>(),
                        BookId = It.IsAny<string>(),
                        User = It.IsAny<User>(),
                        Count = 7,
                        UserId = "123"
                    }
                },
                Comments = new List<BookComment>(),
                Processes = new List<BookProcess>()
            };
            _mockBookRepository.Setup(w => w.GetById("123")).ReturnsAsync(book);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => bookService.AddAssessment("123", "123", 7));
        }

        [Test]
        public void AddAssessment_BadArgument_BookId_ReturnNull_Exception()
        {
            _mockBookRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(() => null);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => bookService.AddAssessment("123", "123", 7));
        }

        [Test]
        public void AddAssessment_BadArgument_NullBookId_Exception()
        {
            _mockBookRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(() => null);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => bookService.AddAssessment(null, "123", 7));
        }

        [Test]
        public void AddAssessment_BadArgument_Assessment_Exception()
        {
            _mockBookRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(() => null);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => bookService.AddAssessment("123", "123", 11));
        }

        [Test]
        public void AddOrUpdateProcess_GoodArgument_NotInDb_Success()
        {
            _mockBookRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(_book);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            var addOrUpdateProcess = bookService.AddOrUpdateProcess("123", It.IsAny<string>(), 2);
            _mockBookRepository.Verify(w => w.UpdateProcess(It.IsAny<Book>(), It.IsAny<string>(), 2), Times.Never);
            _mockBookRepository.Verify(w => w.AddProcess(It.IsAny<Book>(), It.IsAny<string>(), 2), Times.Once);
        }

        [Test]
        public void AddOrUpdateProcess_GoodArgument_InOnDb_Exception()
        {
            var book = new Book
            {
                Id = Guid.NewGuid().ToString(),
                Name = "SomeBookName",
                Year = 2020,
                BookUrl = "SomeBookUrl",
                ImageIrl = "SomeBookImageUrl",
                Description = "SomeBookDescription",
                Authors = new List<AuthorBook>(),
                Genres = new List<GenreBook>(),
                Likes = new List<BookLike>(),
                Assessments = new List<BookAssessment>
                {
                    new BookAssessment
                    {
                        Id = Guid.NewGuid().ToString(),
                        Book = It.IsAny<Book>(),
                        BookId = It.IsAny<string>(),
                        User = It.IsAny<User>(),
                        Count = 7,
                        UserId = "123"
                    }
                },
                Comments = new List<BookComment>(),
                Processes = new List<BookProcess>
                {
                    new BookProcess
                    {
                        Id = Guid.NewGuid().ToString(),
                        Book = It.IsAny<Book>(),
                        User = It.IsAny<User>(),
                        BookId = It.IsAny<string>(),
                        UserId = "123",
                        Process = 2
                    }
                }
            };
            _mockBookRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(book);

            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            var addOrUpdateProcess = bookService.AddOrUpdateProcess("123", "123", 2);
            _mockBookRepository.Verify(w => w.UpdateProcess(It.IsAny<Book>(), It.IsAny<string>(), 2), Times.Once);
            _mockBookRepository.Verify(w => w.AddProcess(It.IsAny<Book>(), It.IsAny<string>(), 2), Times.Never);
        }

        [Test]
        public void AddOrUpdateProcess_BadArgument_BookId_ReturnNull_Exception()
        {
            _mockBookRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(() => null);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => bookService.AddOrUpdateProcess("123", "123", 2));
        }

        [Test]
        public void AddOrUpdateProcess_BadArgument_NullBookId_Exception()
        {
            _mockBookRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(() => null);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => bookService.AddOrUpdateProcess(null, It.IsAny<string>(), 2));
        }

        [Test]
        public void AddOrUpdateProcess_BadArgument_Process_Exception()
        {
            _mockBookRepository.Setup(w => w.GetById(It.IsAny<string>())).ReturnsAsync(() => null);
            using var bookService = new BookService(_mockBookRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => bookService.AddOrUpdateProcess("123", It.IsAny<string>(), 4));
        }
    }
}