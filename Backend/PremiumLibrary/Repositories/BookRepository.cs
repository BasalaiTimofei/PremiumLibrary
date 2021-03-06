﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PremiumLibrary.Context;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Models.DataBaseModels.BookFolder;

namespace PremiumLibrary.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationContext _applicationContext;
        private bool _disposed;

        public BookRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<List<Book>> GetAll()
        {
            return await _applicationContext.Books.ToListAsync();
        }

        public async Task<Book> GetById(string id)
        {
            return await _applicationContext.Books.FirstOrDefaultAsync(w => string.Equals(w.Id, id));
        }

        public async Task<Book> Add(Book book)
        {
            await _applicationContext.Books.AddAsync(book);
            await _applicationContext.SaveChangesAsync();
            return await _applicationContext.Books.FirstOrDefaultAsync(w => string.Equals(w.Id, book.Id));
        }

        public async Task AddAssessment(Book book, string userId, int count)
        {
            var user = await _applicationContext.Users.FindAsync(userId);
            var assessment = new BookAssessment
            {
                Id = Guid.NewGuid().ToString(),
                User = user,
                UserId = user.Id,
                Book = book,
                BookId = book.Id,
                Count = count
            };
            await _applicationContext.BookAssessments.AddAsync(assessment);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task AddProcess(Book book, string userId, int count)
        {
            var user = await _applicationContext.Users.FindAsync(userId);
            var process = new BookProcess
            {
                Id = Guid.NewGuid().ToString(),
                User = user,
                UserId = user.Id,
                Book = book,
                BookId = book.Id,
                Process = count
            };
            await _applicationContext.BookProcesses.AddAsync(process);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task UpdateProcess(Book book, string userId, int count)
        {
            var processDb = await _applicationContext.BookProcesses.FirstOrDefaultAsync(w =>
                string.Equals(w.BookId, book.Id) && string.Equals(w.UserId, userId));
            var entry = _applicationContext.Entry(processDb);
            entry.CurrentValues.SetValues(processDb.Process = count);
            entry.Property(w => w.Id).IsModified = false;
            await _applicationContext.SaveChangesAsync();
        }

        public async Task Delete(Book book)
        {
            _applicationContext.Books.Remove(book);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task<Book> Update(Book book)
        {
            var bookDb = await _applicationContext.Books.FirstOrDefaultAsync(w => string.Equals(w.Id, book.Id));
            var entry = _applicationContext.Entry(bookDb);
            entry.CurrentValues.SetValues(book);
            entry.Property(w => w.Id).IsModified = false;
            await _applicationContext.SaveChangesAsync();
            return await _applicationContext.Books.FirstOrDefaultAsync(w => string.Equals(w.Id, book.Id));
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