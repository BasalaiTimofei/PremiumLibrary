using System;
using System.Threading.Tasks;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Interfaces.Services;

namespace PremiumLibrary.Services
{
    public class DependencyService : IDependencyService
    {
        private readonly IDependencyRepository _dependencyRepository;
        private bool _disposed;

        public DependencyService(IDependencyRepository dependencyRepository)
        {
            _dependencyRepository = dependencyRepository;
        }

        public async Task AddAuthorsBook(string bookId, string authorsId)
        {
            await _dependencyRepository.AddAuthorBook(bookId, authorsId);
        }

        public async Task DeleteAuthorBook(string bookId, string authorId)
        {
            var dependency = await _dependencyRepository.GetAuthorBook(bookId, authorId);
            if (dependency == null) return;
            await _dependencyRepository.DeleteAuthorBook(dependency);
        }

        public async Task AddGenresBook(string bookId, string genresId)
        {
            await _dependencyRepository.AddGenreBook(bookId, genresId);
        }

        public async Task DeleteGenreBook(string bookId, string genreId)
        {
            var dependency = await _dependencyRepository.GetGenreBook(bookId, genreId);
            if (dependency == null) return;
            await _dependencyRepository.DeleteGenreBook(dependency);
        }

        public void Dispose()
        {
            if (_disposed) return;
            _dependencyRepository?.Dispose();
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        ~DependencyService()
        {
            Dispose();
        }
    }
}