using System;
using System.Threading.Tasks;
using PremiumLibrary.Models.DataBaseModels.Book;

namespace PremiumLibrary.Interfaces.Repositories
{
    public interface ILikeRepository : IDisposable
    {
        Task AddBookLike(BookLike bookLike);
        Task AddBookCommentLike(BookCommentLike bookCommentLike);
        Task AddAuthorLike(AuthorLike authorLike);
        Task AddAuthorCommentLike(AuthorCommentLike authorCommentLike);
        Task AddGenreLike(GenreLike genreLike);

        Task DeleteBookLike(BookLike bookLike);
        Task DeleteBookCommentLike(BookCommentLike bookCommentLike);
        Task DeleteAuthorLike(AuthorLike authorLike);
        Task DeleteAuthorCommentLike(AuthorCommentLike authorCommentLike);
        Task DeleteGenreLike(GenreLike genreLike);
    }
}