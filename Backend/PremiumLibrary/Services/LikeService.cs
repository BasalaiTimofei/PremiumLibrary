using System;
using System.Threading.Tasks;
using Castle.Core.Internal;
using PremiumLibrary.Exceptions;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Interfaces.Services;

namespace PremiumLibrary.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private bool _disposed;

        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task AddBookLike(string bookId, string userId)
        {
            if (bookId.IsNullOrEmpty() || userId.IsNullOrEmpty()) throw new CustomException("Некоректные данные");
            await _likeRepository.AddBookLike(bookId, userId);
        }

        public async Task AddBookCommentLike(string bookCommentId, string userId)
        {
            if (bookCommentId.IsNullOrEmpty() || userId.IsNullOrEmpty()) throw new CustomException("Некоректные данные");
            await _likeRepository.AddBookCommentLike(bookCommentId, userId);
        }

        public async Task AddAuthorLike(string authorId, string userId)
        {
            if (authorId.IsNullOrEmpty() || userId.IsNullOrEmpty()) throw new CustomException("Некоректные данные");
            await _likeRepository.AddAuthorLike(authorId, userId);
        }

        public async Task AddAuthorCommentLike(string authorCommentId, string userId)
        {
            if (authorCommentId.IsNullOrEmpty() || userId.IsNullOrEmpty()) throw new CustomException("Некоректные данные");
            await _likeRepository.AddAuthorCommentLike(authorCommentId, userId);
        }

        public async Task AddGenreLike(string genreId, string userId)
        {
            if (genreId.IsNullOrEmpty() || userId.IsNullOrEmpty()) throw new CustomException("Некоректные данные");
            await _likeRepository.AddGenreLike(genreId, userId);
        }

        public async Task DeleteBookLike(string bookId, string userId)
        {
            if (bookId.IsNullOrEmpty() || userId.IsNullOrEmpty()) throw new CustomException("Некоректные данные");
            await _likeRepository.DeleteBookLike(bookId, userId);
        }

        public async Task DeleteBookCommentLike(string bookCommentId, string userId)
        {
            if (bookCommentId.IsNullOrEmpty() || userId.IsNullOrEmpty()) throw new CustomException("Некоректные данные");
            await _likeRepository.DeleteBookCommentLike(bookCommentId, userId);
        }

        public async Task DeleteAuthorLike(string authorId, string userId)
        {
            if (authorId.IsNullOrEmpty() || userId.IsNullOrEmpty()) throw new CustomException("Некоректные данные");
            await _likeRepository.DeleteAuthorLike(authorId, userId);
        }

        public async Task DeleteAuthorCommentLike(string authorCommentId, string userId)
        {
            if (authorCommentId.IsNullOrEmpty() || userId.IsNullOrEmpty()) throw new CustomException("Некоректные данные");
            await _likeRepository.DeleteAuthorCommentLike(authorCommentId, userId);
        }

        public async Task DeleteGenreLike(string genreId, string userId)
        {
            if (genreId.IsNullOrEmpty() || userId.IsNullOrEmpty()) throw new CustomException("Некоректные данные");
            await _likeRepository.DeleteGenreLike(genreId, userId);
        }

        public void Dispose()
        {
            if (_disposed) return;
            _likeRepository?.Dispose();
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        ~LikeService()
        {
            Dispose();
        }
    }
}