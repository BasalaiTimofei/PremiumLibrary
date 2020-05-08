using System;
using System.Collections.Generic;
using AutoMapper;
using PremiumLibrary.Models.DataBaseModels;
using PremiumLibrary.Models.DataBaseModels.AuthorFolder;
using PremiumLibrary.Models.DataBaseModels.BookFolder;
using PremiumLibrary.Models.DataBaseModels.GenreFolder;
using PremiumLibrary.Models.ViewModels.User;

namespace PremiumLibrary.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserListingModel>()
                .ForMember(w => w.Id,
                    e => e.MapFrom(q => q.Id))
                .ForMember(w => w.UserName,
                    e => e.MapFrom(q => q.UserName))
                .ForMember(w => w.ImageUrl,
                    e => e.MapFrom(q => q.ImageUrl));

            CreateMap<Registration, User>()
                .ForMember(w => w.Id,
                    e => e.MapFrom(q => Guid.NewGuid().ToString()))
                .ForMember(w => w.EmailAddress,
                    e => e.MapFrom(q => q.EmailAddress))
                .ForMember(w => w.ImageUrl,
                    e => e.MapFrom(q =>
                        string.IsNullOrWhiteSpace(q.ImageUrl) ? Constant.DEFAULT_IMAGE_URL : q.ImageUrl))
                .ForMember(w => w.Password,
                    e => e.MapFrom(q => q.Password))
                .ForMember(w => w.UserName,
                    e => e.MapFrom(q => q.UserName))
                .ForMember(w => w.Roles,
                    e => e.MapFrom(q => new List<UserRole>()))
                .ForMember(w => w.AuthorLikes,
                    e => e.MapFrom(q => new List<AuthorLike>()))
                .ForMember(w => w.AuthorComments,
                    e => e.MapFrom(q => new List<AuthorComment>()))
                .ForMember(w => w.AuthorCommentLikes,
                    e => e.MapFrom(q => new List<AuthorCommentLike>()))
                .ForMember(w => w.BookAssessments,
                    e => e.MapFrom(q => new List<BookAssessment>()))
                .ForMember(w => w.BookComments,
                    e => e.MapFrom(q => new List<BookComment>()))
                .ForMember(w => w.BookCommentLikes,
                    e => e.MapFrom(q => new List<BookCommentLike>()))
                .ForMember(w => w.BookLikes,
                    e => e.MapFrom(q => new List<BookLike>()))
                .ForMember(w => w.BookProcesses,
                    e => e.MapFrom(q => new List<BookProcess>()))
                .ForMember(w => w.GenreLikes,
                    e => e.MapFrom(q => new List<GenreLike>()));
        }
    }
}
