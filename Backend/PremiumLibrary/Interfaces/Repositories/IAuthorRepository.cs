using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremiumLibrary.Models.DataBaseModels.Book;

namespace PremiumLibrary.Interfaces.Repositories
{
    public interface IAuthorRepository : IDisposable
    {
        Task<List<Author>> GetAll();
        Task<Author> GetById(string id);

        Task<Author> Add(Author author);
        Task<Author> Update(Author author);
        Task Delete(Author author);
    }
}