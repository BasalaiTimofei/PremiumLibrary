using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PremiumLibrary.Models.DataBaseModels.Book;
using PremiumLibrary.Models.ViewModels.Author;

namespace PremiumLibrary.Mapping
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorCreateModel, Author>()
                .ForMember(w => w.Id,
                    e => e.MapFrom(q => Guid.NewGuid().ToString()))
                .ForMember(w => w.FirstName,
                    e => e.MapFrom(q => q.FirstName))
                .ForMember(w => w.SecondName,
                    e => e.MapFrom(q => q.SecondName))
                .ForMember(w => w.ImageUrl,
                    e => e.MapFrom(q => q.ImageUrl))
                .ForMember(w => w.AuthorBooks,
                    e => e.MapFrom(q => new List<AuthorBook>()))
                .ForMember(w => w.AuthorComments,
                    e => e.MapFrom(q => new List<AuthorComment>()))
                .ForMember(w => w.AuthorLikes,
                    e => e.MapFrom(q => new List<AuthorLike>()));

            CreateMap<Author, AuthorListingModel>()
                .ForMember(w => w.Id,
                    e => e.MapFrom(q => q.Id))
                .ForMember(w => w.FullName,
                    e => e.MapFrom(q => $"{q.SecondName} {q.FirstName}"))
                .ForMember(w => w.ImageUrl,
                    e => e.MapFrom(q => q.ImageUrl))
                .ForMember(w => w.Comments,
                    e => e.MapFrom(q => q.AuthorComments.Count))
                .ForMember(w => w.Likes,
                    e => e.MapFrom(q => q.AuthorLikes.Count))
                .ForMember(w => w.Books,
                    e => e.MapFrom(q => q.AuthorBooks.Count))
                .ForMember(w => w.Like,
                    e => e.Ignore());
        }
    }
}
