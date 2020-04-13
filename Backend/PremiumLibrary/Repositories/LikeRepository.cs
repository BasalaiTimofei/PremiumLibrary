using System;
using System.Threading.Tasks;
using PremiumLibrary.Context;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Models.DataBaseModels.Book;

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

        public async Task AddBookLike(BookLike bookLike)
        {
            await _applicationContext.BookLikes.AddAsync(bookLike);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task AddBookCommentLike(BookCommentLike bookCommentLike)
        {
            await _applicationContext.BookCommentLikes.AddAsync(bookCommentLike);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task AddAuthorLike(AuthorLike authorLike)
        {
            await _applicationContext.AuthorLikes.AddAsync(authorLike);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task AddAuthorCommentLike(AuthorCommentLike authorCommentLike)
        {
            await _applicationContext.AuthorCommentLikes.AddAsync(authorCommentLike);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task AddGenreLike(GenreLike genreLike)
        {
            await _applicationContext.GenreLikes.AddAsync(genreLike);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task DeleteBookLike(BookLike bookLike)
        {
            _applicationContext.BookLikes.Remove(bookLike);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task DeleteBookCommentLike(BookCommentLike bookCommentLike)
        {
            _applicationContext.BookCommentLikes.Remove(bookCommentLike);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task DeleteAuthorLike(AuthorLike authorLike)
        {
            _applicationContext.AuthorLikes.Remove(authorLike);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task DeleteAuthorCommentLike(AuthorCommentLike authorCommentLike)
        {
            _applicationContext.AuthorCommentLikes.Remove(authorCommentLike);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task DeleteGenreLike(GenreLike genreLike)
        {
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
