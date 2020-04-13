using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PremiumLibrary.Context;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Models.DataBaseModels.Book;

namespace PremiumLibrary.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationContext _applicationContext;
        private bool _disposed;

        public GenreRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<List<Genre>> GetAll()
        {
            return await _applicationContext.Genres.ToListAsync();
        }

        public async Task<Genre> GetById(string id)
        {
            return await _applicationContext.Genres.FirstOrDefaultAsync(w => string.Equals(w.Id, id));
        }

        public async Task<Genre> Add(Genre genre)
        {
            await _applicationContext.Genres.AddAsync(genre);
            await _applicationContext.SaveChangesAsync();
            return await _applicationContext.Genres.FirstOrDefaultAsync(w => string.Equals(w.Id, genre.Id));
        }

        public async Task<Genre> Update(Genre genre)
        {
            var genreDb = await _applicationContext.Genres.FirstOrDefaultAsync(w => string.Equals(w.Id, genre.Id));
            var entry = _applicationContext.Entry(genreDb);
            entry.CurrentValues.SetValues(genre);
            entry.Property(w => w.Id).IsModified = false;
            await _applicationContext.SaveChangesAsync();
            return await _applicationContext.Genres.FirstOrDefaultAsync(w => string.Equals(w.Id, genre.Id));
        }

        public async Task Delete(Genre genre)
        {
            _applicationContext.Genres.Remove(genre);
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
