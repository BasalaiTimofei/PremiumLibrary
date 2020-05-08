using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PremiumLibrary.Context;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Models.DataBaseModels.AuthorFolder;

namespace PremiumLibrary.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationContext _applicationContext;
        private bool _disposed;

        public AuthorRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<List<Author>> GetAll()
        {
            return await _applicationContext.Authors.ToListAsync();
        }

        public async Task<Author> GetById(string id)
        {
            return await _applicationContext.Authors.FirstOrDefaultAsync(w => string.Equals(w.Id, id));
        }

        public async Task<Author> Add(Author author)
        {
            await _applicationContext.Authors.AddAsync(author);
            await _applicationContext.SaveChangesAsync();
            return await _applicationContext.Authors.FirstOrDefaultAsync(w => string.Equals(w.Id, author.Id));
        }

        public async Task<Author> Update(Author author)
        {
            var authorDb = await _applicationContext.Authors.FirstOrDefaultAsync(w => string.Equals(w.Id, author.Id));
            var entry = _applicationContext.Entry(authorDb);
            entry.CurrentValues.SetValues(author);
            entry.Property(w => w.Id).IsModified = false;
            await _applicationContext.SaveChangesAsync();
            return await _applicationContext.Authors.FirstOrDefaultAsync(w => string.Equals(w.Id, author.Id));
        }

        public async Task Delete(Author author)
        {
            _applicationContext.Authors.Remove(author);
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