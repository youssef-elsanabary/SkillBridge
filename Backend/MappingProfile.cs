using AutoMapper;
using Backend.DTO;
using Backend.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProfileDto, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));
        CreateMap<RegisterDto, User>();
        CreateMap<LoginDto, User>();
        CreateMap<User, ProfileDto>(); 
      
    }
}
