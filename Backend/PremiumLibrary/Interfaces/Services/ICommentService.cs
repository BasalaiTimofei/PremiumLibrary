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

        Task AddAuthorComment(AuthorCommentCreateModel authorCommentCreateModel);
        Task AddBookComment(BookCommentCreateModel bookCommentCreateModel);
        Task DeleteAuthorComment(string authorCommentId);
        Task DeleteBookComment(string bookCommentId);
    }
}