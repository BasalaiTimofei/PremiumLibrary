using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Castle.Core.Internal;
using PremiumLibrary.Exceptions;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Interfaces.Services;
using PremiumLibrary.Models.DataBaseModels.GenreFolder;
using PremiumLibrary.Models.ViewModels.Genre;

namespace PremiumLibrary.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private bool _disposed;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<List<GenreListingModel>> GetAll(string userId)
        {
            var result = await _genreRepository.GetAll();
            if (result == null) throw new ServerException("Сервер вернул null");
            var mapping = _mapper.Map<List<GenreListingModel>>(result);
            foreach (var genreListingModel in mapping)
                genreListingModel.Like = await IsLike(genreListingModel.Id, userId);
            return mapping;
        }

        public async Task<List<GenreListingModel>> GetByBook(string bookId, string userId)
        {
            if (bookId.IsNullOrEmpty()) throw new CustomException("bookId = null");
            var genres = await _genreRepository.GetAll();
            if (genres == null) throw new ServerException("Сервер вернул null");
            var result = genres.Where(w => w.Books.Any(e => string.Equals(e.BookId, bookId)));
            if (!result.Any()) throw new CustomException("По такой книги нет жанров");
            var mapping = _mapper.Map<List<GenreListingModel>>(result);
            foreach (var genreListingModel in mapping)
                genreListingModel.Like = await IsLike(genreListingModel.Id, userId);
            return mapping;
        }

        public async Task<List<GenreListingModel>> GetByLike(string userId)
        {
            if (userId.IsNullOrEmpty()) throw new CustomException("userId = null");
            var genres = await _genreRepository.GetAll();
            if (genres == null) throw new ServerException("Сервер вернул null");
            var result = genres.Where(w => w.Likes.Any(e => string.Equals(e.UserId, userId)));
            if (!result.Any()) throw new CustomException("Нет избранных жанров");
            var mapping = _mapper.Map<List<GenreListingModel>>(result);
            foreach (var genreListingModel in mapping)
                genreListingModel.Like = true;
            return mapping;
        }

        public async Task<GenreListingModel> GetById(string genreId, string userId)
        {
            if (genreId.IsNullOrEmpty()) throw new CustomException("genreId = null");
            var result = await _genreRepository.GetById(genreId);
            if (result == null) throw new CustomException("Жанра с таким id нет");
            var mapping = _mapper.Map<GenreListingModel>(result);
            mapping.Like = await IsLike(result.Id, userId);
            return mapping;
        }

        public async Task<GenreListingModel> GetByName(string genreName, string userId)
        {
            if (genreName.IsNullOrEmpty()) throw new CustomException("genreName = null");
            var genres = await _genreRepository.GetAll();
            if (genres == null) throw new ServerException("Сервер вернул null");
            var result = genres.FirstOrDefault(w => string.Equals(w.Name, genreName));
            if (result == null) throw new CustomException("Жанра с таким Name нет");
            var mapping = _mapper.Map<GenreListingModel>(result);
            mapping.Like = await IsLike(result.Id, userId);
            return mapping;
        }

        public async Task<string> Create(GenreCreateModel genreCreateModel)
        {
            if (genreCreateModel == null || genreCreateModel.Name.IsNullOrEmpty())
                throw new CustomException("Некоректные данные");
            var genres = await _genreRepository.GetAll();
            if (genres == null) throw new ServerException("Сервер вернул null");
            if (genres.Any(w => string.Equals(w.Name, genreCreateModel.Name)))
                throw new CustomException("Жанр с таким именем уже существует");
            var result = await _genreRepository.Add(_mapper.Map<Genre>(genreCreateModel));
            if (result == null) throw new ServerException("Ошибка сервера при добавлении");
            return result.Id;
        }

        public Task Update()
        {
            throw new NotImplementedException();
        }

        public async Task Delete(string genreId)
        {
            if (genreId.IsNullOrEmpty()) throw new CustomException("genreId = null");
            var result = await _genreRepository.GetById(genreId);
            if (result == null) throw new CustomException("Жанра с таким id нет");
            await _genreRepository.Delete(result);
        }

        private async Task<bool> IsLike(string genreId, string userId)
        {
            var genre = await _genreRepository.GetById(genreId);
            return genre.Likes.Any(w => string.Equals(w.UserId, userId));
        }

        public void Dispose()
        {
            if (_disposed) return;
            _genreRepository?.Dispose();
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        ~GenreService()
        {
            Dispose();
        }
    }
}