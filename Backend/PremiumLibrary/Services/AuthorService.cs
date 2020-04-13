using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Interfaces.Services;
using PremiumLibrary.Models.DataBaseModels.Book;
using PremiumLibrary.Models.ViewModels.Author;

namespace PremiumLibrary.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private bool _disposed;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper, IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task Create(AuthorCreateModel authorCreateModel)
        {
            var author = await _authorRepository.Add(_mapper.Map<Author>(authorCreateModel));

            await AddAuthorBooks(author.Id, authorCreateModel.BooksId);
        }

        public async Task AddAuthorBooks(string authorId, List<string> booksId)
        {
            var author = await _authorRepository.GetById(authorId);
            var booksDb = await _bookRepository.GetAll();

            foreach (var item in booksId)
            {
                var book = booksDb.FirstOrDefault(w => string.Equals(w.Id, item));

                if (book == null || book.Authors.Any(w => string.Equals(w.AuthorId, authorId))) continue;

                await _authorRepository.AddAuthorBooks(author, book);
            }
        }

        public Task<AuthorListingModel> Update(AuthorCreateModel authorCreateModel)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(string authorId)
        {
            var author = await _authorRepository.GetById(authorId);

            await _authorRepository.Delete(author);
        }

        public async Task DeleteAuthorBook(string authorId, string bookId)
        {
            var author = await _authorRepository.GetById(authorId);
            var book = await _bookRepository.GetById(bookId);

            await _authorRepository.DeleteAuthorBooks(author, book);
        }

        public async Task<AuthorListingModel> GetById(string authorId, string userId)
        {
            var authors = await _authorRepository.GetAll();
            var author = await _authorRepository.GetById(authorId);

            var mappingAuthors = _mapper.Map<AuthorListingModel>(author);

            mappingAuthors.Like = authors.FirstOrDefault(w => string.Equals(w.Id, mappingAuthors.Id))
                .AuthorLikes.Any(w => string.Equals(w.UserId, userId));

            return mappingAuthors;
        }

        public async Task<AuthorListingModel> GetByName(string authorName, string userId)
        {
            var authors = await _authorRepository.GetAll();
            var author = authors.FirstOrDefault(w => string.Equals($"{w.SecondName} {w.FirstName}", authorName));

            var mappingAuthors = _mapper.Map<AuthorListingModel>(author);

            mappingAuthors.Like = authors.FirstOrDefault(w => string.Equals(w.Id, mappingAuthors.Id))
                .AuthorLikes.Any(w => string.Equals(w.UserId,userId));

            return mappingAuthors;
        }

        public async Task<List<AuthorListingModel>> GetAll(string userId)
        {
            var authors = await _authorRepository.GetAll();

            var mappingAuthors = _mapper.Map<List<AuthorListingModel>>(authors);

            foreach (var author in mappingAuthors)
            {
                author.Like = authors.FirstOrDefault(w => string.Equals(w.Id, author.Id)).AuthorLikes
                    .Any(w => string.Equals(w.UserId, userId));
            }

            return mappingAuthors;
        }

        public async Task<List<AuthorListingModel>> GetByBook(string bookId, string userId)
        {
            var book = await _bookRepository.GetById(bookId);
            var authors = book.Authors.Select(w => w.Author);

            var mappingAuthors = _mapper.Map<List<AuthorListingModel>>(authors);

            foreach (var author in mappingAuthors)
            {
                author.Like = authors.FirstOrDefault(w => string.Equals(w.Id, author.Id)).AuthorLikes
                    .Any(w => string.Equals(w.UserId, userId));
            }

            return mappingAuthors;
        }

        private AuthorListingModel Liked(AuthorListingModel authorListingModel, List<Author> authors, string userId)
        {
            authorListingModel.Like = authors.FirstOrDefault(
                    w => string.Equals(w.Id, authorListingModel.Id))
                .AuthorLikes.Any(w => string.Equals(w.UserId, userId));
            return authorListingModel;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _authorRepository?.Dispose();
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        ~AuthorService()
        {
            Dispose();
        }
    }
}