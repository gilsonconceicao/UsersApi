using AutoMapper;
using UsersApiStudy.src.DTOs;
using UsersApiStudy.src.Models;

namespace UsersApiStudy.src.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, ReadUserDto>().ReverseMap(); 
        CreateMap<CreateUserDto, User>().ReverseMap();
        CreateMap<UpdateUserDto, User>().ReverseMap(); 
    }
}
