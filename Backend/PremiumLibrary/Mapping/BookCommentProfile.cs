using System;
using System.Collections.Generic;
using AutoMapper;
using PremiumLibrary.Models.DataBaseModels.BookFolder;
using PremiumLibrary.Models.ViewModels.Comment;

namespace PremiumLibrary.Mapping
{
    public class BookCommentProfile : Profile
    {
        public BookCommentProfile()
        {
            CreateMap<BookCommentCreateModel, BookComment>()
                .ForMember(w => w.Id,
                    e => e.MapFrom(q => Guid.NewGuid().ToString()))
                .ForMember(w => w.Comment,
                    e => e.MapFrom(q => q.Comment))
                .ForMember(w => w.DateTime,
                    e => e.MapFrom(q => DateTime.Now))
                .ForMember(w => w.BookId,
                    e => e.MapFrom(q => q.BookId))
                .ForMember(w => w.BookCommentLikes,
                    e => e.MapFrom(q => new List<BookCommentLike>()))
                .ForMember(w => w.Book,
                    e => e.Ignore())
                .ForMember(w => w.User,
                    e => e.Ignore());

            CreateMap<BookComment, BookCommentListingModel>()
                .ForMember(w => w.Id,
                    e => e.MapFrom(q => q.Id))
                .ForMember(w => w.Comment,
                    e => e.MapFrom(q => q.Comment))
                .ForMember(w => w.DateTime,
                    q => q.MapFrom(e => e.DateTime))
                .ForMember(w => w.ImageUrl,
                    e => e.MapFrom(q => q.User.ImageUrl))
                .ForMember(w => w.UserName,
                    e => e.MapFrom(q => q.User.UserName))
                .ForMember(w => w.Likes,
                    e => e.MapFrom(q => q.BookCommentLikes.Count))
                .ForMember(w => w.Like,
                    e => e.Ignore());
        }
    }
}
