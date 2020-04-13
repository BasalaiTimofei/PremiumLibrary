using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PremiumLibrary.Context;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Models.DataBaseModels.Book;

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

        public async Task<AuthorBook> AddAuthorBook(AuthorBook authorBook)
        {
            await _applicationContext.AuthorBooks.AddAsync(authorBook);
            await _applicationContext.SaveChangesAsync();
            return await _applicationContext.AuthorBooks.FirstOrDefaultAsync(w => string.Equals(w.Id, authorBook.Id));
        }

        public async Task<GenreBook> AddGenreBook(GenreBook genreBook)
        {
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