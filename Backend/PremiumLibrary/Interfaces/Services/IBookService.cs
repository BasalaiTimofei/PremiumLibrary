using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremiumLibrary.Models.ViewModels.Book;

namespace PremiumLibrary.Interfaces.Services
{
    public interface IBookService : IDisposable
    {
        Task<List<BookListingModel>> GetAll(string userId);
        Task<List<BookListingModel>> GetByAuthor(string authorId, string userId);
        Task<List<BookListingModel>> GetByGenre(string genreId, string userId);
        Task<List<BookListingModel>> GetByLikes(string userId);

        Task<BookListingModel> GetById(string bookId, string userId);
        Task<BookListingModel> GetByName(string bookName, string userId);

        Task<string> AddBook(BookCreateModel bookCreateModel);
        Task Update();
        Task Delete(string bookId);

        Task AddAssessment(string bookId, string userId, int assessment);
        Task AddOrUpdateProcess(string bookId, string userId, int count);
    }
}