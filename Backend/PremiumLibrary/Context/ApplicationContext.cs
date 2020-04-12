using Microsoft.EntityFrameworkCore;
using PremiumLibrary.Models.DataBaseModels;
using PremiumLibrary.Models.DataBaseModels.Book;

namespace PremiumLibrary.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<GenreBook> GenreBooks { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        
        public DbSet<AuthorComment> AuthorComments { get; set; }
        public DbSet<BookComment> BookComments { get; set; }
        
        public DbSet<AuthorLike> AuthorLikes { get; set; }
        public DbSet<AuthorCommentLike> AuthorCommentLikes { get; set; }
        public DbSet<BookCommentLike> BookCommentLikes { get; set; }
        public DbSet<BookLike> BookLikes { get; set; }
         public DbSet<GenreLike> GenreLikes { get; set; }
      
        public DbSet<BookAssessment> BookAssessments { get; set; }
        public DbSet<BookProcess> BookProcesses { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorLikeConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorCommentConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorBookConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorCommentLikeConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new BookAssessmentConfiguration());
            modelBuilder.ApplyConfiguration(new GenreBookConfiguration());
            modelBuilder.ApplyConfiguration(new BookCommentConfiguration());
            modelBuilder.ApplyConfiguration(new BookCommentLikeConfiguration());
            modelBuilder.ApplyConfiguration(new BookLikeConfiguration());
            modelBuilder.ApplyConfiguration(new BookProcessConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new GenreLikeConfiguration());
        }
    }
}
