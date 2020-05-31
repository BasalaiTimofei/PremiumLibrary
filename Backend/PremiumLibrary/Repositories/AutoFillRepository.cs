using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PremiumLibrary.Context;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Models.DataBaseModels;
using PremiumLibrary.Models.DataBaseModels.AuthorFolder;
using PremiumLibrary.Models.DataBaseModels.BookFolder;
using PremiumLibrary.Models.DataBaseModels.GenreFolder;

namespace PremiumLibrary.Repositories
{
    public class AutoFillRepository : IAutoFillRepository
    {
        private const string AdminRoleId = "1dfc7345-86d2-4358-8f0a-9b02dd5b7a6b";
        private const string AdminId = "aae8b358-7030-4333-960e-112d144ff6fa";
        private const string UserRoleId = "1dfc7345-86d2-4358-8f0a-9b02dd5b7a6c";

        private readonly ApplicationContext _applicationContext;
        private bool _disposed;

        public AutoFillRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task CreateRoles()
        {
            await _applicationContext.Roles.AddAsync(new Role
            {
                Id = AdminRoleId,
                Users = new List<UserRole>(),
                Name = "Admin"
            });
            await _applicationContext.SaveChangesAsync();
            await _applicationContext.Roles.AddAsync(new Role
            {
                Id = UserRoleId,
                Users = new List<UserRole>(),
                Name = "User"
            });
            await _applicationContext.SaveChangesAsync();
        }

        public async Task CreateAdmin()
        {
            await _applicationContext.Users.AddAsync(new User
            {
                Id = AdminId,
                ImageUrl = @"https://sun1.beltelecom-by-minsk.userapi.com/Av5XcYjJBfNcNxIqY8YVS_Gy9WC_L_UjShS9SQ/rdcsLMiDsi4.jpg",
                UserName = "Admin",
                Password = "Admin",
                EmailAddress = "Admin@Admin.Admin",
                Roles = new List<UserRole>(),
                AuthorLikes = new List<AuthorLike>(),
                AuthorComments = new List<AuthorComment>(),
                BookComments = new List<BookComment>(),
                BookCommentLikes = new List<BookCommentLike>(),
                AuthorCommentLikes = new List<AuthorCommentLike>(),
                GenreLikes = new List<GenreLike>(),
                BookLikes = new List<BookLike>(),
                BookProcesses = new List<BookProcess>(),
                BookAssessments = new List<BookAssessment>()
            });
            await _applicationContext.SaveChangesAsync();
            await _applicationContext.UserRoles.AddAsync(new UserRole
            {
                Id = Guid.NewGuid().ToString(),
                RoleId = AdminRoleId,
                UserId = AdminId,
                User = _applicationContext.Users.FindAsync(AdminId).Result,
                Role = _applicationContext.Roles.FindAsync(AdminRoleId).Result
            });
            await _applicationContext.SaveChangesAsync();
        }

        public async Task CreateUsers()
        {
            for (int i = 1; i <= 20; i++)
            {
                await _applicationContext.Users.AddAsync(new User
                {
                    Id = Guid.NewGuid().ToString(),
                    ImageUrl = @"https://sun9-41.userapi.com/_IyAehlXuufxbG-3II5NR-9OLnyTU3aiJJvbkg/WNeUHTuNdr4.jpg",
                    UserName = $"UserName_{i}",
                    Password = $"Password_{i}",
                    EmailAddress = $"Email@Email.Email_{i}",
                    Roles = new List<UserRole>(),
                    AuthorLikes = new List<AuthorLike>(),
                    AuthorComments = new List<AuthorComment>(),
                    BookComments = new List<BookComment>(),
                    BookCommentLikes = new List<BookCommentLike>(),
                    AuthorCommentLikes = new List<AuthorCommentLike>(),
                    GenreLikes = new List<GenreLike>(),
                    BookLikes = new List<BookLike>(),
                    BookProcesses = new List<BookProcess>(),
                    BookAssessments = new List<BookAssessment>()
                });
                await _applicationContext.SaveChangesAsync();
                await _applicationContext.UserRoles.AddAsync(new UserRole
                {
                    Id = Guid.NewGuid().ToString(),
                    RoleId = UserRoleId,
                    UserId = _applicationContext.Users.FirstOrDefaultAsync(w => string.Equals(w.UserName, $"UserName_{i}")).Result.Id,
                    User = _applicationContext.Users.FirstOrDefaultAsync(w => string.Equals(w.UserName, $"UserName_{i}")).Result,
                    Role = _applicationContext.Roles.FindAsync(UserRoleId).Result
                });
                await _applicationContext.SaveChangesAsync();
            }
        }

