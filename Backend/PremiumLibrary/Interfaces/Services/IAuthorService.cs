using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremiumLibrary.Models.ViewModels.Author;

namespace PremiumLibrary.Interfaces.Services
{
    public interface IAuthorService : IDisposable
    {
        Task<List<AuthorListingModel>> GetAll(string userId);
        Task<List<AuthorListingModel>> GetByBook(string bookId, string userId);
       
        Task<AuthorListingModel> GetById(string authorId, string userId);
        Task<AuthorListingModel> GetByName(string authorName, string userId);
        
        Task Create(AuthorCreateModel authorCreateModel);
        Task Update();
        Task Delete(string authorId);
    }
}