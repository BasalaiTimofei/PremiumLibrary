using System;
using System.Threading.Tasks;
using PremiumLibrary.Models.DataBaseModels.Book;

namespace PremiumLibrary.Interfaces.Repositories
{
    public interface IDependencyRepository : IDisposable
    {
        Task<AuthorBook> AddAuthorBook(AuthorBook authorBook);
        Task<GenreBook> AddGenreBook(GenreBook genreBook);
        Task DeleteAuthorBook(AuthorBook authorBook);
        Task DeleteGenreBook(GenreBook genreBook);
    }
}