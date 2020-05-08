using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PremiumLibrary.Context;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Models.DataBaseModels.AuthorFolder;
using PremiumLibrary.Models.DataBaseModels.BookFolder;

namespace PremiumLibrary.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationContext _applicationContext;
        private bool _disposed;

        public CommentRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<List<AuthorComment>> GetAuthorComments(string authorId)
        {
            return await _applicationContext.AuthorComments.Where(w => string.Equals(w.AuthorId, authorId))
                .ToListAsync();
        }

        public async Task<List<BookComment>> GetBookComments(string bookId)
        {
            return await _applicationContext.BookComments.Where(w => string.Equals(w.BookId, bookId))
                .ToListAsync();
        }

        public async Task<AuthorComment> GetAuthorComment(string authorCommentId)
        {
            return await _applicationContext.AuthorComments.FindAsync(authorCommentId);
        }

        public async Task<BookComment> GetBookComment(string bookCommentId)
        {
            return await _applicationContext.BookComments.FindAsync(bookCommentId);
        }

        public async Task<AuthorComment> AddAuthorComment(AuthorComment authorComment)
        {
            authorComment.User = await _applicationContext.Users.FindAsync(authorComment.UserId);
            authorComment.Author = await _applicationContext.Authors.FindAsync(authorComment.AuthorId);
            await _applicationContext.AuthorComments.AddAsync(authorComment);
            await _applicationContext.SaveChangesAsync();
            return await _applicationContext.AuthorComments.FirstOrDefaultAsync(w =>
                string.Equals(w.Id, authorComment.Id));
        }

        public async Task<BookComment> AddBookComment(BookComment bookComment)
        {
            bookComment.User = await _applicationContext.Users.FindAsync(bookComment.UserId);
            bookComment.Book = await _applicationContext.Books.FindAsync(bookComment.BookId);
            await _applicationContext.BookComments.AddAsync(bookComment);
            await _applicationContext.SaveChangesAsync();
            return await _applicationContext.BookComments.FirstOrDefaultAsync(w => 
                string.Equals(w.Id, bookComment.Id));
        }

        public async Task DeleteAuthorComment(AuthorComment authorComment)
        {
            _applicationContext.AuthorComments.Remove(authorComment);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task DeleteBookComment(BookComment bookComment)
        {
            _applicationContext.BookComments.Remove(bookComment);
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