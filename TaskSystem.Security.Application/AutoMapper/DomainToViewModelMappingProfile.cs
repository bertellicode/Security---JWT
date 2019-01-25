using AutoMapper;
using Security.Application.ViewModels;
using Security.Domain.Users.DTOs;
using Security.Domain.Users.Entities;

namespace Security.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();

            CreateMap<TokenDto, TokenViewModel>();

            CreateMap<TokenDto, LoginReturnViewModel>()
                .ConstructUsing((tokenDto, context) => new LoginReturnViewModel(context.Mapper.Map<TokenViewModel>(tokenDto)));
        }
    }
}
