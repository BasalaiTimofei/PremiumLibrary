using System;
using System.Threading.Tasks;
using PremiumLibrary.Models.DataBaseModels.AuthorFolder;
using PremiumLibrary.Models.DataBaseModels.GenreFolder;

namespace PremiumLibrary.Interfaces.Repositories
{
    public interface IDependencyRepository : IDisposable
    {
        Task<AuthorBook> GetAuthorBook(string bookId, string authorId);
        Task<GenreBook> GetGenreBook(string bookId, string genreId);

        Task<AuthorBook> AddAuthorBook(string bookId, string authorId);
        Task<GenreBook> AddGenreBook(string bookId, string genreId);
        
        Task DeleteAuthorBook(AuthorBook authorBook);
        Task DeleteGenreBook(GenreBook genreBook);
    }
}