﻿using System;
using System.Threading.Tasks;

namespace PremiumLibrary.Interfaces.Services
{
    public interface IAutoFillService : IDisposable
    {
        Task CreateRoles();
        Task CreateAdmin();
        Task CreateUsers();
        Task CreateGenres();
        Task CreateAuthors();
        Task CreateBooks();
        Task CreateDependencyAuthorBook();
        Task CreateDependencyGenreBook();
        Task CreateBookLike();
        Task CreateAuthorLike();
        Task CreateGenreLike();
        Task CreateCommentBook();
        Task CreateCommentAuthor();
        Task CreateAssessment();
        Task CreateProcess();
    }
}
