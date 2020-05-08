using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Core.Internal;
using PremiumLibrary.Models.DataBaseModels.AuthorFolder;
using PremiumLibrary.Models.DataBaseModels.BookFolder;
using PremiumLibrary.Models.DataBaseModels.GenreFolder;
using PremiumLibrary.Models.ViewModels.Book;

namespace PremiumLibrary.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookCreateModel, Book>()
                .ForMember(w => w.Id,
                    e => e.MapFrom(q => Guid.NewGuid().ToString()))
                .ForMember(w => w.Name,
                    e => e.MapFrom(q => q.Name))
                .ForMember(w => w.Description,
                    e => e.MapFrom(q => q.Description))
                .ForMember(w => w.BookUrl,
                    e => e.MapFrom(q => q.BookUrl))
                .ForMember(w => w.ImageIrl,
                    e => e.MapFrom(q => q.ImageUrl.IsNullOrEmpty() ? Constant.DEFAULT_IMAGE_URL : q.ImageUrl))
                .ForMember(w => w.Year,
                    e => e.MapFrom(q => q.Year))
                .ForMember(w => w.Authors,
                    e => e.MapFrom(q => new List<AuthorBook>()))
                .ForMember(w => w.Assessments,
                    e => e.MapFrom(q => new List<BookAssessment>()))
                .ForMember(w => w.Comments,
                    e => e.MapFrom(q => new List<BookComment>()))
                .ForMember(w => w.Genres,
                    e => e.MapFrom(q => new List<GenreBook>()))
                .ForMember(w => w.Likes,
                    e => e.MapFrom(q => new List<BookLike>()))
                .ForMember(w => w.Processes,
                    e => e.MapFrom(q => new List<BookProcess>()));

            CreateMap<Book, BookListingModel>()
                .ForMember(w => w.Id,
                    e => e.MapFrom(q => q.Id))
                .ForMember(w => w.Name,
                    e => e.MapFrom(q => q.Name))
                .ForMember(w => w.Description,
                    e => e.MapFrom(q => q.Description))
                .ForMember(w => w.ImageUrl,
                    e => e.MapFrom(q => q.ImageIrl))
                .ForMember(w => w.BookUrl,
                    e => e.MapFrom(q => q.BookUrl))
                .ForMember(w => w.Year,
                    e => e.MapFrom(q => q.Year))
                .ForMember(w => w.Assessment,
                e => e.MapFrom(q => q.Assessments.Count != 0 ? q.Assessments.Sum(r => r.Count) / q.Assessments.Count : 0))
                .ForMember(w => w.YourAssessment,
                    e => e.Ignore())
                .ForMember(w => w.Genres,
                e => e.MapFrom(q => q.Genres.Count != 0 ? q.Genres.Select(s => s.Genre.Name) : new List<string>()))
                .ForMember(w => w.Comments,
                    e => e.MapFrom(q => q.Comments.Count))
                .ForMember(w => w.Likes,
                    e => e.MapFrom(q => q.Likes.Count))
                .ForMember(w => w.Like,
                    e => e.Ignore())
                .ForMember(w => w.Process,
                    e => e.Ignore());
        }
    }
}
