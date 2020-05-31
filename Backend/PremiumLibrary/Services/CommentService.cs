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
using PremiumLibrary.Models.DataBaseModels.BookFolder;
using PremiumLibrary.Models.ViewModels.Comment;

namespace PremiumLibrary.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private bool _disposed;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<List<AuthorCommentListingModel>> GetAuthorComments(string authorId, string userId)
        {
            if (authorId.IsNullOrEmpty()) throw new CustomException("В поле authorId пусто");
            var comments = await _commentRepository.GetAuthorComments(authorId);
            if (comments == null) throw new CustomException("У этого автора нет коментариев");
            var mapping = _mapper.Map<List<AuthorCommentListingModel>>(comments);
            foreach (var authorCommentListingModel in mapping)
                authorCommentListingModel.Like = await IsLikeAuthorComment(authorCommentListingModel.Id, userId);
            return mapping;
        }

        public async Task<List<BookCommentListingModel>> GetBookComments(string bookId, string userId)
        {
            if (bookId.IsNullOrEmpty()) throw new CustomException("В поле bookId пусто");
            var book = await _commentRepository.GetBookComments(bookId);
            if (book == null) throw new CustomException("У этой книги нет коментариев");
            var mapping = _mapper.Map<List<BookCommentListingModel>>(book);
            foreach (var bookCommentListingModel in mapping)
                bookCommentListingModel.Like = await IsLikeBookComment(bookCommentListingModel.Id, userId);
            return mapping;
        }

        public async Task AddAuthorComment(AuthorCommentCreateModel authorCommentCreateModel, string userId)
        {
            if (authorCommentCreateModel == null 
                || authorCommentCreateModel.AuthorId.IsNullOrEmpty() 
                || authorCommentCreateModel.Comment.IsNullOrEmpty()) throw new CustomException("Некоректные данные");
            var model = _mapper.Map<AuthorComment>(authorCommentCreateModel);
            model.UserId = userId;
            await _commentRepository.AddAuthorComment(model);
        }

        public async Task AddBookComment(BookCommentCreateModel bookCommentCreateModel, string userId)
        {
            if (bookCommentCreateModel == null
                || bookCommentCreateModel.BookId.IsNullOrEmpty()
                || bookCommentCreateModel.Comment.IsNullOrEmpty()) throw new CustomException("Некоректные данные");
            var model = _mapper.Map<BookComment>(bookCommentCreateModel);
            model.UserId = userId;
            await _commentRepository.AddBookComment(model);
        }

        public async Task DeleteAuthorComment(string authorCommentId)
        {
            if (authorCommentId.IsNullOrEmpty()) throw new CustomException("В поле authorCommentId пусто");
            var result = await _commentRepository.GetAuthorComment(authorCommentId);
            if (result == null) throw new CustomException("Коментарий не найден");
            await _commentRepository.DeleteAuthorComment(result);
        }

        public async Task DeleteBookComment(string bookCommentId)
        {
            if (bookCommentId.IsNullOrEmpty()) throw new CustomException("В поле bookCommentId пусто");
            var result = await _commentRepository.GetBookComment(bookCommentId);
            if (result == null) throw new CustomException("Коментарий не найден");
            await _commentRepository.DeleteBookComment(result);
        }

        private async Task<bool> IsLikeBookComment(string bookCommentId, string userId)
        {
            var result = await _commentRepository.GetBookComment(bookCommentId);
            return result.BookCommentLikes.Any(w => string.Equals(w.UserId, userId));
        }

        private async Task<bool> IsLikeAuthorComment(string authorCommentId, string userId)
        {
            var result = await _commentRepository.GetAuthorComment(authorCommentId);
            return result.AuthorCommentLikes.Any(w => string.Equals(w.UserId, userId));
        }


        public void Dispose()
        {
            if (_disposed) return;
            _commentRepository?.Dispose();
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        ~CommentService()
        {
            Dispose();
        }
    }
}