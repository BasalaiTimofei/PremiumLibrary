using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremiumLibrary.Models.DataBaseModels.BookFolder;

namespace PremiumLibrary.Interfaces.Repositories
{
    public interface IBookRepository : IDisposable
    {
        Task<List<Book>> GetAll();
        Task<Book> GetById(string id);

        Task<Book> Add(Book book);
        Task AddAssessment(Book book, string userId, int count);
        Task AddProcess(Book book, string userId, int count);
        Task UpdateProcess(Book book, string userId, int count);
        Task Delete(Book book);
        Task<Book> Update(Book book);
    }
}