using AutoMapper;
using Security.Application.ViewModels;
using Security.Domain.Users.Entities;

namespace Security.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
