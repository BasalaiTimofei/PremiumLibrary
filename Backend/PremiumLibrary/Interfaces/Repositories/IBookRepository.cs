using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremiumLibrary.Models.DataBaseModels.Book;

namespace PremiumLibrary.Interfaces.Repositories
{
    public interface IBookRepository : IDisposable
    {
        Task<List<Book>> GetAll();
        Task<Book> GetById(string id);

        Task<Book> Add(Book book);
        Task Delete(Book book);
        Task<Book> Update(Book book);
    }
}