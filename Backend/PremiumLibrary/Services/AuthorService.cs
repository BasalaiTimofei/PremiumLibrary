using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Castle.Core.Internal;
using PremiumLibrary.Exceptions;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Interfaces.Services;
using PremiumLibrary.Models.DataBaseModels.AuthorFolder;
using PremiumLibrary.Models.ViewModels.Author;

namespace PremiumLibrary.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private bool _disposed;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<List<AuthorListingModel>> GetAll(string userId)
        {
            var authors = await _authorRepository.GetAll();
            if (authors == null) throw new ServerException("Сервер вернул null");
            var mapping = _mapper.Map<List<AuthorListingModel>>(authors);
            foreach (var authorListingModel in mapping)
                authorListingModel.Like = await IsLike(authorListingModel.Id, userId);
            return mapping;
        }

        public async Task<List<AuthorListingModel>> GetByBook(string bookId, string userId)
        {
            if (bookId.IsNullOrEmpty()) throw new CustomException("bookId = null");
            var authors = await _authorRepository.GetAll();
            if (authors == null) throw new ServerException("Сервер вернул null");
            var result = authors.Where(w => w.AuthorBooks.Any(e => string.Equals(e.BookId, bookId)));
            if (!result.Any()) throw new CustomException("У данной книги нет авторов");
            var mapping = _mapper.Map<List<AuthorListingModel>>(result);
            foreach (var authorListingModel in mapping)
                authorListingModel.Like = await IsLike(authorListingModel.Id, userId);
            return mapping;
        }

        public async Task<List<AuthorListingModel>> GetByLike(string userId)
        {
            if (userId.IsNullOrEmpty()) throw new CustomException("userId = null");
            var authors = await _authorRepository.GetAll();
            if (authors == null) throw new ServerException("Сервер вернул null");
            var result = authors.Where(w => w.AuthorLikes.Any(e => string.Equals(e.UserId, userId)));
            if (!result.Any()) throw new CustomException("Нет выбранных авторов");
            var mapping = _mapper.Map<List<AuthorListingModel>>(result);
            foreach (var authorListingModel in mapping)
                authorListingModel.Like = true;
            return mapping;
        }

        public async Task<AuthorListingModel> GetById(string authorId, string userId)
        {
            if (authorId.IsNullOrEmpty()) throw new CustomException("authorId = null");
            var author = await _authorRepository.GetById(authorId);
            if (author == null) throw new CustomException("Автор не найден");
            var mapping = _mapper.Map<AuthorListingModel>(author);
            mapping.Like = await IsLike(mapping.Id, userId);
            return mapping;
        }

        public async Task<AuthorListingModel> GetByName(string authorName, string userId)
        {
            if (authorName.IsNullOrEmpty()) throw new CustomException("authorName = null");
            var authors = await _authorRepository.GetAll();
            if (authors == null) throw new ServerException("Сервер вернул null");
            var result = authors.FirstOrDefault(w => string.Equals($"{w.FirstName} {w.SecondName}", authorName));
            if (result == null) throw new CustomException("Автор не найден");
            var mapping = _mapper.Map<AuthorListingModel>(result);
            mapping.Like = await IsLike(mapping.Id, userId);
            return mapping;
        }

        public async Task Create(AuthorCreateModel authorCreateModel)
        {
            if (authorCreateModel == null 
                || authorCreateModel.FirstName.IsNullOrEmpty() 
                || authorCreateModel.SecondName.IsNullOrEmpty())
                throw new CustomException("Некоректные данные");
            var authors = await _authorRepository.GetAll();
            if (authors == null) throw new ServerException("Сервер вернул null");
            if (authors.Any(w => 
                string.Equals(w.FirstName, authorCreateModel.FirstName) 
                && string.Equals(w.SecondName, authorCreateModel.SecondName)))
                throw new CustomException("Такой автор уже существует");
            var result = await _authorRepository.Add(_mapper.Map<Author>(authorCreateModel));
            if (result == null) throw new ServerException("Ошибка в БД");
        }

        public Task Update()
        {
            throw new NotImplementedException();
        }

        public async Task Delete(string authorId)
        {
            if (authorId.IsNullOrEmpty()) throw new CustomException("authorId = null");
            var author = await _authorRepository.GetById(authorId);
            if (author == null) throw new CustomException("Автор не найден");
            await _authorRepository.Delete(author);
        }

        private async Task<bool> IsLike(string authorId, string userId)
        {
            var result = await _authorRepository.GetById(authorId);
            return result.AuthorLikes.Any(w => string.Equals(w.UserId, userId));
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