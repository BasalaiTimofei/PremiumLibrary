using System;
using System.Threading.Tasks;

namespace PremiumLibrary.Interfaces.Services
{
    public interface IDependencyService : IDisposable
    {
        Task AddAuthorsBook(string bookId, string authorsId);
        Task DeleteAuthorBook(string bookId, string authorId);

        Task AddGenresBook(string bookId, string genresId);
        Task DeleteGenreBook(string bookId, string genreId);
    }
}