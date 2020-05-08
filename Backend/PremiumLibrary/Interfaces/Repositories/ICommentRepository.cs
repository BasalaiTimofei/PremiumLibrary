using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremiumLibrary.Models.DataBaseModels.AuthorFolder;
using PremiumLibrary.Models.DataBaseModels.BookFolder;

namespace PremiumLibrary.Interfaces.Repositories
{
    public interface ICommentRepository : IDisposable
    {
        Task<List<AuthorComment>> GetAuthorComments(string authorId);
        Task<List<BookComment>> GetBookComments(string bookId);

        Task<AuthorComment> GetAuthorComment(string authorCommentId);
        Task<BookComment> GetBookComment(string bookCommentId);


        Task<AuthorComment> AddAuthorComment(AuthorComment authorComment);
        Task<BookComment> AddBookComment(BookComment bookComment);

        Task DeleteAuthorComment(AuthorComment authorComment);
        Task DeleteBookComment(BookComment bookComment);
    }
}