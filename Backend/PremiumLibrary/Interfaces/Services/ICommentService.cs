using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremiumLibrary.Models.ViewModels.Comment;

namespace PremiumLibrary.Interfaces.Services
{
    public interface ICommentService : IDisposable
    {
        Task<List<AuthorCommentListingModel>> GetAuthorComments(string authorId, string userId);
        Task<List<BookCommentListingModel>> GetBookComments(string bookId, string userId);

        Task AddAuthorComment(AuthorCommentCreateModel authorCommentCreateModel, string userId);
        Task AddBookComment(BookCommentCreateModel bookCommentCreateModel, string userId);
        Task DeleteAuthorComment(string authorCommentId);
        Task DeleteBookComment(string bookCommentId);
    }
}