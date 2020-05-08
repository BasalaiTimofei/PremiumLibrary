using System;
using System.Collections.Generic;
using AutoMapper;
using Castle.Core.Internal;
using PremiumLibrary.Models.DataBaseModels.GenreFolder;
using PremiumLibrary.Models.ViewModels.Genre;

namespace PremiumLibrary.Mapping
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<GenreCreateModel, Genre>()
                .ForMember(w => w.Id,
                    e => e.MapFrom(q => Guid.NewGuid().ToString()))
                .ForMember(w => w.Name,
                    e => e.MapFrom(q => q.Name))
                .ForMember(w => w.ImageUrl,
                    e => e.MapFrom(q => q.ImageUrl.IsNullOrEmpty() ? Constant.DEFAULT_IMAGE_URL : q.ImageUrl))
                .ForMember(w => w.Likes,
                    e => e.MapFrom(q => new List<GenreLike>()))
                .ForMember(w => w.Books,
                    e => e.MapFrom(q => new List<GenreBook>()));

            CreateMap<Genre, GenreListingModel>()
                .ForMember(w => w.Id,
                    e => e.MapFrom(q => q.Id))
                .ForMember(w => w.Name,
                    e => e.MapFrom(q => q.Name))
                .ForMember(w => w.ImageUrl,
                    e => e.MapFrom(q => q.ImageUrl))
                .ForMember(w => w.Likes,
                    e => e.MapFrom(q => q.Likes.Count))
                .ForMember(w => w.Like,
                    e => e.Ignore());
        }
    }
}
