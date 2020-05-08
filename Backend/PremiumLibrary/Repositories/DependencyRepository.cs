using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PremiumLibrary.Context;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Models.DataBaseModels.AuthorFolder;
using PremiumLibrary.Models.DataBaseModels.GenreFolder;

namespace PremiumLibrary.Repositories
{
    public class DependencyRepository : IDependencyRepository
    {
        private readonly ApplicationContext _applicationContext;
        private bool _disposed;

        public DependencyRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<AuthorBook> GetAuthorBook(string bookId, string authorId)
        {
            var dependencies = await _applicationContext.AuthorBooks.ToListAsync();
            return dependencies?.FirstOrDefault(w =>
                string.Equals(w.AuthorId, authorId) && string.Equals(w.BookId, bookId));
        }

        public async Task<GenreBook> GetGenreBook(string bookId, string genreId)
        {
            var dependencies = await _applicationContext.GenreBooks.ToListAsync();
            return dependencies?.FirstOrDefault(w =>
                string.Equals(w.GenreId, genreId) && string.Equals(w.BookId, bookId));
        }

        public async Task<AuthorBook> AddAuthorBook(string bookId, string authorId)
        {
            var authorBook = new AuthorBook
            {
                Id = Guid.NewGuid().ToString(),
                BookId = bookId,
                AuthorId = authorId,
                Book = await _applicationContext.Books.FindAsync(bookId),
                Author = await _applicationContext.Authors.FindAsync(authorId)
            };
            await _applicationContext.AuthorBooks.AddAsync(authorBook);
            await _applicationContext.SaveChangesAsync();
            return await _applicationContext.AuthorBooks.FirstOrDefaultAsync(w => string.Equals(w.Id, authorBook.Id));
        }

        public async Task<GenreBook> AddGenreBook(string bookId, string genreId)
        {
            var genreBook = new GenreBook
            {
                Id = Guid.NewGuid().ToString(),
                BookId = bookId,
                GenreId = genreId,
                Book = await _applicationContext.Books.FindAsync(bookId),
                Genre = await _applicationContext.Genres.FindAsync(genreId)
            };
            await _applicationContext.GenreBooks.AddAsync(genreBook);
            await _applicationContext.SaveChangesAsync();
            return await _applicationContext.GenreBooks.FirstOrDefaultAsync(w => string.Equals(w.Id, genreBook.Id));
        }

        public async Task DeleteAuthorBook(AuthorBook authorBook)
        {
            _applicationContext.AuthorBooks.Remove(authorBook);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task DeleteGenreBook(GenreBook genreBook)
        {
            _applicationContext.GenreBooks.Remove(genreBook);
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