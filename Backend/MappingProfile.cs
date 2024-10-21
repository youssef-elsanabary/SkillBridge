using AutoMapper;
using Backend.DTO;
using Backend.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProfileDto, User>()
            .ForMember(dest => dest.Image, opt => opt.Ignore()); // Image is handled separately
        CreateMap<User, ProfileDto>();
        CreateMap<RegisterDto, User>();
        CreateMap<LoginDto, User>();
    }
}
