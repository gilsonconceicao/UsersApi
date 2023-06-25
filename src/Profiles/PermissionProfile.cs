using AutoMapper;
using UsersApi.src.DTOs;
using UsersApi.src.Models;

namespace UsersApi.src.Profiles;

public class PermissionProfile : Profile 
{
    public PermissionProfile()
    {
        CreateMap<CreatePermission, Permissions>(); 
        CreateMap<Permissions, ReadPermissionDto>();
        CreateMap<ReadPermissionDto, Permissions>();
    }        
}
