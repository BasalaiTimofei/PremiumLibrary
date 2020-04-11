using AutoMapper;
using PremiumLibrary.Models.DataBaseModels;
using PremiumLibrary.Models.ViewModels.Role;

namespace PremiumLibrary.Mapping
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleListingModel>()
                .ForMember(w => w.Id,
                    e => e.MapFrom(q => q.Id))
                .ForMember(w => w.Name,
                    e => e.MapFrom(q => q.Name));
        }
    }
}
