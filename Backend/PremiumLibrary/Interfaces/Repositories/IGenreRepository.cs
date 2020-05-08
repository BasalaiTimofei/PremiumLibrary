using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremiumLibrary.Models.DataBaseModels.GenreFolder;

namespace PremiumLibrary.Interfaces.Repositories
{
    public interface IGenreRepository : IDisposable
    {
        Task<List<Genre>> GetAll();
        Task<Genre> GetById(string id);

        Task<Genre> Add(Genre genre);
        Task<Genre> Update(Genre genre);
        Task Delete(Genre genre);
    }
}