using System;
using System.Threading.Tasks;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Interfaces.Services;

namespace PremiumLibrary.Services
{
    public class AutoFillService : IAutoFillService
    {
        private readonly IAutoFillRepository _autoFillRepository;
        private bool _disposed;

        public AutoFillService(IAutoFillRepository autoFillRepository)
        {
            _autoFillRepository = autoFillRepository;
        }

        public async Task CreateRoles()
        {
            await _autoFillRepository.CreateRoles();
        }

        public async Task CreateAdmin()
        {
            await _autoFillRepository.CreateAdmin();
        }

        public async Task CreateUsers()
        {
            await _autoFillRepository.CreateUsers();
        }

        public async Task CreateGenres()
        {
            await _autoFillRepository.CreateGenres();
        }

        public async Task CreateAuthors()
        {
            await _autoFillRepository.CreateAuthors();
        }

        public async Task CreateBooks()
        {
            await _autoFillRepository.CreateBooks();
        }

        public async Task CreateDependencyAuthorBook()
        {
            await _autoFillRepository.CreateDependencyAuthorBook();
        }

        public async Task CreateDependencyGenreBook()
        {
            await _autoFillRepository.CreateDependencyGenreBook();
        }

        public async Task CreateBookLike()
        {
            await _autoFillRepository.CreateBookLike();
        }

        public async Task CreateAuthorLike()
        {
            await _autoFillRepository.CreateAuthorLike();
        }

        public async Task CreateGenreLike()
        {
            await _autoFillRepository.CreateGenreLike();
        }

        public async Task CreateCommentBook()
        {
            await _autoFillRepository.CreateCommentBook();
        }

        public async Task CreateCommentAuthor()
        {
            await _autoFillRepository.CreateCommentAuthor();
        }

        public async Task CreateAssessment()
        {
            await _autoFillRepository.CreateAssessment();
        }

        public async Task CreateProcess()
        {
            await _autoFillRepository.CreateProcess();
        }

        public void Dispose()
        {
            if (_disposed) return;
            _autoFillRepository?.Dispose();
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        ~AutoFillService()
        {
            Dispose();
        }

    }
}
