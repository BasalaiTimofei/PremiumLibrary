using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremiumLibrary.Models.ViewModels.Genre;

namespace PremiumLibrary.Interfaces.Services
{
    public interface IGenreService : IDisposable
    {
        Task<List<GenreListingModel>> GetAll(string userId);
        Task<List<GenreListingModel>> GetByBook(string bookId, string userId);
        Task<List<GenreListingModel>> GetByLike(string userId);

        Task<GenreListingModel> GetById(string genreId, string userId);
        Task<GenreListingModel> GetByName(string genreName, string userId);

        Task<string> Create(GenreCreateModel genreCreateModel);
        Task Update();
        Task Delete(string genreId);
    }
}