        public async Task CreateGenres()
        {
            for (int i = 1; i <= 10; i++)
            {
                await _applicationContext.Genres.AddAsync(new Genre
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = $"GenreName_{i}",
                    ImageUrl = @"https://sun9-12.userapi.com/bnIaOu67bRAxJ6KzsJhMGV9H2GRPDgOZAxLODg/TNA03dxRUFY.jpg",
                    Books = new List<GenreBook>(),
                    Likes = new List<GenreLike>()
                });
                await _applicationContext.SaveChangesAsync();
            }
        }

        public async Task CreateAuthors()
        {
            for (int i = 1; i <= 10; i++)
            {
                await _applicationContext.Authors.AddAsync(new Author
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = $"FirstName_{i}",
                    SecondName = $"LastName_{i}",
                    ImageUrl = @"https://sun9-41.userapi.com/sE3n6k5fl1vtOWT5eSm9KbmxFqXmcDqVxN7sZQ/QiMkZnfTQG0.jpg",
                    AuthorBooks = new List<AuthorBook>(),
                    AuthorLikes = new List<AuthorLike>(),
                    AuthorComments = new List<AuthorComment>()
                });
                await _applicationContext.SaveChangesAsync();
            }
        }

        public async Task CreateBooks()
        {
            var random = new Random();
            for (int i = 1; i <= 100; i++)
            {
                _applicationContext.Books.Add(new Book
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = $"BookName_{i}",
                    Year = random.Next(1920, 2021),
                    ImageIrl = @"https://sun9-6.userapi.com/ikd_DM0KBViiaVlN_HKtd_ljpwy_NwJAlC-yZA/oH0RF4dUPJQ.jpg",
                    BookUrl = @"https://vk.com/doc133215086_551927410?hash=5aee1ff3dd52c3c621&dl=114e0458af8e63974c",
                    Description =
                        "Description Description Description Description Description Description Description" +
                        "Description Description Description Description Description Description Description" +
                        "Description Description Description Description Description Description Description",
                    Authors = new List<AuthorBook>(),
                    Genres = new List<GenreBook>(),
                    Likes = new List<BookLike>(),
                    Assessments = new List<BookAssessment>(),
                    Comments = new List<BookComment>(),
                    Processes = new List<BookProcess>()
                });
                await _applicationContext.SaveChangesAsync();
            }
        }

        public async Task CreateDependencyAuthorBook()
        {
            int k = 1;
            for (int i = 1; i <= 10; i++)
            {
                var author = await _applicationContext.Authors.FirstOrDefaultAsync(w =>
                        string.Equals(w.FirstName, $"FirstName_{i}"));
                for (int j = k; j <= 10*i; j++)
                {
                    var book = await _applicationContext.Books.FirstOrDefaultAsync(w =>
                        string.Equals(w.Name, $"BookName_{j}"));
                    await _applicationContext.AuthorBooks.AddAsync(new AuthorBook
                    {
                        Id = Guid.NewGuid().ToString(),
                        AuthorId = author.Id,
                        BookId = book.Id,
                        Author = author,
                        Book = book
                    });
                    await _applicationContext.SaveChangesAsync();
                }
                k = i * 10;
            }
        }

        public async Task CreateDependencyGenreBook()
        {
            int k = 1;
            for (int i = 1; i <= 10; i++)
            {
                var genre = await _applicationContext.Genres.FirstOrDefaultAsync(w =>
                    string.Equals(w.Name, $"GenreName_{i}"));
                for (int j = k; j <= 10*i; j++)
                {
                    var book = await _applicationContext.Books.FirstOrDefaultAsync(w =>
                        string.Equals(w.Name, $"BookName_{j}"));
                    await _applicationContext.GenreBooks.AddAsync(new GenreBook
                    {
                        Id = Guid.NewGuid().ToString(),
                        BookId = book.Id,
                        Book = book,
                        GenreId = genre.Id,
                        Genre = genre
                    });
                    await _applicationContext.SaveChangesAsync();
                }
                k = i * 10;
            }
        }

        public async Task CreateBookLike()
        {
            var users = await _applicationContext.Users.ToListAsync();
            int k = 1;
            foreach (var user in users)
            {
                for (int i = k; i <= 4+k; i++)
                {
                    var book = await _applicationContext.Books.FirstOrDefaultAsync(w =>
                        string.Equals(w.Name, $"BookName_{i}"));
                    await _applicationContext.BookLikes.AddAsync(new BookLike
                    {
                        Id = Guid.NewGuid().ToString(),
                        Book = book,
                        User = user,
                        UserId = user.Id,
                        BookId = book.Id
                    });
                    await _applicationContext.SaveChangesAsync();
                }
                k += 5;
            }
        }

        public async Task CreateAuthorLike()
        {
            var users = await _applicationContext.Users.ToListAsync();
            int k = 1;
            foreach (var user in users)
            {
                for (int i = k; i <= 4+k; i++)
                {
                    var author = await _applicationContext.Authors.FirstOrDefaultAsync(w =>
                            string.Equals(w.FirstName, $"FirstName_{i}"));
                    await _applicationContext.AuthorLikes.AddAsync(new AuthorLike
                    {
                        Id = Guid.NewGuid().ToString(),
                        User = user,
                        Author = author,
                        AuthorId = author.Id,
                        UserId = user.Id
                    });
                    await _applicationContext.SaveChangesAsync();
                }
                k += 5;
                if (k == 11) k = 1;
            }
        }

        public async Task CreateGenreLike()
        {
            var users = await _applicationContext.Users.ToListAsync();
            int k = 1;
            foreach (var user in users)
            {
                for (int i = k; i <= 4 + k; i++)
                {
                    var genre = await _applicationContext.Genres.FirstOrDefaultAsync(w =>
                        string.Equals(w.Name, $"GenreName_{i}"));
                    await _applicationContext.GenreLikes.AddAsync(new GenreLike
                    {
                        Id = Guid.NewGuid().ToString(),
                        User = user,
                        Genre = genre,
                        GenreId = genre.Id,
                        UserId = user.Id
                    });
                    await _applicationContext.SaveChangesAsync();
                }
                k += 5;
                if (k == 11) k = 1;
            }
        }

        public async Task CreateCommentBook()
        {
            var users = await _applicationContext.Users.ToListAsync();
            var books = await _applicationContext.Books.ToListAsync();
            foreach (var user in users)
            {
                foreach (var book in books)
                {
                    await _applicationContext.BookComments.AddAsync(new BookComment
                    {
                        Id = Guid.NewGuid().ToString(),
                        Book = book,
                        User = user,
                        UserId = user.Id,
                        BookId = book.Id,
                        DateTime = DateTime.Now,
                        Comment = "Comment Comment Comment Comment Comment Comment Comment Comment Comment" +
                                  "Comment Comment Comment Comment Comment Comment Comment Comment Comment" +
                                  "Comment Comment Comment Comment Comment Comment Comment Comment Comment",
                        BookCommentLikes = new List<BookCommentLike>()
                    });
                    await _applicationContext.SaveChangesAsync();
                }
            }
        }

        public async Task CreateCommentAuthor()
        {
            var users = await _applicationContext.Users.ToListAsync();
            var authors = await _applicationContext.Authors.ToListAsync();
            foreach (var user in users)
            {
                foreach (var author in authors)
                {
                    await _applicationContext.AuthorComments.AddAsync(new AuthorComment
                    {
                        Id = Guid.NewGuid().ToString(),
                        User = user,
                        Author = author,
                        AuthorId = author.Id,
                        UserId = user.Id,
                        DateTime = DateTime.Now,
                        Comment = "Comment Comment Comment Comment Comment Comment Comment Comment Comment" +
                                  "Comment Comment Comment Comment Comment Comment Comment Comment Comment" +
                                  "Comment Comment Comment Comment Comment Comment Comment Comment Comment",
                        AuthorCommentLikes = new List<AuthorCommentLike>()
                    });
                    await _applicationContext.SaveChangesAsync();
                }
            }
        }

        public async Task CreateAssessment()
        {
            var random = new Random();
            var users = await _applicationContext.Users.ToListAsync();
            var books = await _applicationContext.Books.ToListAsync();
            foreach (var user in users)
            {
                foreach (var book in books)
                {
                    await _applicationContext.BookAssessments.AddAsync(new BookAssessment
                    {
                        Id = Guid.NewGuid().ToString(),
                        Book = book,
                        User = user,
                        Count = random.Next(3, 6),
                        UserId = user.Id,
                        BookId = book.Id
                    });
                    await _applicationContext.SaveChangesAsync();
                }
            }
        }

        public async Task CreateProcess()
        {
            var random = new Random();
            var users = await _applicationContext.Users.ToListAsync();
            foreach (var user in users)
            {
                for (int i = random.Next(5, 19); i <= 20; i++)
                {
                    var book = await _applicationContext.Books.FirstOrDefaultAsync(w =>
                        string.Equals(w.Name, $"BookName_{i}"));
                    await _applicationContext.BookProcesses.AddAsync(new BookProcess
                    {
                        Id = Guid.NewGuid().ToString(),
                        Book = book,
                        User = user,
                        Process = 1,
                        UserId = user.Id,
                        BookId = book.Id
                    });
                    await _applicationContext.SaveChangesAsync();
                }
                for (int i = random.Next(25, 39); i <= 40; i++)
                {
                    var book = await _applicationContext.Books.FirstOrDefaultAsync(w =>
                        string.Equals(w.Name, $"BookName_{i}"));
                    await _applicationContext.BookProcesses.AddAsync(new BookProcess
                    {
                        Id = Guid.NewGuid().ToString(),
                        Book = book,
                        User = user,
                        Process = 2,
                        UserId = user.Id,
                        BookId = book.Id
                    });
                    await _applicationContext.SaveChangesAsync();
                }
                for (int i = random.Next(45, 59); i <= 60; i++)
                {
                    var book = await _applicationContext.Books.FirstOrDefaultAsync(w =>
                        string.Equals(w.Name, $"BookName_{i}"));
                    await _applicationContext.BookProcesses.AddAsync(new BookProcess
                    {
                        Id = Guid.NewGuid().ToString(),
                        Book = book,
                        User = user,
                        Process = 3,
                        UserId = user.Id,
                        BookId = book.Id
                    });
                    await _applicationContext.SaveChangesAsync();
                }
                for (int i = random.Next(65, 79); i <= 80; i++)
                {
                    var book = await _applicationContext.Books.FirstOrDefaultAsync(w =>
                        string.Equals(w.Name, $"BookName_{i}"));
                    await _applicationContext.BookProcesses.AddAsync(new BookProcess
                    {
                        Id = Guid.NewGuid().ToString(),
                        Book = book,
                        User = user,
                        Process = 4,
                        UserId = user.Id,
                        BookId = book.Id
                    });
                    await _applicationContext.SaveChangesAsync();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _applicationContext.Dispose();
            }
            _disposed = true;
        }
    }
}
