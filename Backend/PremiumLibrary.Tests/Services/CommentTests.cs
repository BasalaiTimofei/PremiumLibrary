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
using PremiumLibrary.Models.ViewModels.Comment;
using PremiumLibrary.Services;

namespace PremiumLibrary.Tests.Services
{
    [TestFixture]
    class CommentTests
    {
        private MapperConfiguration _mapperConfiguration;
        private Mapper _mapper;
        private Mock<ICommentRepository> _mockCommentRepository;

        private BookComment _bookComment;
        private AuthorComment _authorComment;
        private List<BookComment> _bookComments;
        private List<AuthorComment> _authorComments;

        [SetUp]
        public void Init()
        {
            _mockCommentRepository = new Mock<ICommentRepository>();
            _mapperConfiguration = new MapperConfiguration(cfg => 
                cfg.AddProfiles(new List<Profile>
                {
                    new BookCommentProfile(),
                    new AuthorCommentProfile()
                }));
            _mapper = new Mapper(_mapperConfiguration);
            _bookComment = new BookComment
            {
                Id = Guid.NewGuid().ToString(),
                Comment = "SomeBookComment",
                UserId = "SomeUserId",
                BookId = "SomeBookId",
                DateTime = DateTime.Now,
                Book = new Book(),
                User = new User(),
                BookCommentLikes = new List<BookCommentLike>()
            };
            _bookComments = new List<BookComment>
            {
                _bookComment, _bookComment, _bookComment
            };
            _authorComment = new AuthorComment
            {
                Id = Guid.NewGuid().ToString(),
                Comment = "SomeAuthorComment",
                UserId = "SomeUserId",
                AuthorId = "SomeAuthorId",
                DateTime = DateTime.Now,
                Author = new Author(),
                User = new User(),
                AuthorCommentLikes = new List<AuthorCommentLike>()
            };
            _authorComments = new List<AuthorComment>
            {
                _authorComment, _authorComment, _authorComment
            };
        }

        [Test]
        public void GetAuthorComment_GoodArgument_Success()
        {
            _mockCommentRepository.Setup(w => w.GetAuthorComments(It.IsAny<string>())).ReturnsAsync(_authorComments);
            _mockCommentRepository.Setup(w => w.GetAuthorComment(It.IsAny<string>())).ReturnsAsync(_authorComment);
            using var commentService = new CommentService(_mockCommentRepository.Object, _mapper);
            Assert.That(commentService.GetAuthorComments("SomeAuthorId", It.IsAny<string>()).Result, Is.TypeOf(typeof(List<AuthorCommentListingModel>)));
        }
        
        [Test]
        public void GetAuthorComment_GoodArgument_ReturnNull_Exception()
        {
            _mockCommentRepository.Setup(w => w.GetAuthorComment(It.IsAny<string>())).ReturnsAsync(() => null);
            using var commentService = new CommentService(_mockCommentRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => commentService.GetAuthorComments("SomeAuthorId", It.IsAny<string>()));
        }

        [Test]
        public void GetAuthorComment_NullArgument_Exception()
        {
            _mockCommentRepository.Setup(w => w.GetAuthorComments(It.IsAny<string>())).ReturnsAsync(_authorComments);
            using var commentService = new CommentService(_mockCommentRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => commentService.GetAuthorComments(null, It.IsAny<string>()));
        }

        [Test]
        public void GetBookComment_GoodArgument_Success()
        {
            _mockCommentRepository.Setup(w => w.GetBookComments(It.IsAny<string>())).ReturnsAsync(_bookComments);
            _mockCommentRepository.Setup(w => w.GetBookComment(It.IsAny<string>())).ReturnsAsync(_bookComment);
            using var commentService = new CommentService(_mockCommentRepository.Object, _mapper);
            Assert.That(commentService.GetBookComments("SomeBookId", It.IsAny<string>()).Result, Is.TypeOf(typeof(List<BookCommentListingModel>)));
        }

        [Test]
        public void GetBookComment_GoodArgument_ReturnNull_Exception()
        {
            _mockCommentRepository.Setup(w => w.GetBookComments(It.IsAny<string>())).ReturnsAsync(() => null);
            using var commentService = new CommentService(_mockCommentRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => commentService.GetBookComments("SomeBookId", It.IsAny<string>()));
        }

        [Test]
        public void GetBookComment_NullArgument_Exception()
        {
            _mockCommentRepository.Setup(w => w.GetBookComments(It.IsAny<string>())).ReturnsAsync(_bookComments);
            using var commentService = new CommentService(_mockCommentRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => commentService.GetBookComments(null, It.IsAny<string>()));
        }

        [Test]
        public void AddAuthorComment_GoodArgument_Success()
        {
            var authorCommentCreateModel = new AuthorCommentCreateModel
            {
                AuthorId = "SomeAuthorId",
                Comment = "SomeAuthorComment"
            };
            using var commentService = new CommentService(_mockCommentRepository.Object, _mapper);
            var addAuthorComment = commentService.AddAuthorComment(authorCommentCreateModel, It.IsAny<string>());
            _mockCommentRepository.Verify(w => w.AddAuthorComment(It.IsAny<AuthorComment>()), Times.Once);
        }

