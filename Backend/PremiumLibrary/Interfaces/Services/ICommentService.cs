using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PremiumLibrary.Interfaces.Services
{
    public interface ICommentService : IDisposable
    {
        Task<List<AuthorCommentListingModel>> GetAuthorComment(string authorId, string userId);
        Task<List<BookCommentListingModel>> GetBookComment(string bookId, string userId);

        Task AddAuthorComment(AuthorCommentCreateModel authorCommentCreateModel);
        Task AddBookComment(BookCommentCreateModel bookCommentCreateModel);
        Task DeleteAuthorComment(string authorCommentId, string userId);
        Task DeleteBookComment(string bookCommentId, string userId);
    }
}