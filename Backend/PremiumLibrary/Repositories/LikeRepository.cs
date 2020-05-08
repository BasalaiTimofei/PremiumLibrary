using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PremiumLibrary.Context;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Models.DataBaseModels.AuthorFolder;
using PremiumLibrary.Models.DataBaseModels.BookFolder;
using PremiumLibrary.Models.DataBaseModels.GenreFolder;

namespace PremiumLibrary.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ApplicationContext _applicationContext;
        private bool _disposed;

        public LikeRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task AddBookLike(string bookId, string userId)
        {
            var bookLike = new BookLike
            {
                Id = Guid.NewGuid().ToString(),
                BookId = bookId,
                UserId = userId,
                Book = _applicationContext.Books.FindAsync(bookId).Result,
                User = _applicationContext.Users.FindAsync(userId).Result
            };
            await _applicationContext.BookLikes.AddAsync(bookLike);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task AddBookCommentLike(string bookCommentId, string userId)
        {
            var bookCommentLike = new BookCommentLike
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                BookCommentId = bookCommentId,
                User =_applicationContext.Users.FindAsync(userId).Result,
                BookComment = _applicationContext.BookComments.FindAsync(bookCommentId).Result
            };
            await _applicationContext.BookCommentLikes.AddAsync(bookCommentLike);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task AddAuthorLike(string authorId, string userId)
        {
            var authorLike = new AuthorLike
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                AuthorId = authorId,
                User = _applicationContext.Users.FindAsync(userId).Result,
                Author = _applicationContext.Authors.FindAsync(authorId).Result
            };
            await _applicationContext.AuthorLikes.AddAsync(authorLike);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task AddAuthorCommentLike(string authorCommentId, string userId)
        {
            var authorCommentLike = new AuthorCommentLike
            {
                Id = Guid.NewGuid().ToString(),
                AuthorCommentId = authorCommentId,
                UserId = userId,
                User = _applicationContext.Users.FindAsync(userId).Result,
                AuthorComment = _applicationContext.AuthorComments.FindAsync(authorCommentId).Result
            };
            await _applicationContext.AuthorCommentLikes.AddAsync(authorCommentLike);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task AddGenreLike(string genreId, string userId)
        {
            var genreLike = new GenreLike
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                GenreId = genreId,
                User = _applicationContext.Users.FindAsync(userId).Result,
                Genre = _applicationContext.Genres.FindAsync(genreId).Result
            };
            await _applicationContext.GenreLikes.AddAsync(genreLike);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task DeleteBookLike(string bookId, string userId)
        {
            var bookLike = await _applicationContext.BookLikes.FirstOrDefaultAsync(w =>
                string.Equals(w.BookId, bookId) && string.Equals(w.UserId, userId));
            if (bookLike == null) return;
            _applicationContext.BookLikes.Remove(bookLike);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task DeleteBookCommentLike(string bookCommentId, string userId)
        {
            var bookCommentLike = await _applicationContext.BookCommentLikes.FirstOrDefaultAsync(w =>
                string.Equals(w.BookCommentId, bookCommentId) && string.Equals(w.UserId, userId));
            if (bookCommentLike == null) return;
            _applicationContext.BookCommentLikes.Remove(bookCommentLike);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task DeleteAuthorLike(string authorId, string userId)
        {
            var authorLike = await _applicationContext.AuthorLikes.FirstOrDefaultAsync(w =>
                string.Equals(w.AuthorId, authorId) && string.Equals(w.UserId, userId));
            if (authorLike == null) return;
            _applicationContext.AuthorLikes.Remove(authorLike);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task DeleteAuthorCommentLike(string authorCommentId, string userId)
        {
            var authorCommentLike = await _applicationContext.AuthorCommentLikes.FirstOrDefaultAsync(w =>
                string.Equals(w.AuthorCommentId, authorCommentId) && string.Equals(w.UserId, userId));
            if (authorCommentLike == null) return;
            _applicationContext.AuthorCommentLikes.Remove(authorCommentLike);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task DeleteGenreLike(string genreId, string userId)
        {
            var genreLike = await _applicationContext.GenreLikes.FirstOrDefaultAsync(w =>
                string.Equals(w.GenreId, genreId) && string.Equals(w.UserId, userId));
            if (genreLike == null) return;
            _applicationContext.GenreLikes.Remove(genreLike);
            await _applicationContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _applicationContext.Dispose();
            }
            _disposed = true;
        }
    }
}