using System;
using System.Threading.Tasks;

namespace PremiumLibrary.Interfaces.Services
{
    public interface ILikeService : IDisposable
    {
        Task AddBookLike(string bookId, string userId);
        Task AddBookCommentLike(string bookCommentId, string userId);
        Task AddAuthorLike(string authorId, string userId);
        Task AddAuthorCommentLike(string authorCommentId, string userId);
        Task AddGenreLike(string genreId, string userId);

        Task DeleteBookLike(string bookId, string userId);
        Task DeleteBookCommentLike(string bookCommentId, string userId);
        Task DeleteAuthorLike(string authorId, string userId);
        Task DeleteAuthorCommentLike(string authorCommentId, string userId);
        Task DeleteGenreLike(string genreId, string userId);
    }
}