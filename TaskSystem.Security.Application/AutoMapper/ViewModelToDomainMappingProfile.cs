using AutoMapper;
using Security.Application.ViewModels;
using Security.Domain.Users.Entities;

namespace Security.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserViewModel, User>();
        }
    }
}