        [Test]
        public void AddAuthorComment_BadArgument_Exception()
        {
            var authorCommentCreateModel = new AuthorCommentCreateModel
            {
                AuthorId = "",
                Comment = ""
            };
            using var commentService = new CommentService(_mockCommentRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => commentService.AddAuthorComment(authorCommentCreateModel, It.IsAny<string>()));
        }

        [Test]
        public void AddAuthorComment_NullArgument_Exception()
        {
            using var commentService = new CommentService(_mockCommentRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => commentService.AddAuthorComment(null, It.IsAny<string>()));
        }

        [Test]
        public void AddBookComment_GoodArgument_Success()
        {
            var bookCommentCreateModel = new BookCommentCreateModel
            {
                BookId = "SomeBookId",
                Comment = "SomeBookComment"
            };
            using var commentService = new CommentService(_mockCommentRepository.Object, _mapper);
            var addBookComment = commentService.AddBookComment(bookCommentCreateModel, It.IsAny<string>());
            _mockCommentRepository.Verify(w => w.AddBookComment(It.IsAny<BookComment>()), Times.Once);
        }

        [Test]
        public void AddBookComment_BadArgument_Exception()
        {
            var bookCommentCreateModel = new BookCommentCreateModel
            {
                BookId = "",
                Comment = ""
            };
            using var commentService = new CommentService(_mockCommentRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => commentService.AddBookComment(bookCommentCreateModel, It.IsAny<string>()));
        }

        [Test]
        public void AddBookComment_NullArgument_Exception()
        {
            using var commentService = new CommentService(_mockCommentRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => commentService.AddBookComment(null, It.IsAny<string>()));
        }

        [Test]
        public void DeleteAuthorComment_GoodArgument_Success()
        {
            var authorComment = new AuthorComment
            {
                Id = "123",
                Comment = "SomeAuthorComment",
                UserId = "SomeUserId",
                AuthorId = "SomeAuthorId1",
                DateTime = DateTime.Now,
                Author = new Author(),
                User = new User(),
                AuthorCommentLikes = new List<AuthorCommentLike>()
            };
            _mockCommentRepository.Setup(w => w.GetAuthorComment(It.IsAny<string>())).ReturnsAsync(authorComment);
            using var commentService = new CommentService(_mockCommentRepository.Object, _mapper);
            var deleteAuthorComment = commentService.DeleteAuthorComment("123");
            _mockCommentRepository.Verify(w => w.DeleteAuthorComment(It.IsAny<AuthorComment>()), Times.Once);
        }

        [Test]
        public void DeleteAuthorComment_BadArgument_ReturnNull_Exception()
        {
            _mockCommentRepository.Setup(w => w.GetAuthorComment(It.IsAny<string>())).ReturnsAsync(() => null);
            using var commentService = new CommentService(_mockCommentRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => commentService.DeleteAuthorComment("123"));
        }

        [Test]
        public void DeleteAuthorComment_BadArgument_Exception()
        {
            using var commentService = new CommentService(_mockCommentRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => commentService.DeleteAuthorComment(""));
        }

        [Test]
        public void DeleteAuthorComment_NullArgument_Exception()
        {
            using var commentService = new CommentService(_mockCommentRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => commentService.DeleteAuthorComment(null));
        }

        [Test]
        public void DeleteBookComment_GoodArgument_Success()
        {
            var bookComment = new BookComment
                {
                    Id = "123",
                    Comment = "SomeBookComment",
                    UserId = "SomeUserId",
                    BookId = "SomeBookId",
                    DateTime = DateTime.Now,
                    Book = new Book(),
                    User = new User(),
                    BookCommentLikes = new List<BookCommentLike>()
                };
            _mockCommentRepository.Setup(w => w.GetBookComment(It.IsAny<string>())).ReturnsAsync(bookComment);
            using var commentService = new CommentService(_mockCommentRepository.Object, _mapper);
            var deleteBookComment = commentService.DeleteBookComment("123");
            _mockCommentRepository.Verify(w => w.DeleteBookComment(It.IsAny<BookComment>()), Times.Once);
        }

        [Test]
        public void DeleteBookComment_BadArgument_ReturnNull_Exception()
        {
            _mockCommentRepository.Setup(w => w.GetBookComment(It.IsAny<string>())).ReturnsAsync(() => null);
            using var commentService = new CommentService(_mockCommentRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => commentService.DeleteBookComment("123"));
        }

        [Test]
        public void DeleteBookComment_BadArgument_Exception()
        {
            using var commentService = new CommentService(_mockCommentRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => commentService.DeleteBookComment(""));
        }

        [Test]
        public void DeleteBookComment_NullArgument_Exception()
        {
            using var commentService = new CommentService(_mockCommentRepository.Object, _mapper);
            Assert.ThrowsAsync<CustomException>(() => commentService.DeleteBookComment(null));
        }
    }
}