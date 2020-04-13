using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremiumLibrary.Models.DataBaseModels.Book;

namespace PremiumLibrary.Interfaces.Repositories
{
    public interface ICommentRepository : IDisposable
    {
        Task<List<AuthorComment>> GetAuthorComment(string authorId);
        Task<List<BookComment>> GetBookComment(string bookId);

        Task<AuthorComment> AddAuthorComment(AuthorComment authorComment);
        Task<BookComment> AddBookComment(BookComment bookComment);

        Task DeleteAuthorComment(AuthorComment authorComment);
        Task DeleteBookComment(BookComment bookComment);
    }
}