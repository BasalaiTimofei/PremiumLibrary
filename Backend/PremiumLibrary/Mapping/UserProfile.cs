using System;
using AutoMapper;
using PremiumLibrary.Models.DataBaseModels;
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
                    e => e.MapFrom(q => q.UserName));

            CreateMap<Registration, User>()
                .ForMember(w => w.Id,
                    e => e.MapFrom(q => Guid.NewGuid().ToString()))
                .ForMember(w => w.EmailAddress,
                    e => e.MapFrom(q => q.EmailAddress))
                .ForMember(w => w.Password,
                    e => e.MapFrom(q => q.Password))
                .ForMember(w => w.UserName,
                    e => e.MapFrom(q => q.UserName))
                .ForMember(w => w.Roles, e => e.Ignore());
        }
    }
}
