using System;
using System.Collections.Generic;
using AutoMapper;
using PremiumLibrary.Models.DataBaseModels.AuthorFolder;
using PremiumLibrary.Models.ViewModels.Comment;

namespace PremiumLibrary.Mapping
{
    public class AuthorCommentProfile : Profile
    {
        public AuthorCommentProfile()
        {
            CreateMap<AuthorCommentCreateModel, AuthorComment>()
                .ForMember(w => w.Id,
                    e => e.MapFrom(q => Guid.NewGuid().ToString()))
                .ForMember(w => w.Comment,
                    e => e.MapFrom(q => q.Comment))
                .ForMember(w => w.DateTime,
                    e => e.MapFrom(q => DateTime.Now))
                .ForMember(w => w.AuthorCommentLikes,
                    e => e.MapFrom(q => new List<AuthorCommentLike>()))
                .ForMember(w => w.UserId,
                    e => e.MapFrom(q => q.UserId))
                .ForMember(w => w.AuthorId,
                    e => e.MapFrom(q => q.AuthorId))
                .ForMember(w => w.User,
                    e => e.Ignore())
                .ForMember(w => w.Author,
                    e => e.Ignore());

            CreateMap<AuthorComment, AuthorCommentListingModel>()
                .ForMember(w => w.Id,
                    e => e.MapFrom(q => q.Id))
                .ForMember(w => w.Comment,
                    e => e.MapFrom(q => q.Comment))
                .ForMember(w => w.DateTime,
                    e => e.MapFrom(q => q.DateTime))
                .ForMember(w => w.ImageUrl,
                    e => e.MapFrom(q => q.User.ImageUrl))
                .ForMember(w => w.UserName,
                    e => e.MapFrom(q => q.User.UserName))
                .ForMember(w => w.Likes,
                    e => e.MapFrom(q => q.AuthorCommentLikes.Count))
                .ForMember(w => w.Like,
                    e => e.Ignore());
        }
    }
}
