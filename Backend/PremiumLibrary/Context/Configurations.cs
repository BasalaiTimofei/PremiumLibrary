using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PremiumLibrary.Models.DataBaseModels;
using PremiumLibrary.Models.DataBaseModels.AuthorFolder;
using PremiumLibrary.Models.DataBaseModels.BookFolder;
using PremiumLibrary.Models.DataBaseModels.GenreFolder;

namespace PremiumLibrary.Context
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasMany(w => w.Roles)
                .WithOne(w => w.User);
            builder.HasMany(w => w.AuthorLikes)
                .WithOne(w => w.User);
            builder.HasMany(w => w.AuthorComments)
                .WithOne(w => w.User);
            builder.HasMany(w => w.AuthorCommentLikes)
                .WithOne(w => w.User);
            builder.HasMany(w => w.BookAssessments)
                .WithOne(w => w.User);
            builder.HasMany(w => w.BookComments)
                .WithOne(w => w.User);
            builder.HasMany(w => w.BookCommentLikes)
                .WithOne(w => w.User);
            builder.HasMany(w => w.BookLikes)
                .WithOne(w => w.User);
            builder.HasMany(w => w.BookProcesses)
                .WithOne(w => w.User);
            builder.HasMany(w => w.GenreLikes)
                .WithOne(w => w.User);

            builder.Property(w => w.EmailAddress).IsRequired().HasMaxLength(50);
            builder.Property(w => w.Password).IsRequired().IsRequired().HasMaxLength(50);
            builder.Property(w => w.UserName).IsRequired().HasMaxLength(20);
            builder.Property(w => w.ImageUrl).IsRequired().HasMaxLength(150);
        }
    }

    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasMany(w => w.Users)
                .WithOne(w => w.Role);

            builder.Property(w => w.Name).IsRequired().HasMaxLength(20);
        }
    }

    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasOne(w => w.User)
                .WithMany(w => w.Roles)
                .HasForeignKey(w => w.UserId);
            builder.HasOne(w => w.Role)
                .WithMany(w => w.Users)
                .HasForeignKey(w => w.RoleId);
        }
    }

    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasMany(w => w.AuthorLikes)
                .WithOne(w => w.Author);
            builder.HasMany(w => w.AuthorComments)
                .WithOne(w => w.Author);
            builder.HasMany(w => w.AuthorBooks)
                .WithOne(w => w.Author);

            builder.Property(w => w.FirstName).IsRequired().HasMaxLength(20);
            builder.Property(w => w.SecondName).IsRequired().HasMaxLength(25);
            builder.Property(w => w.ImageUrl).IsRequired().HasMaxLength(150);
        }
    }

    public class AuthorLikeConfiguration : IEntityTypeConfiguration<AuthorLike>
    {
        public void Configure(EntityTypeBuilder<AuthorLike> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasOne(w => w.Author)
                .WithMany(w => w.AuthorLikes)
                .HasForeignKey(w => w.AuthorId);
            builder.HasOne(w => w.User)
                .WithMany(w => w.AuthorLikes)
                .HasForeignKey(w => w.UserId);
        }
    }

    public class AuthorCommentConfiguration : IEntityTypeConfiguration<AuthorComment>
    {
        public void Configure(EntityTypeBuilder<AuthorComment> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasOne(w => w.Author)
                .WithMany(w => w.AuthorComments)
                .HasForeignKey(w => w.AuthorId);
            builder.HasOne(w => w.User)
                .WithMany(w => w.AuthorComments)
                .HasForeignKey(w => w.UserId);
            builder.HasMany(w => w.AuthorCommentLikes)
                .WithOne(w => w.AuthorComment);

            builder.Property(w => w.Comment).IsRequired().HasMaxLength(1000);
            builder.Property(w => w.DateTime).IsRequired();
        }
    }

    public class AuthorBookConfiguration : IEntityTypeConfiguration<AuthorBook>
    {
        public void Configure(EntityTypeBuilder<AuthorBook> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasOne(w => w.Author)
                .WithMany(w => w.AuthorBooks)
                .HasForeignKey(w => w.AuthorId);
            builder.HasOne(w => w.Book)
                .WithMany(w => w.Authors)
                .HasForeignKey(w => w.BookId);
        }
    }

    public class AuthorCommentLikeConfiguration : IEntityTypeConfiguration<AuthorCommentLike>
    {
        public void Configure(EntityTypeBuilder<AuthorCommentLike> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasOne(w => w.AuthorComment)
                .WithMany(w => w.AuthorCommentLikes)
                .HasForeignKey(w => w.AuthorCommentId);
            builder.HasOne(w => w.User)
                .WithMany(w => w.AuthorCommentLikes)
                .HasForeignKey(w => w.UserId);
        }
    }

    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasMany(w => w.Assessments)
                .WithOne(w => w.Book);
            builder.HasMany(w => w.Genres)
                .WithOne(w => w.Book);
            builder.HasMany(w => w.Authors)
                .WithOne(w => w.Book);
            builder.HasMany(w => w.Comments)
                .WithOne(w => w.Book);
            builder.HasMany(w => w.Likes)
                .WithOne(w => w.Book);
            builder.HasMany(w => w.Processes)
                .WithOne(w => w.Book);

            builder.Property(w => w.Name).IsRequired().HasMaxLength(50);
            builder.Property(w => w.Description).IsRequired().HasMaxLength(1000);
            builder.Property(w => w.ImageIrl).IsRequired().HasMaxLength(150);
            builder.Property(w => w.BookUrl).IsRequired().HasMaxLength(150);
            builder.Property(w => w.Year).IsRequired();
        }
    }

    public class BookAssessmentConfiguration : IEntityTypeConfiguration<BookAssessment>
    {
        public void Configure(EntityTypeBuilder<BookAssessment> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasOne(w => w.Book)
                .WithMany(w => w.Assessments)
                .HasForeignKey(w => w.BookId);
            builder.HasOne(w => w.User)
                .WithMany(w => w.BookAssessments)
                .HasForeignKey(w => w.UserId);

            builder.Property(w => w.Count).IsRequired();
        }
    }

    public class GenreBookConfiguration : IEntityTypeConfiguration<GenreBook>
    {
        public void Configure(EntityTypeBuilder<GenreBook> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasOne(w => w.Genre)
                .WithMany(w => w.Books)
                .HasForeignKey(w => w.GenreId);
            builder.HasOne(w => w.Book)
                .WithMany(w => w.Genres)
                .HasForeignKey(w => w.BookId);
        }
    }

    public class BookCommentConfiguration : IEntityTypeConfiguration<BookComment>
    {
        public void Configure(EntityTypeBuilder<BookComment> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasOne(w => w.User)
                .WithMany(w => w.BookComments)
                .HasForeignKey(w => w.UserId);
            builder.HasOne(w => w.Book)
                .WithMany(w => w.Comments)
                .HasForeignKey(w => w.BookId);
            builder.HasMany(w => w.BookCommentLikes)
                .WithOne(w => w.BookComment);

            builder.Property(w => w.Comment).IsRequired().HasMaxLength(1000);
            builder.Property(w => w.DateTime).IsRequired();
        }
    }

    public class BookCommentLikeConfiguration : IEntityTypeConfiguration<BookCommentLike>
    {
        public void Configure(EntityTypeBuilder<BookCommentLike> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasOne(w => w.BookComment)
                .WithMany(w => w.BookCommentLikes)
                .HasForeignKey(w => w.BookCommentId);
            builder.HasOne(w => w.User)
                .WithMany(w => w.BookCommentLikes)
                .HasForeignKey(w => w.UserId);
        }
    }

    public class BookLikeConfiguration : IEntityTypeConfiguration<BookLike>
    {
        public void Configure(EntityTypeBuilder<BookLike> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasOne(w => w.Book)
                .WithMany(w => w.Likes)
                .HasForeignKey(w => w.BookId);
            builder.HasOne(w => w.User)
                .WithMany(w => w.BookLikes)
                .HasForeignKey(w => w.UserId);
        }
    }

    public class BookProcessConfiguration : IEntityTypeConfiguration<BookProcess>
    {
        public void Configure(EntityTypeBuilder<BookProcess> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasOne(w => w.Book)
                .WithMany(w => w.Processes)
                .HasForeignKey(w => w.BookId);
            builder.HasOne(w => w.User)
                .WithMany(w => w.BookProcesses)
                .HasForeignKey(w => w.UserId);
        }
    }

    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasMany(w => w.Likes)
                .WithOne(w => w.Genre);
            builder.HasMany(w => w.Books)
                .WithOne(w => w.Genre);

            builder.Property(w => w.Name).IsRequired().HasMaxLength(50);
            builder.Property(w => w.ImageUrl).IsRequired().HasMaxLength(150);
        }
    }

    public class GenreLikeConfiguration : IEntityTypeConfiguration<GenreLike>
    {
        public void Configure(EntityTypeBuilder<GenreLike> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasOne(w => w.Genre)
                .WithMany(w => w.Likes)
                .HasForeignKey(w => w.GenreId);
            builder.HasOne(w => w.User)
                .WithMany(w => w.GenreLikes)
                .HasForeignKey(w => w.UserId);
        }
    }

}