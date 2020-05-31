using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Castle.Core.Internal;
using PremiumLibrary.Exceptions;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Interfaces.Services;
using PremiumLibrary.Models.DataBaseModels.BookFolder;
using PremiumLibrary.Models.ViewModels.Book;

namespace PremiumLibrary.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private bool _disposed;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<BookListingModel>> GetAll(string userId)
        {
            var books = await _bookRepository.GetAll();
            if (books == null) throw new ServerException("Сервер вернул null");
            var mapping = _mapper.Map<List<BookListingModel>>(books);
            foreach (var bookListingModel in mapping)
            {
                bookListingModel.Like = await IsLike(bookListingModel.Id, userId);
                bookListingModel.Process = await GetProcess(bookListingModel.Id, userId);
            }
            return mapping;
        }

        public async Task<List<BookListingModel>> GetByAuthor(string authorId, string userId)
        {
            if (authorId.IsNullOrEmpty()) throw new CustomException("authorId = null");
            var books = await _bookRepository.GetAll();
            if (books == null) throw new ServerException("Сервер вернул null");
            var result = books.Where(w => w.Authors.Any(s => string.Equals(s.AuthorId, authorId)));
            if (!result.Any()) throw new CustomException("По такому автору нет книг");
            var mapping = _mapper.Map<List<BookListingModel>>(result);
            foreach (var bookListingModel in mapping)
            {
                bookListingModel.Like = await IsLike(bookListingModel.Id, userId);
                bookListingModel.Process = await GetProcess(bookListingModel.Id, userId);
            }
            return mapping;
        }

        public async Task<List<BookListingModel>> GetByGenre(string genreId, string userId)
        {
            if (genreId.IsNullOrEmpty()) throw new CustomException("genreId = null");
            var books = await _bookRepository.GetAll();
            if (books == null) throw new ServerException("Сервер вернул null");
            var result = books.Where(w => w.Genres.Any(s => string.Equals(s.GenreId, genreId)));
            if (!result.Any()) throw new CustomException("По такому жанру нет книг");
            var mapping = _mapper.Map<List<BookListingModel>>(result);
            foreach (var bookListingModel in mapping)
            {
                bookListingModel.Like = await IsLike(bookListingModel.Id, userId);
                bookListingModel.Process = await GetProcess(bookListingModel.Id, userId);
            }
            return mapping;
        }

        public async Task<List<BookListingModel>> GetByLikes(string userId)
        {
            if (userId.IsNullOrEmpty()) throw new CustomException("userId = null");
            var books = await _bookRepository.GetAll();
            if (books == null) throw new ServerException("Сервер вернул null");
            var result = books.Where(w => w.Likes.Any(s => string.Equals(s.UserId, userId)));
            if (!result.Any()) throw new CustomException("Нет избранных книг");
            var mapping = _mapper.Map<List<BookListingModel>>(result);
            foreach (var bookListingModel in mapping)
            {
                bookListingModel.Like = await IsLike(bookListingModel.Id, userId);
                bookListingModel.Process = await GetProcess(bookListingModel.Id, userId);
            }
            return mapping;
        }

        public async Task<BookListingModel> GetById(string bookId, string userId)
        {
            if (bookId.IsNullOrEmpty()) throw new CustomException("bookId = null");
            var result = await _bookRepository.GetById(bookId);
            if (result == null) throw new CustomException("По такому id нет книг");
            var mapping = _mapper.Map<BookListingModel>(result);
            mapping.Like = await IsLike(mapping.Id, userId);
            mapping.Process = await GetProcess(mapping.Id, userId);
            return mapping;
        }

        public async Task<BookListingModel> GetByName(string bookName, string userId)
        {
            if (bookName.IsNullOrEmpty()) throw new CustomException("bookName = null");
            var books = await _bookRepository.GetAll();
            if (books == null) throw new ServerException("Сервер вернул null");
            var result = books.FirstOrDefault(w => string.Equals(w.Name, bookName));
            if (result == null) throw new CustomException("По такому имени нет книг");
            var mapping = _mapper.Map<BookListingModel>(result);
            mapping.Like = await IsLike(mapping.Id, userId);
            mapping.Process = await GetProcess(mapping.Id, userId);
            return mapping;
        }

        public async Task<List<BookListingModel>> GetByProcess(int process, string userId)
        {
            var books = await _bookRepository.GetAll();
            if (books == null) throw new ServerException("Сервер вернул null");
            var result = books.Where(w => w.Processes.Any(s => s.Process == process));
            if (result == null) throw new CustomException("По такому имени нет книг");
            var mapping = _mapper.Map<List<BookListingModel>>(result);
            foreach (var bookListingModel in mapping)
            {
                bookListingModel.Like = true;
                bookListingModel.Process = await GetProcess(bookListingModel.Id, userId);
            }
            return mapping;
        }

        public async Task<string> AddBook(BookCreateModel bookCreateModel)
        {
            if (bookCreateModel == null || bookCreateModel.Name.IsNullOrEmpty() || bookCreateModel.Description.IsNullOrEmpty())
                throw new CustomException("Некоректные данные");
            var books = await _bookRepository.GetAll();
            if (books == null) throw new ServerException("Сервер вернул null");
            if (books.Any(w => string.Equals(w.Name, bookCreateModel.Name))) 
                throw new CustomException("Книга с таким именем уже есть");
            var result = await _bookRepository.Add(_mapper.Map<Book>(bookCreateModel));
            if (result == null) throw new ServerException("Сервер вернул null");
            return result.Id;
        }

        public Task Update()
        {
            throw new NotImplementedException();
        }

        public async Task Delete(string bookId)
        {
            if (bookId.IsNullOrEmpty()) throw new CustomException("bookId = null");
            var result = await _bookRepository.GetById(bookId);
            if (result == null) throw new CustomException("По такому id нет книг");
            await _bookRepository.Delete(result);
        }

        //TODO Проверка на юзера в контролере
        public async Task AddAssessment(string bookId, string userId, int assessment)
        {
            if (bookId.IsNullOrEmpty() || assessment > 10 || assessment < 1) 
                throw new CustomException("Некоректные данные");
            var book = await _bookRepository.GetById(bookId);
            if (book == null) throw new CustomException("По такому id нет книг");
            if (book.Assessments.Any(w => string.Equals(w.UserId, userId))) 
                throw new CustomException("Оценка уже стоит");
            await _bookRepository.AddAssessment(book, userId, assessment);
        }

        public async Task AddOrUpdateProcess(string bookId, string userId, int process)
        {
            if (bookId.IsNullOrEmpty() || process > 4 || process < 1)
                throw new CustomException("Некоректные данные");
            var book = await _bookRepository.GetById(bookId);
            if (book == null) throw new CustomException("По такому id нет книг");
            if (book.Processes.Any(w => string.Equals(w.UserId, userId)))
                await _bookRepository.UpdateProcess(book, userId, process);
            else 
                await _bookRepository.AddProcess(book, userId, process);
        }

        private async Task<bool> IsLike(string bookId, string userId)
        {
            var result = await _bookRepository.GetById(bookId);
            return result.Likes.Any(w => string.Equals(w.UserId, userId));
        }

        private async Task<int> GetProcess(string bookId, string userId)
        {
            var book = await _bookRepository.GetById(bookId);
            if (!book.Processes.Any(w => string.Equals(w.UserId, userId))) return 0;
            return book.Processes.FirstOrDefault(w => string.Equals(w.UserId, userId)).Process;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _bookRepository?.Dispose();
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        ~BookService()
        {
            Dispose();
        }
    }
}