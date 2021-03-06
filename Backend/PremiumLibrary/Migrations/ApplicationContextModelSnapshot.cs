﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PremiumLibrary.Context;

namespace PremiumLibrary.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.AuthorFolder.Author", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.AuthorFolder.AuthorBook", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BookId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("AuthorBooks");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.AuthorFolder.AuthorComment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("UserId");

                    b.ToTable("AuthorComments");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.AuthorFolder.AuthorCommentLike", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuthorCommentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorCommentId");

                    b.HasIndex("UserId");

                    b.ToTable("AuthorCommentLikes");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.AuthorFolder.AuthorLike", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("UserId");

                    b.ToTable("AuthorLikes");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.BookFolder.Book", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BookUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("ImageIrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.BookFolder.BookAssessment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BookId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookAssessments");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.BookFolder.BookComment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BookId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookComments");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.BookFolder.BookCommentLike", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BookCommentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BookCommentId");

                    b.HasIndex("UserId");

                    b.ToTable("BookCommentLikes");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.BookFolder.BookLike", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BookId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookLikes");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.BookFolder.BookProcess", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BookId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Process")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookProcesses");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.GenreFolder.Genre", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.GenreFolder.GenreBook", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BookId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GenreId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("GenreId");

                    b.ToTable("GenreBooks");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.GenreFolder.GenreLike", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GenreId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("UserId");

                    b.ToTable("GenreLikes");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.UserRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.AuthorFolder.AuthorBook", b =>
                {
                    b.HasOne("PremiumLibrary.Models.DataBaseModels.AuthorFolder.Author", "Author")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("AuthorId");

                    b.HasOne("PremiumLibrary.Models.DataBaseModels.BookFolder.Book", "Book")
                        .WithMany("Authors")
                        .HasForeignKey("BookId");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.AuthorFolder.AuthorComment", b =>
                {
                    b.HasOne("PremiumLibrary.Models.DataBaseModels.AuthorFolder.Author", "Author")
                        .WithMany("AuthorComments")
                        .HasForeignKey("AuthorId");

                    b.HasOne("PremiumLibrary.Models.DataBaseModels.User", "User")
                        .WithMany("AuthorComments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.AuthorFolder.AuthorCommentLike", b =>
                {
                    b.HasOne("PremiumLibrary.Models.DataBaseModels.AuthorFolder.AuthorComment", "AuthorComment")
                        .WithMany("AuthorCommentLikes")
                        .HasForeignKey("AuthorCommentId");

                    b.HasOne("PremiumLibrary.Models.DataBaseModels.User", "User")
                        .WithMany("AuthorCommentLikes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.AuthorFolder.AuthorLike", b =>
                {
                    b.HasOne("PremiumLibrary.Models.DataBaseModels.AuthorFolder.Author", "Author")
                        .WithMany("AuthorLikes")
                        .HasForeignKey("AuthorId");

                    b.HasOne("PremiumLibrary.Models.DataBaseModels.User", "User")
                        .WithMany("AuthorLikes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.BookFolder.BookAssessment", b =>
                {
                    b.HasOne("PremiumLibrary.Models.DataBaseModels.BookFolder.Book", "Book")
                        .WithMany("Assessments")
                        .HasForeignKey("BookId");

                    b.HasOne("PremiumLibrary.Models.DataBaseModels.User", "User")
                        .WithMany("BookAssessments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.BookFolder.BookComment", b =>
                {
                    b.HasOne("PremiumLibrary.Models.DataBaseModels.BookFolder.Book", "Book")
                        .WithMany("Comments")
                        .HasForeignKey("BookId");

                    b.HasOne("PremiumLibrary.Models.DataBaseModels.User", "User")
                        .WithMany("BookComments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.BookFolder.BookCommentLike", b =>
                {
                    b.HasOne("PremiumLibrary.Models.DataBaseModels.BookFolder.BookComment", "BookComment")
                        .WithMany("BookCommentLikes")
                        .HasForeignKey("BookCommentId");

                    b.HasOne("PremiumLibrary.Models.DataBaseModels.User", "User")
                        .WithMany("BookCommentLikes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.BookFolder.BookLike", b =>
                {
                    b.HasOne("PremiumLibrary.Models.DataBaseModels.BookFolder.Book", "Book")
                        .WithMany("Likes")
                        .HasForeignKey("BookId");

                    b.HasOne("PremiumLibrary.Models.DataBaseModels.User", "User")
                        .WithMany("BookLikes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.BookFolder.BookProcess", b =>
                {
                    b.HasOne("PremiumLibrary.Models.DataBaseModels.BookFolder.Book", "Book")
                        .WithMany("Processes")
                        .HasForeignKey("BookId");

                    b.HasOne("PremiumLibrary.Models.DataBaseModels.User", "User")
                        .WithMany("BookProcesses")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.GenreFolder.GenreBook", b =>
                {
                    b.HasOne("PremiumLibrary.Models.DataBaseModels.BookFolder.Book", "Book")
                        .WithMany("Genres")
                        .HasForeignKey("BookId");

                    b.HasOne("PremiumLibrary.Models.DataBaseModels.GenreFolder.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.GenreFolder.GenreLike", b =>
                {
                    b.HasOne("PremiumLibrary.Models.DataBaseModels.GenreFolder.Genre", "Genre")
                        .WithMany("Likes")
                        .HasForeignKey("GenreId");

                    b.HasOne("PremiumLibrary.Models.DataBaseModels.User", "User")
                        .WithMany("GenreLikes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("PremiumLibrary.Models.DataBaseModels.UserRole", b =>
                {
                    b.HasOne("PremiumLibrary.Models.DataBaseModels.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.HasOne("PremiumLibrary.Models.DataBaseModels.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
